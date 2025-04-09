using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;

namespace CCSS_Service.Services
{
    public interface IRequestServices
    {
        Task<List<RequestResponse>> GetAllRequest();
        Task<List<RequestResponse>> GetAllRequestByAccountId(string accountId);
        Task<RequestResponse> GetRequestById(string id);
        Task<string> DeleteRequest(string id);
        Task<string> AddRequest(RequestDtos requestDtos);
        Task<string> UpdateRequest(string requestId, UpdateRequestDtos requestDtos);
        Task<string> UpdateStatusRequest(string requestId, RequestStatus requestStatus);
        Task<double> TotalPriceRequest(double packagePrice, double accountCouponPrice, string startDate, string endDate, List<RequestTotalPrice> requestTotalPrices, string serviceId);
        Task<bool> CheckRequest(string requestId);
    }
    public class RequestServices : IRequestServices
    {
        private readonly IRequestRepository _repository;
        private readonly IRequestCharacterRepository _requestCharacterRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly ITaskRepository taskRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IAccountCouponRepository _accountCouponRepository;
        private readonly IBeginTransactionRepository _beginTransactionRepository;
        private readonly IContractRespository _contractRepository;


        public RequestServices(ITaskRepository taskRepository, IRequestRepository repository, IRequestCharacterRepository requestCharacterRepository, IAccountRepository accountRepository, ICharacterRepository characterRepository, IServiceRepository serviceRepository, IAccountCouponRepository accountCouponRepository, IBeginTransactionRepository beginTransactionRepository, IContractRespository contractRepository)
        {
            _repository = repository;
            _characterRepository = characterRepository;
            _requestCharacterRepository = requestCharacterRepository;
            _accountRepository = accountRepository;
            this.taskRepository = taskRepository;
            _serviceRepository = serviceRepository;
            _accountCouponRepository = accountCouponRepository;
            _beginTransactionRepository = beginTransactionRepository;
            _contractRepository = contractRepository;
        }
        #region GetAll Request
        public async Task<List<RequestResponse>> GetAllRequest()
        {
            List<RequestResponse> listRequest = new List<RequestResponse>();
            var request = await _repository.GetAllRequest();
            foreach (var item in request)
            {
                var listRequestCharacter = await _requestCharacterRepository.GetAllRequestCharacter();

                List<CharacterRequestResponse> characterResponses = listRequestCharacter.Where(sc => sc.RequestId.Equals(item.RequestId)).Select(c => new CharacterRequestResponse()
                {
                    CharacterId = c.CharacterId,
                    CosplayerId = c.CosplayerId,
                    Description = c.Description,
                    Quantity = c.Quantity,
                    MinHeight = c.Character.MinHeight,
                    MaxHeight = c.Character.MaxHeight,
                    MinWeight = c.Character.MinWeight,
                    MaxWeight = c.Character.MaxWeight,
                    CharacterImages = c.Character.CharacterImages
                                      .Select(img => new CharacterImageDto
                                      {
                                          CharacterImageId = img.CharacterImageId,
                                          UrlImage = img.UrlImage
                                      }).ToList(),
                }).ToList();

                RequestResponse response = new RequestResponse()
                {
                    RequestId = item.RequestId,
                    AccountId = item.AccountId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Status = item.Status.ToString(),
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Location = item.Location,
                    ServiceId = item.ServiceId,
                    PackageId = item.PackageId,
                    //ContractId = item.ContractId,
                    CharactersListResponse = characterResponses
                };
                listRequest.Add(response); ;
            }
            return listRequest;
        }
        #endregion

