using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Hubs;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ICustomerCharacterService
    {
        Task<bool> AddCustomerCharacter(CustomerCharacterRequest customerCharacterRequest);
        Task<bool> UpdateCustomerCharacter(string accountId, string customerCharacterRequestId, UpdateCustomerCharacterRequest updateCustomerCharacterRequest);
        Task<bool> UpadateStatusCustomerCharacter(string customerCharacterId, string status, string? reason, double? price);
        Task<List<CustomerCharacterReponse>> GetCustomerCharacterList(string? customerCharacterId, string? accountId, string? categoryId, string? createDate,string? status);
        Task<List<CustomerCharacterReponse>> GetAllCustomerCharacterByAccountId(string accountId);
    }
    public class CustomerCharacterService : ICustomerCharacterService
    {
        private readonly ICustomerCharacterRepository customerCharacterRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICustomerCharacterImageRepository customerCharacterImageRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;
        private readonly Image image;
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly ICharacterRepository characterRepository;
        private readonly ICharacterImageRepository characterImageRepository;
        public CustomerCharacterService(ICharacterImageRepository characterImageRepository, ICharacterRepository characterRepository, IAccountRepository accountRepository, IHubContext<NotificationHub> hubContext, ICustomerCharacterImageRepository customerCharacterImageRepository, Image image, IMapper mapper, ICategoryRepository categoryRepository, ICustomerCharacterRepository customerCharacterRepository)
        {
            this.customerCharacterRepository = customerCharacterRepository; 
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.image = image;
            this.customerCharacterImageRepository = customerCharacterImageRepository;
            this.hubContext = hubContext;
            this.accountRepository = accountRepository;
            this.characterRepository = characterRepository;
            this.characterImageRepository = characterImageRepository;
        }
        public async Task<bool> AddCustomerCharacter(CustomerCharacterRequest customerCharacterRequest)
        {
            try
            {
                List<CustomerCharacterImage> images = new List<CustomerCharacterImage>();
                Category category = await categoryRepository.GetCategory(customerCharacterRequest.CategoryId);
                if (category == null)
                {
                    throw new Exception("Category does not exist");
                }

                if (customerCharacterRequest.MaxHeight <= 0 || customerCharacterRequest.MinHeight <= 0 || customerCharacterRequest.MaxWeight <= 0 || customerCharacterRequest.MinWeight <= 0)
                {
                    throw new Exception("MaxHeight, MinHeight, MaxWeight, MinWeight must be greater than 0");
                }
                float minWeight = (float)customerCharacterRequest.MinWeight;

                if (customerCharacterRequest.MaxWeight < minWeight + 10)
                {
                    throw new Exception("MaxWeight must be greater than MinWeight is 10");
                }

                float minHeight = (float)customerCharacterRequest.MinHeight;

                if (customerCharacterRequest.MaxHeight < minHeight + 10)
                {
                    throw new Exception("MaxHeight must be greater than MinHeight is 10");
                }

                Account customer = await accountRepository.GetAccount(customerCharacterRequest.CreateBy);
                if (customer == null)
                {
                    throw new Exception("Customer does not exist");
                }
                if(customer.Role.RoleName != RoleName.Customer)
                {
                    throw new Exception("Account must be customer");
                }
                
                CustomerCharacter customerCharacter = new CustomerCharacter()
                {
                    Status = CustomerCharacterStatus.Pending,
                    CategoryId = customerCharacterRequest.CategoryId,
                    CreateDate = DateTime.UtcNow.AddHours(7),
                    Description = customerCharacterRequest.Description,
                    MaxHeight = customerCharacterRequest.MaxHeight,
                    MaxWeight = customerCharacterRequest.MaxWeight,
                    MinHeight = customerCharacterRequest.MinHeight,
                    MinWeight = customerCharacterRequest.MinWeight,
                    Name = customerCharacterRequest.Name,
                    CreateBy = customerCharacterRequest.CreateBy,
                };

                bool checkAddCusCha = await customerCharacterRepository.AddCustomerCharacter(customerCharacter);
                if (!checkAddCusCha)
                {
                    throw new Exception("Can not add CustomerCharacter");
                }
                foreach (var imageCusCha in customerCharacterRequest.CustomerCharacterImages)
                {
                    string urlImage = await image.UploadImageToFirebase(imageCusCha);
                    CustomerCharacterImage customerCharacterImage = new CustomerCharacterImage()
                    {
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        CustomerCharacterImageId = Guid.NewGuid().ToString(),
                        CustomerCharacterId = customerCharacter.CustomerCharacterId,
                        UpdateDate = null,
                        UrlImage = urlImage,
                    };

                    images.Add(customerCharacterImage);
                }

                bool result = await customerCharacterImageRepository.AddListCustomerCharacterImage(images);
                if (!result)
                {
                    throw new Exception("Can not add CustomerCharacterImage");
                }
                return await NortificationManager();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<CustomerCharacterReponse>> GetAllCustomerCharacterByAccountId(string accountId)
        {
            try
            {
                List<CustomerCharacterReponse> ccr = new List<CustomerCharacterReponse>();
                List<CustomerCharacterImageResponse> cci = new List<CustomerCharacterImageResponse>();
                List<CustomerCharacter> customerCharacters = await customerCharacterRepository.GetAllCustomerCharacterByAccountId(accountId);

                if (customerCharacters == null)
                {
                    return ccr;
                }

                foreach (CustomerCharacter customerCharacter in customerCharacters)
                {
                    foreach (var imageCusCha in customerCharacter.CustomerCharacterImages)
                    {
                        CustomerCharacterImageResponse customerCharacterImageResponse = new CustomerCharacterImageResponse()
                        {
                            CreateDate = imageCusCha.CreateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                            CustomerCharacterImageId = imageCusCha.CustomerCharacterImageId,
                            UpdateDate = imageCusCha.UpdateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                            UrlImage = imageCusCha.UrlImage
                        };

                        cci.Add(customerCharacterImageResponse);
                    }

                    CustomerCharacterReponse customerCharacterReponse = new CustomerCharacterReponse()
                    {
                        CategoryId = customerCharacter.CategoryId,
                        UpdateDate = customerCharacter.UpdateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                        CreateBy = customerCharacter.CreateBy,
                        CreateDate = customerCharacter.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                        CustomerCharacterId = customerCharacter.CustomerCharacterId,
                        Description = customerCharacter.Description,
                        MaxHeight = customerCharacter.MaxHeight,
                        MaxWeight = customerCharacter.MaxWeight,
                        MinHeight = customerCharacter.MinHeight,
                        MinWeight = customerCharacter.MinWeight,
                        Name = customerCharacter.Name,
                        Reason = customerCharacter.Reason,
                        Status = customerCharacter.Status.ToString(),
                        CustomerCharacterImageResponses = cci
                    };

                    ccr.Add(customerCharacterReponse);

                    cci = new List<CustomerCharacterImageResponse>();
                }

                return ccr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<CustomerCharacterReponse>> GetCustomerCharacterList(string? customerCharacterId, string? accountId, string? categoryId, string? createDate, string? status)
        {
            try
            {
                List<CustomerCharacterReponse> ccr = new List<CustomerCharacterReponse>();
                List<CustomerCharacterImageResponse> cci = new List<CustomerCharacterImageResponse>();
                List<CustomerCharacter> customerCharacters = await customerCharacterRepository.GetCustomerCharacters(customerCharacterId, accountId, categoryId, createDate, status);
            
                if(customerCharacters == null)
                {
                    return ccr;
                }

                foreach (CustomerCharacter customerCharacter in customerCharacters)
                {
                    foreach(var imageCusCha in customerCharacter.CustomerCharacterImages)
                    {
                        CustomerCharacterImageResponse customerCharacterImageResponse = new CustomerCharacterImageResponse()
                        {
                            CreateDate = imageCusCha.CreateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                            CustomerCharacterImageId = imageCusCha.CustomerCharacterImageId,
                            UpdateDate = imageCusCha.UpdateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                            UrlImage = imageCusCha.UrlImage
                        };

                        cci.Add(customerCharacterImageResponse);    
                    }

                    CustomerCharacterReponse customerCharacterReponse = new CustomerCharacterReponse()
                    {
                        CategoryId = customerCharacter.CategoryId,
                        UpdateDate = customerCharacter.UpdateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                        CreateBy = customerCharacter.CreateBy,
                        CreateDate = customerCharacter.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                        CustomerCharacterId = customerCharacter.CustomerCharacterId,
                        Description = customerCharacter.Description,
                        MaxHeight = customerCharacter.MaxHeight,
                        MaxWeight = customerCharacter.MaxWeight,
                        MinHeight = customerCharacter.MinHeight,
                        MinWeight = customerCharacter.MinWeight,    
                        Name = customerCharacter.Name,  
                        Reason = customerCharacter.Reason,
                        Status = customerCharacter.Status.ToString(),
                        CustomerCharacterImageResponses = cci
                    };

                    ccr.Add(customerCharacterReponse);

                    cci = new List<CustomerCharacterImageResponse>();
                }

                return ccr; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpadateStatusCustomerCharacter(string customerCharacterId, string status, string? reason, double? price)
        {
            try
            {
                CustomerCharacter customerCharacter = await customerCharacterRepository.GetCustomerCharacterById(customerCharacterId);
                if (customerCharacter == null)
                {
                    throw new Exception("CustomerCharacter does not exist");
                }

                if(status.ToUpper().Equals(CustomerCharacterStatus.Accept.ToString().ToUpper()))
                {
                    if (customerCharacter.Status == CustomerCharacterStatus.Pending)
                    {
                        customerCharacter.Status = CustomerCharacterStatus.Accept;
                    }
                    else
                    {
                        throw new Exception("Can not update status CustomerCharacter");
                    }
                }

                if (status.ToUpper().Equals(CustomerCharacterStatus.Reject.ToString().ToUpper()))
                {
                    if (!string.IsNullOrEmpty(reason))
                    {
                        if (customerCharacter.Status == CustomerCharacterStatus.Pending)
                        {
                            customerCharacter.Status = CustomerCharacterStatus.Reject;
                            customerCharacter.Reason = reason;
                        }
                        else
                        {
                            throw new Exception("Can not update status CustomerCharacter");
                        }
                    }
                    else
                    {
                        throw new Exception("Please enter reason");
                    }
                }

                if (status.ToUpper().Equals(CustomerCharacterStatus.Completed.ToString().ToUpper()))
                {
                    if (price != null)
                    {
                        if (customerCharacter.Status == CustomerCharacterStatus.Accept)
                        {
                            customerCharacter.Status = CustomerCharacterStatus.Completed;

                            Character character = new Character()
                            {
                                CategoryId = customerCharacter.CategoryId,
                                CharacterName = customerCharacter.Name,
                                CreateDate = DateTime.UtcNow.AddHours(7),
                                Description = customerCharacter.Description,
                                IsActive = true,
                                MaxHeight = customerCharacter.MaxHeight,
                                MaxWeight = customerCharacter.MaxWeight,
                                MinHeight = customerCharacter.MinHeight,
                                MinWeight = customerCharacter.MinWeight,
                                Quantity = 1,
                                Price = price,
                            };
                            bool checkAddCharacter = await characterRepository.CreateCharacter(character);
                            if (!checkAddCharacter)
                            {
                                throw new Exception("Can not add Character");
                            }

                            List<CharacterImage> images = new List<CharacterImage>();
                            int count = 0;

                            foreach(var cci in customerCharacter.CustomerCharacterImages)
                            {
                                CharacterImage characterImage = new CharacterImage()
                                {
                                    CharacterId = character.CharacterId,
                                    CreateDate = DateTime.Now,
                                    UrlImage = cci.UrlImage,
                                };
                                if(count == 0)
                                {
                                    characterImage.IsAvatar = true;
                                }
                                else
                                {
                                    characterImage.IsAvatar = false;
                                }
                                count++;
                                images.Add(characterImage);
                            }

                            bool checkAddCharacterImage = await characterImageRepository.AddCharacterImages(images);
                            if (!checkAddCharacterImage)
                            {
                                throw new Exception("Can not add CharacterImage");
                            }
                        }
                        else
                        {
                            throw new Exception("Can not update status CustomerCharacter");
                        }
                    }
                    else
                    {
                        throw new Exception("Please enter price");
                    }
                }

                bool result = await customerCharacterRepository.UpdateCustomerCharacter(customerCharacter);
                if (!result)
                {
                    throw new Exception("Can not update CustomerCharater");
                }

                return await NortificationCustomer(customerCharacter.CreateBy, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> NortificationCustomer(string accountId, string status)
        {
            Account account = await accountRepository.GetAccount(accountId);
            SendMail sendMail = new SendMail();
            string connectionId = NotificationHub.GetConnectionId(account.AccountId);
            string message = $"Feedback on the request to create a new character.";
            if (!string.IsNullOrEmpty(connectionId))
            {
                await hubContext.Clients.Client(connectionId).SendAsync("StatusCustomerCharacter", message);
            }
            else
            {
                Console.WriteLine($"User {account.AccountId} không online, không thể gửi thông báo");
                bool result = await sendMail.SendCustomerStatusCustomerCharacterEmail(account.Email, status);
                if (!result)
                {
                    Console.WriteLine($"User {account.AccountId} không thể gửi mail");
                }
            }

            return true;
        }

        public async Task<bool> UpdateCustomerCharacter(string accountId, string customerCharacterRequestId, UpdateCustomerCharacterRequest updateCustomerCharacterRequest)
        {
            try
            {
                Account account = await accountRepository.GetAccount(accountId);
                if (account == null)
                {
                    throw new Exception("Account does not exist");
                }

                if(account.Role.RoleName != RoleName.Customer)
                {
                    throw new Exception("Account must be customer");
                }

                Category category = await categoryRepository.GetCategory(updateCustomerCharacterRequest.CategoryId);
                if (category == null)
                {
                    throw new Exception("Category does not exist");
                }

                if (updateCustomerCharacterRequest.MaxHeight <= 0 || updateCustomerCharacterRequest.MinHeight <= 0 || updateCustomerCharacterRequest.MaxWeight <= 0 || updateCustomerCharacterRequest.MinWeight <= 0)
                {
                    throw new Exception("MaxHeight, MinHeight, MaxWeight, MinWeight must be greater than 0");
                }
                float minWeight = (float)updateCustomerCharacterRequest.MinWeight;

                if (updateCustomerCharacterRequest.MaxWeight < minWeight + 10)
                {
                    throw new Exception("MaxWeight must be greater than MinWeight is 10");
                }

                float minHeight = (float)updateCustomerCharacterRequest.MinHeight;

                if (updateCustomerCharacterRequest.MaxHeight < minHeight + 10)
                {
                    throw new Exception("MaxHeight must be greater than MinHeight is 10");
                }

                CustomerCharacter customerCharacter = await customerCharacterRepository.GetCustomerCharacterByIdAndCustomerId(customerCharacterRequestId, account.AccountId);

                if (customerCharacter == null) 
                {
                    throw new Exception("CustomerCharacter does not exist");
                }

                if (customerCharacter.Status != CustomerCharacterStatus.Pending) 
                {
                    throw new Exception("Can not update CustomerCharacter");
                }

                customerCharacter.MinWeight = updateCustomerCharacterRequest.MinWeight;
                customerCharacter.MaxWeight = updateCustomerCharacterRequest.MaxWeight;
                customerCharacter.MaxHeight = updateCustomerCharacterRequest.MaxHeight;
                customerCharacter.MinHeight = updateCustomerCharacterRequest.MinHeight;
                customerCharacter.UpdateDate = DateTime.UtcNow.AddHours(7); 
                customerCharacter.CategoryId = updateCustomerCharacterRequest.CategoryId;
                customerCharacter.Description = updateCustomerCharacterRequest.Description;
                
                bool checkUpdate = await customerCharacterRepository.UpdateCustomerCharacter(customerCharacter);
                if (!checkUpdate)
                {
                    throw new Exception("Can not update CustomerCharacter");
                }

                if (updateCustomerCharacterRequest.CustomerCharacterImages != null)
                {
                    foreach(var imageCusCha in updateCustomerCharacterRequest.CustomerCharacterImages)
                    {
                        string urlImage = await image.UploadImageToFirebase(imageCusCha.Image);

                        CustomerCharacterImage cci = await customerCharacterImageRepository.GetCustomerCharacterImage(imageCusCha.CustomerCharacterImageId);
                        if (cci == null)
                        {
                            throw new Exception("CustomerCharacterImage does not exist");
                        }

                        cci.UrlImage = urlImage;

                        bool checkUpdateImage = await customerCharacterImageRepository.UpdateCustomerCharacterImage(cci);
                        if (!checkUpdateImage) 
                        {
                            throw new Exception("Can not update CustomerCharacteImage");
                        }
                    }
                }

                return await NortificationManager();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> NortificationManager()
        {
            List<Account> accounts = await accountRepository.GetAllAccountRoleManager();
            SendMail sendMail = new SendMail(); 
            foreach (var account in accounts)
            {
                string connectionId = NotificationHub.GetConnectionId(account.AccountId);
                string message = $"You have a new request regarding customer attire.";
                if (!string.IsNullOrEmpty(connectionId))
                {
                    await hubContext.Clients.Client(connectionId).SendAsync("ReceiveCustomerCharacter", message);
                }
                else
                {
                    Console.WriteLine($"User {account.AccountId} không online, không thể gửi thông báo");
                    bool result = await sendMail.SendManagerCustomerCharacterEmail(account.Email);
                    if (!result)
                    {
                        Console.WriteLine($"User {account.AccountId} không thể gửi mail");
                    }
                }
            }

            return true;
        }
    }
}