        #region Get Request By Id
        public async Task<RequestResponse> GetRequestById(string id)
        {
            var request = await _repository.GetRequestById(id);
            var listRequestCharacter = await _requestCharacterRepository.GetAllRequestCharacter();

            List<CharacterRequestResponse> characterResponses = listRequestCharacter.Where(sc => sc.RequestId.Equals(request.RequestId)).Select(c => new CharacterRequestResponse()
            {
                CharacterId = c.CharacterId,
                CosplayerId = c.CosplayerId,
                Description = c.Description,
                Quantity = c.Quantity,
                MinHeight = c.Character.MinHeight,
                MaxHeight = c.Character.MaxHeight,
                MinWeight = c.Character.MinWeight,
                MaxWeight = c.Character.MaxWeight,
                CharacterImages = c.Character.CharacterImages
                                      .Select(img => new CharacterImageDto
                                      {
                                          CharacterImageId = img.CharacterImageId,
                                          UrlImage = img.UrlImage
                                      }).ToList()
            }).ToList();

            var response = new RequestResponse()
            {
                RequestId = request.RequestId,
                AccountId = request.AccountId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Status = request.Status.ToString(),
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                ServiceId = request.ServiceId,
                PackageId = request.PackageId,
                //ContractId = request.ContractId,
                CharactersListResponse = characterResponses
            };
            return response;
        }
        #endregion

        public async Task<List<RequestResponse>> GetAllRequestByAccountId(string accountId)
        {
            var account = await _accountRepository.GetAccountByAccountId(accountId);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            List<RequestResponse> listRequest = new List<RequestResponse>();
            var request = await _repository.GetAllRequestByAccountId(account.AccountId);
            foreach (var item in request)
            {
                var listRequestCharacter = await _requestCharacterRepository.GetAllRequestCharacter();

                List<CharacterRequestResponse> characterResponses = listRequestCharacter.Where(sc => sc.RequestId.Equals(item.RequestId)).Select(c => new CharacterRequestResponse()
                {
                    CharacterId = c.CharacterId,
                    CosplayerId = c.CosplayerId,
                    Description = c.Description,
                    Quantity = c.Quantity,
                    MinHeight = c.Character.MinHeight,
                    MaxHeight = c.Character.MaxHeight,
                    MinWeight = c.Character.MinWeight,
                    MaxWeight = c.Character.MaxWeight,
                    CharacterImages = c.Character.CharacterImages
                                      .Select(img => new CharacterImageDto
                                      {
                                          CharacterImageId = img.CharacterImageId,
                                          UrlImage = img.UrlImage
                                      }).ToList(),
                }).ToList();

                RequestResponse response = new RequestResponse()
                {
                    RequestId = item.RequestId,
                    AccountId = item.AccountId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Status = item.Status.ToString(),
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Location = item.Location,
                    ServiceId = item.ServiceId,
                    PackageId = item.PackageId,
                    //ContractId = item.ContractId,
                    CharactersListResponse = characterResponses
                };
                listRequest.Add(response); ;
            }
            return listRequest;
        }

        #region Add Request
        public async Task<string> AddRequest(RequestDtos requestDtos)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;

                if (!string.IsNullOrEmpty(requestDtos.StartDate) || !string.IsNullOrEmpty(requestDtos.EndDate))
                {
                    string[] dateFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                    bool isValidDate = DateTime.TryParseExact(requestDtos.StartDate, dateFormats,
                                                              System.Globalization.CultureInfo.InvariantCulture,
                                                              System.Globalization.DateTimeStyles.None,
                                                              out StartDate);

                    bool isValidEndDate = DateTime.TryParseExact(requestDtos.EndDate, dateFormats,
                                                                 System.Globalization.CultureInfo.InvariantCulture,
                                                                 System.Globalization.DateTimeStyles.None,
                                                                 out EndDate);

                    if (!isValidDate || !isValidEndDate)
                    {
                        return ("Date format is incorrect. Please enter the right format DateTime.");
                    }
                    if (StartDate < DateTime.Now)
                    {
                        return ("Start date cannot be in the past.");
                    }
                    if (EndDate < DateTime.Now)
                    {
                        return ("End date cannot be in the past.");
                    }
                    if (StartDate > EndDate)
                    {
                        return ("End date must be greater than event date.");
                    }
                }

                if (requestDtos == null)
                {
                    return "Need fill request";
                }

                Account customer = await _accountRepository.GetAccount(requestDtos.AccountId);
                if (customer == null)
                {
                    return "Customer does not exist";
                }
                if (customer.Role.RoleName != RoleName.Customer)
                {
                    return "Account must be customer";
                }

                var service = await _serviceRepository.GetService(requestDtos.ServiceId);
                if (service == null)
                {
                    return "please choose services you want";
                }
                if (service.ServiceId != "S003")
                {
                    requestDtos.PackageId = null;
                }
                if (!string.IsNullOrEmpty(requestDtos.AccountCouponId))
                {
                    var accountCoupon = await _accountCouponRepository.GetAccountCouponById(requestDtos.AccountCouponId);
                    if (accountCoupon == null)
                    {
                        return "This AccountCoupon is not found";
                    }
                    if (accountCoupon.Coupon.Type != CouponType.ForContract)
                    {
                        return "This coupon not use for contract";
                    }
                    if (accountCoupon.IsActive == true)
                    {
                        return "This coupon be used";
                    }
                }

                var newRequest = new Request()
                {
                    RequestId = Guid.NewGuid().ToString(),
                    AccountId = requestDtos.AccountId,
                    Name = requestDtos.Name,
                    Price = requestDtos.Price,
                    Description = requestDtos.Description,
                    Status = RequestStatus.Pending,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Location = requestDtos.Location,
                    ServiceId = requestDtos.ServiceId,
                    PackageId = requestDtos.PackageId,
                    //ContractId = null,
                    AccountCouponId = requestDtos.AccountCouponId ?? null,
                };
                var result = await _repository.AddRequest(newRequest);
                if (!result)
                {
                    await transaction.RollbackAsync();
                    return "Add Request Failed";
                }
                else
                {
                    if (requestDtos.ListRequestCharacters != null && requestDtos.ListRequestCharacters.Any())
                    {
                        List<RequestCharacter> characteInRequest = new List<RequestCharacter>();

                        foreach (var r in requestDtos.ListRequestCharacters)
                        {
                            if (service.ServiceId != "S002")
                            {
                                r.CosplayerId = null;
                                var checkCharacter = await _characterRepository.GetCharacter(r.CharacterId);
                                if (checkCharacter.Quantity == 0 || r.Quantity > checkCharacter.Quantity)
                                {
                                    await transaction.RollbackAsync();
                                    return $"Not enough stock for character {r.CharacterId}.";
                                }
                            }
                            else /*(service.ServiceId == "S002")*/
                            {
                                r.Quantity = 1;
                                if (r.CosplayerId != null)
                                {
                                    if (characteInRequest.Any(c => c.CosplayerId == r.CosplayerId))
                                    {
                                        await transaction.RollbackAsync();
                                        return $"Cosplayer with ID {r.CosplayerId} is already added.";
                                    }
                                    var checkCharacter = await _characterRepository.GetCharacter(r.CharacterId);
                                    if (checkCharacter == null)
                                    {
                                        await transaction.RollbackAsync();
                                        return "Character does not exist";
                                    }
                                    var account = await _accountRepository.GetAccount(r.CosplayerId);
                                    bool checkAccount = await _characterRepository.CheckCharacterForAccount(account, r.CharacterId);
                                    if (!checkAccount)
                                    {
                                        await transaction.RollbackAsync();
                                        return "Cosplayer does not suitable.";
                                    }

                                    bool checkTask = await taskRepository.CheckTaskIsValid(account, StartDate, EndDate);
                                    if (!checkTask)
                                    {
                                        await transaction.RollbackAsync();
                                        return "This cosplayer is has another job. Please change datetime.";
                                    }
                                    var character = await _accountRepository.GetAccount(r.CosplayerId);
                                    if (character.RoleId != "R004" || character == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                                    {
                                        await transaction.RollbackAsync();
                                        return "This cosplayer not found";
                                    }
                                }
                            }
                            var Getcharacter = await _characterRepository.GetCharacter(r.CharacterId);
                            var totalPrice = Getcharacter.Price * r.Quantity;
                            // Nếu CosplayerId hợp lệ, thêm vào danh sách
                            characteInRequest.Add(new RequestCharacter
                            {
                                RequestCharacterId = Guid.NewGuid().ToString(),
                                RequestId = newRequest.RequestId,
                                Description = r.Description,
                                CharacterId = r.CharacterId,
                                CreateDate = newRequest.StartDate,
                                Quantity = r.Quantity,
                                CosplayerId = r.CosplayerId,
                                TotalPrice = totalPrice,
                            });
                        }
                        var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                        if (!requestCharacterAdd)
                        {
                            await transaction.RollbackAsync();
                            return "Failed to add characters in Request";
                        }

                    }
                    await transaction.CommitAsync();
                    return "Add Request Success";
                }
            }

        }
        #endregion

        #region Update Request
        public async Task<string> UpdateRequest(string requestId, UpdateRequestDtos UpdateRequestDtos)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;

                if (!string.IsNullOrEmpty(UpdateRequestDtos.StartDate) || !string.IsNullOrEmpty(UpdateRequestDtos.EndDate))
                {
                    string[] dateFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                    bool isValidDate = DateTime.TryParseExact(UpdateRequestDtos.StartDate, dateFormats,
                                                              System.Globalization.CultureInfo.InvariantCulture,
                                                              System.Globalization.DateTimeStyles.None,
                                                              out StartDate);

                    bool isValidEndDate = DateTime.TryParseExact(UpdateRequestDtos.EndDate, dateFormats,
                                                                 System.Globalization.CultureInfo.InvariantCulture,
                                                                 System.Globalization.DateTimeStyles.None,
                                                                 out EndDate);

                    if (!isValidDate || !isValidEndDate)
                    {
                        return ("Date format is incorrect. Please enter the right format DateTime.");
                    }
                    if (StartDate < DateTime.Now)
                    {
                        return ("Start date cannot be in the past.");
                    }
                    if (EndDate < DateTime.Now)
                    {
                        return ("End date cannot be in the past.");
                    }
                    if (StartDate > EndDate)
                    {
                        return ("End date must be greater than event date.");
                    }
                }
                var requestExisting = await _repository.GetRequestById(requestId);
                if (requestExisting == null)
                {
                    return "Request is not found";
                }

                List<RequestCharacter> characterInRequest = new List<RequestCharacter>();
                foreach (var r in UpdateRequestDtos.ListUpdateRequestCharacters)
                {
                    if (r.CosplayerId != null)
                    {
                        var checkCharacter = await _characterRepository.GetCharacter(r.CharacterId);
                        if (checkCharacter == null)
                        {
                            await transaction.RollbackAsync();
                            return "Character does not exist";
                        }
                        var account = await _accountRepository.GetAccount(r.CosplayerId);
                        bool checkAccount = await _characterRepository.CheckCharacterForAccount(account, r.CharacterId);
                        if (!checkAccount)
                        {
                            await transaction.RollbackAsync();
                            return "Cosplayer does not suitable.";
                        }
                        bool checkTask = await taskRepository.CheckTaskIsValid(account, StartDate, EndDate);
                        if (!checkTask)
                        {
                            await transaction.RollbackAsync();
                            return "This cosplayer is has another job. Please change datetime.";
                        }
                        var cosplayer = await _accountRepository.GetAccount(r.CosplayerId);
                        if (cosplayer.RoleId != "R004" || cosplayer == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                        {
                            await transaction.RollbackAsync();
                            return "This cosplayer not found";
                        }
                    }

                    var requestCharacter = await _requestCharacterRepository.GetRequestCharacter(requestExisting.RequestId, r.CharacterId);
                    var character = await _characterRepository.GetCharacter(r.CharacterId);
                    if (requestCharacter == null)
                    {
                        await transaction.RollbackAsync();
                        return "Request Character not found";
                    }
                    else
                    {
                        int quantity = (requestExisting.ServiceId != "S001") ? 1 : (r.Quantity ?? 1);
                        if (quantity > character.Quantity)
                        {
                            await transaction.RollbackAsync();
                            return $"Not enough stock for character {character.CharacterName}.";
                        }


                        requestCharacter.CreateDate = StartDate;
                        requestCharacter.UpdateDate = DateTime.Now;
                        requestCharacter.CosplayerId = r.CosplayerId;
                        requestCharacter.Description = r.Description;
                        requestCharacter.Quantity = quantity;

                        characterInRequest.Add(requestCharacter);

                        character.Quantity -= quantity;
                        await _characterRepository.UpdateCharacter(character);
                    }
                }

                if (characterInRequest.Any())
                {
                    await _requestCharacterRepository.UpdateListRequestCharacter(characterInRequest);
                }
                else
                {
                    await transaction.RollbackAsync();
                    return "Cant Update Character Request";
                }

                requestExisting.Name = UpdateRequestDtos.Name;
                requestExisting.Description = UpdateRequestDtos.Description;
                requestExisting.StartDate = StartDate;
                requestExisting.EndDate = EndDate;
                requestExisting.Location = UpdateRequestDtos.Location;
                requestExisting.ServiceId = UpdateRequestDtos.ServiceId;

                await _repository.UpdateRequest(requestExisting);

                await transaction.CommitAsync();
                return "Update request Success";
            }

        }
        #endregion

        #region Update Request Status
        public async Task<string> UpdateStatusRequest(string requestId, RequestStatus requestStatus)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {

                var request = await _repository.GetRequestById(requestId);
                var listRequestCharacters = await _requestCharacterRepository.GetListCharacterByRequest(requestId);

                if (request == null)
                {
                    await transaction.RollbackAsync();
                    return "Request not found";
                }

                if (requestStatus == RequestStatus.Browsed)
                {
                    foreach (var c in listRequestCharacters)
                    {
                        var character = await _characterRepository.GetCharacter(c.CharacterId);
                        if (character == null)
                        {
                            await transaction.RollbackAsync();
                            return "Character is not found";
                        }
                        character.Quantity -= c.Quantity;
                        character.UpdateDate = DateTime.Now;
                        var result = await _characterRepository.UpdateCharacter(character);
                        if (!result)
                        {
                            await transaction.RollbackAsync();
                            return "Update Character failed";
                        }
                    }
                }

                request.Status = requestStatus;
                await _repository.UpdateRequest(request);

                await transaction.CommitAsync();
                return "Status is update success";
            }
        }
        #endregion

        #region Delete Request
        public async Task<string> DeleteRequest(string id)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                var contract = await _contractRepository.GetContractByRequestId(id);
                var request = await _repository.GetRequestById(id);
                if (contract != null)
                {
                    await transaction.RollbackAsync();
                    return $"contract is existed, cannot delete this request {request.RequestId}";
                }
                else
                {
                    if (request == null)
                    {
                        await transaction.RollbackAsync();
                        return "Request not found";
                    }

                    request.Status = RequestStatus.Cancel;
                    await _repository.UpdateRequest(request);

                    await transaction.CommitAsync();
                    return "Delete Request Success";
                }
            }
        }
        #endregion

        public async Task<double> TotalPriceRequest(double packagePrice, double accountCouponPrice, string startDate, string endDate, List<RequestTotalPrice> requestTotalPrices, string serviceId)
        {
            try
            {
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;

                if (!string.IsNullOrEmpty(startDate) || !string.IsNullOrEmpty(endDate))
                {
                    string[] dateFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                    bool isValidDate = DateTime.TryParseExact(startDate, dateFormats,
                                                              System.Globalization.CultureInfo.InvariantCulture,
                                                              System.Globalization.DateTimeStyles.None,
                                                              out StartDate);

                    bool isValidEndDate = DateTime.TryParseExact(endDate, dateFormats,
                                                                 System.Globalization.CultureInfo.InvariantCulture,
                                                                 System.Globalization.DateTimeStyles.None,
                                                                 out EndDate);

                    if (!isValidDate || !isValidEndDate)
                    {
                        throw new Exception("Date format is incorrect. Please enter the right format DateTime.");
                    }
                    if (StartDate < DateTime.Now)
                    {
                        throw new Exception("Start date cannot be in the past.");
                    }
                    if (EndDate < DateTime.Now)
                    {
                        throw new Exception("End date cannot be in the past.");
                    }
                    if (StartDate > EndDate)
                    {
                        throw new Exception("End date must be greater than event date.");
                    }
                }

                double totalDay = (EndDate - StartDate).TotalDays;
                double totalPrice = 0;
                double total = 0;

                foreach (var request in requestTotalPrices)
                {
                    //totalPrice += request.CharacterPrice * (request.SalaryIndex != 0 ? request.SalaryIndex : 1);
                    Character character = await _characterRepository.GetCharacter(request.CharacterId);
                    if (character == null)
                    {
                        throw new Exception("Character does not exist");
                    }
                    if (request.Quantity <= 0)
                    {
                        throw new Exception("Quantity must greater than 0");
                    }

                    if (request.Quantity > character.Quantity)
                    {
                        throw new Exception("Quantity character does not enough");
                    }

                    if (request.CosplayerId == null)
                    {
                        totalPrice = (int)request.Quantity * (double)character.Price * 5;
                    }

                    if (request.CosplayerId != null)
                    {

                        totalPrice = (int)request.Quantity * (double)character.Price;

                        Account cosplayer = await _accountRepository.GetAccount(request.CosplayerId);

                        if (cosplayer == null)
                        {
                            throw new Exception("Cosplayer does not exist");
                        }

                        if (cosplayer.Role.RoleName != RoleName.Cosplayer)
                        {
                            throw new Exception("AccountId must be cosplayer");
                        }

                        bool checkCharacter = await _characterRepository.CheckCharacterForAccount(cosplayer, character.CharacterId);

                        if (!checkCharacter)
                        {
                            throw new Exception("Cosplayer does not suitable for character");
                        }

                        totalPrice += (double)cosplayer.SalaryIndex * totalDay;
                    }

                    total += totalPrice;

                }

                Service service = await _serviceRepository.GetService(serviceId);
                if (service == null)
                {
                    throw new Exception("Service does not exist");
                }

                double amount = 0;

                if (service.ServiceId.Equals("S001"))
                {
                    amount = total - accountCouponPrice;
                }
                else
                {
                    amount = total + packagePrice - accountCouponPrice;
                }
                return amount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckRequest(string requestId)
        {
            try
            {
                Request request = await _repository.GetRequestById(requestId);
                if (request == null)
                {
                    throw new Exception("Request does not exist");
                }

                List<Account> checkAccount = new List<Account>();
                List<Account> checkAccountForCharacter = new List<Account>();
                List<Account> checkAccountForCharacter1 = new List<Account>();
                int count = 0;

                foreach (var requestCharacter in request.RequestCharacters)
                {
                    count += (int)requestCharacter.Quantity;
                    Character character = await _characterRepository.GetCharacter(requestCharacter.CharacterId);
                    if (character == null)
                    {
                        throw new Exception("Character does not exist");
                    }
                    List<Account> accounts = await _accountRepository.GetAccountsByCharacter(character, checkAccountForCharacter1);
                    foreach (var account in accounts)
                    {
                        bool checkTask = await taskRepository.CheckTaskIsValid(account, request.StartDate, request.EndDate);
                        if (checkTask)
                        {
                            checkAccountForCharacter.Add(account);
                            checkAccountForCharacter1.Add(account);
                            if (checkAccountForCharacter.Count == requestCharacter.Quantity)
                            {
                                foreach (var account1 in checkAccountForCharacter)
                                {
                                    checkAccount.Add(account1);
                                }
                                checkAccountForCharacter = new List<Account>();
                                break;
                            }
                        }
                    }
                }

                if (checkAccount.Count == count)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
