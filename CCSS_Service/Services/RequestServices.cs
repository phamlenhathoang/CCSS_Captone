using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        Task<string> DeleteRequest(string id, string? reason);
        Task<string> AddRequestRentCostume(RequestDtos requestDtos);
        Task<string> AddRequestRentCosplayer(RequestRentCosplayer requestDtos);
        Task<string> AddRequestCreateEvent(RequestCreateEvent requestDtos);
        Task<string> UpdateRequest(string requestId, UpdateRequestDtos requestDtos);
        Task<string> UpdateStatusRequest(string requestId, RequestStatus requestStatus, string? reason);
        Task<double> TotalPriceRequest(double packagePrice, double accountCouponPrice, string startDate, string endDate, List<RequestTotalPrice> requestTotalPrices, string serviceId);
        Task<bool> CheckRequest(string requestId);
        Task<string> UpdateDepositRequest(string requestId, UpdateDepositDtos depositDtos);
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
        private readonly IRequestDatesRepository _requestDatesRepository;
        private readonly INotificationService _notificationService;


        public RequestServices(ITaskRepository taskRepository, IRequestRepository repository, IRequestCharacterRepository requestCharacterRepository, IAccountRepository accountRepository, ICharacterRepository characterRepository, IServiceRepository serviceRepository, IAccountCouponRepository accountCouponRepository, IBeginTransactionRepository beginTransactionRepository, IContractRespository contractRepository, IRequestDatesRepository requestDatesRepository, INotificationService notificationService)
        {
            _repository = repository;
            _requestDatesRepository = requestDatesRepository;
            _characterRepository = characterRepository;
            _requestCharacterRepository = requestCharacterRepository;
            _accountRepository = accountRepository;
            this.taskRepository = taskRepository;
            _serviceRepository = serviceRepository;
            _accountCouponRepository = accountCouponRepository;
            _beginTransactionRepository = beginTransactionRepository;
            _contractRepository = contractRepository;
            _notificationService = notificationService;
        }
        #region GetAll Request
        public async Task<List<RequestResponse>> GetAllRequest()
        {
            List<RequestResponse> listRequest = new List<RequestResponse>();
            var request = await _repository.GetAllRequest();
            foreach (var item in request)
            {
                int totalDate = (item.EndDate.Date - item.StartDate.Date).Days + 1;
                var listRequestCharacter = await _requestCharacterRepository.GetAllRequestCharacter();

                List<CharacterRequestResponse> characterResponses = listRequestCharacter.Where(sc => sc.RequestId.Equals(item.RequestId)).Select(c => new CharacterRequestResponse()
                {
                    RequestCharacterId = c.RequestCharacterId,
                    CharacterId = c.CharacterId,
                    CharacterName = c.Character.CharacterName,
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
                    RequestDateResponses = c.RequestDates.OrderBy(s => s.StartDate).Select(rd =>
                    {
                        TimeSpan hourDuration = rd.EndDate - rd.StartDate;
                        decimal totalhours = (decimal)hourDuration.TotalHours;
                        return new RequestDateResponse
                        {
                            RequestDateId = rd.RequestDateId,
                            RequestCharacterId = rd.RequestCharacterId,
                            StartDate = rd.StartDate.ToString("HH:mm dd/MM/yyyy"),
                            EndDate = rd.EndDate.ToString("HH:mm dd/MM/yyyy"),
                            Status = rd.Status,
                            Reason = rd.Reason,
                            TotalHour = totalhours,
                        };
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
                    StartDate = item.StartDate.ToString("HH:mm dd/MM/yyyy"),
                    EndDate = item.EndDate.ToString("HH:mm dd/MM/yyyy"),
                    CreatedDate = item.CreatedDate?.ToString("HH:mm dd/MM/yyyy"),
                    UpdateDate = item.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                    Location = item.Location,
                    ServiceId = item.ServiceId,
                    PackageId = item.PackageId,
                    Deposit = item.Deposit,
                    Range = item.Range,
                    Reason = item.Reason,
                    TotalDate = totalDate,
                    IsValidate = item.IsValidate,
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
            int totalDate = (request.EndDate.Date - request.StartDate.Date).Days + 1;
            var listRequestCharacter = await _requestCharacterRepository.GetAllRequestCharacter();

            List<CharacterRequestResponse> characterResponses = listRequestCharacter.Where(sc => sc.RequestId.Equals(request.RequestId)).Select(c => new CharacterRequestResponse()
            {
                RequestCharacterId = c.RequestCharacterId,
                CharacterId = c.CharacterId,
                CharacterName = c.Character.CharacterName,
                CosplayerId = c.CosplayerId,
                Description = c.Description,
                Quantity = c.Quantity,
                MinHeight = c.Character.MinHeight,
                MaxHeight = c.Character.MaxHeight,
                MinWeight = c.Character.MinWeight,
                MaxWeight = c.Character.MaxWeight,
                Status = c.Status.ToString(),
                CharacterImages = c.Character.CharacterImages
                                      .Select(img => new CharacterImageDto
                                      {
                                          CharacterImageId = img.CharacterImageId,
                                          UrlImage = img.UrlImage
                                      }).ToList(),
                RequestDateResponses = c.RequestDates.OrderBy(s => s.StartDate).Select(rd =>
                {
                    TimeSpan hourDuration = rd.EndDate - rd.StartDate;
                    decimal totalhours = (decimal)hourDuration.TotalHours;
                    return new RequestDateResponse
                    {
                        RequestDateId = rd.RequestDateId,
                        RequestCharacterId = rd.RequestCharacterId,
                        StartDate = rd.StartDate.ToString("HH:mm dd/MM/yyyy"),
                        EndDate = rd.EndDate.ToString("HH:mm dd/MM/yyyy"),
                        Status = rd.Status,
                        Reason = rd.Reason,
                        TotalHour = totalhours,
                    };
                }).ToList(),
            }).ToList();

            var response = new RequestResponse()
            {
                RequestId = request.RequestId,
                AccountId = request.AccountId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Status = request.Status.ToString(),
                StartDate = request.StartDate.ToString("HH:mm dd/MM/yyyy"),
                EndDate = request.EndDate.ToString("HH:mm dd/MM/yyyy"),
                CreatedDate = request.CreatedDate?.ToString("HH:mm dd/MM/yyyy"),
                UpdateDate = request.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                Location = request.Location,
                ServiceId = request.ServiceId,
                PackageId = request.PackageId,
                Deposit = request.Deposit,
                Range = request.Range,
                Reason = request.Reason,
                TotalDate = totalDate,
                IsValidate = request.IsValidate,

                CharactersListResponse = characterResponses
            };
            return response;
        }
        #endregion

        #region Get All Request By AccountId
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
                int totalDate = (item.EndDate.Date - item.StartDate.Date).Days + 1;
                var listRequestCharacter = await _requestCharacterRepository.GetAllRequestCharacter();

                List<CharacterRequestResponse> characterResponses = listRequestCharacter.Where(sc => sc.RequestId.Equals(item.RequestId)).Select(c => new CharacterRequestResponse()
                {
                    RequestCharacterId = c.RequestCharacterId,
                    CharacterId = c.CharacterId,
                    CharacterName = c.Character.CharacterName,
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
                    RequestDateResponses = c.RequestDates.OrderBy(s => s.StartDate).Select(rd =>
                    {
                        TimeSpan hourDuration = rd.EndDate - rd.StartDate;
                        decimal totalhours = (decimal)hourDuration.TotalHours;
                        return new RequestDateResponse
                        {
                            RequestDateId = rd.RequestDateId,
                            RequestCharacterId = rd.RequestCharacterId,
                            StartDate = rd.StartDate.ToString("HH:mm dd/MM/yyyy"),
                            EndDate = rd.EndDate.ToString("HH:mm dd/MM/yyyy"),
                            Status = rd.Status,
                            Reason = rd.Reason,
                            TotalHour = totalhours,
                        };
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
                    StartDate = item.StartDate.ToString("HH:mm dd/MM/yyyy"),
                    EndDate = item.EndDate.ToString("HH:mm dd/MM/yyyy"),
                    CreatedDate = item.CreatedDate?.ToString("HH:mm dd/MM/yyyy"),
                    UpdateDate = item.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                    Location = item.Location,
                    ServiceId = item.ServiceId,
                    PackageId = item.PackageId,
                    Deposit = item.Deposit,
                    Range = item.Range,
                    TotalDate = totalDate,
                    Reason = item.Reason,
                    IsValidate = item.IsValidate,
                    CharactersListResponse = characterResponses
                };
                listRequest.Add(response); ;
            }
            return listRequest;
        }
        #endregion

        #region Add Request CreateEvent
        public async Task<string> AddRequestCreateEvent(RequestCreateEvent requestDtos)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                DateTime StartDate = DateTime.UtcNow.AddHours(7);
                DateTime EndDate = DateTime.UtcNow.AddHours(7);

                if (!string.IsNullOrEmpty(requestDtos.StartDate) || !string.IsNullOrEmpty(requestDtos.EndDate))
                {
                    string[] dateFormats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };

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
                        return "Date format is incorrect. Please enter the right format DateTime.";
                    }
                    if (StartDate < DateTime.UtcNow.AddHours(7))
                    {
                        return "Start date cannot be in the past.";
                    }
                    if (EndDate - StartDate > TimeSpan.FromDays(5))
                    {
                        return "The gap between StartDate and EndDate max 5 days.Please try again";
                    }
                    if (EndDate < DateTime.UtcNow.AddHours(7))
                    {
                        return "End date cannot be in the past.";
                    }
                    if (StartDate > EndDate)
                    {
                        return "End date must be greater than event date.";
                    }
                    if ((StartDate - DateTime.UtcNow.AddHours(7)).TotalDays < 3)
                    {
                        return "Start Date must be 3 days from today";
                    }
                }
                if (requestDtos == null)
                {
                    return "Need entry the field";
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
                var newRequest = new Request()
                {
                    RequestId = Guid.NewGuid().ToString(),
                    AccountId = requestDtos.AccountId,
                    ServiceId = "S003",
                    Name = requestDtos.Name,
                    Price = requestDtos.Price,
                    Description = requestDtos.Description,
                    Status = RequestStatus.Pending,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Location = requestDtos.Location,
                    Deposit = requestDtos.Deposit,
                    Range = requestDtos.Range,
                    PackageId = requestDtos.PackageId,
                };
                var result = await _repository.AddRequest(newRequest);
                if (!result)
                {
                    await transaction.RollbackAsync();
                    return "Add Request Failed";
                }
                else
                {
                    if (requestDtos.ListRequestCharactersCreateEvent != null && requestDtos.ListRequestCharactersCreateEvent.Any())
                    {
                        List<RequestCharacter> characteInRequest = new List<RequestCharacter>();

                        foreach (var r in requestDtos.ListRequestCharactersCreateEvent)
                        {
                            var character = await _characterRepository.GetCharacter(r.CharacterId);
                            if (character == null)
                            {
                                return "Please enter your character";
                            }
                            if (r.Quantity > character.Quantity || r.Quantity < 0)
                            {
                                return $"The quantity of {character.CharacterId} is out of stock. Please try again";
                            }
                            else
                            {
                                double totalDate = (EndDate.Date - StartDate.Date).Days + 1;
                                
                                var totalPrice = character.Price * r.Quantity * totalDate;
                                // Nếu CosplayerId hợp lệ, thêm vào danh sách
                                characteInRequest.Add(new RequestCharacter
                                {
                                    RequestCharacterId = Guid.NewGuid().ToString(),
                                    RequestId = newRequest.RequestId,
                                    Description = r.Description,
                                    CharacterId = r.CharacterId,
                                    CreateDate = DateTime.UtcNow.AddHours(7),
                                    Status = RequestCharacterStatus.Accept,
                                    Quantity = r.Quantity,
                                    TotalPrice = totalPrice,
                                });

                                character.Quantity -= r.Quantity;
                                var resultCharacter = await _characterRepository.UpdateCharacter(character);
                                if (!resultCharacter)
                                {
                                    await transaction.RollbackAsync();
                                    return "Can not update character quantity";
                                }
                            }
                        }
                        var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                        if (!requestCharacterAdd)
                        {
                            await transaction.RollbackAsync();
                            return "Failed to add characters in Request";
                        }
                        else
                        {
                            if (requestDtos.ListRequestCharactersCreateEvent.Any(c => c.ListRequestDates != null && c.ListRequestDates.Any()))
                            {
                                List<RequestDate> requestDates = new List<RequestDate>();
                                foreach (var d in requestDtos.ListRequestCharactersCreateEvent)
                                {
                                    var requestCharacter = await _requestCharacterRepository.GetRequestCharacter(newRequest.RequestId, d.CharacterId);
                                    if (requestCharacter != null)
                                    {

                                        foreach (var dateDtos in d.ListRequestDates)
                                        {
                                            DateTime StartTime = DateTime.UtcNow.AddHours(7);
                                            DateTime EndTime = DateTime.UtcNow.AddHours(7);

                                            if (!string.IsNullOrEmpty(dateDtos.StartDate) || !string.IsNullOrEmpty(dateDtos.EndDate))
                                            {

                                                string[] timeFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                                                bool isValidStartTime = DateTime.TryParseExact(dateDtos.StartDate.Trim(), timeFormats,
                                                                                          System.Globalization.CultureInfo.InvariantCulture,
                                                                                          System.Globalization.DateTimeStyles.None, out StartTime);

                                                bool isValidEndTime = DateTime.TryParseExact(dateDtos.EndDate.Trim(), timeFormats,
                                                                                             System.Globalization.CultureInfo.InvariantCulture,
                                                                                             System.Globalization.DateTimeStyles.None, out EndTime);
                                                if (!isValidStartTime && !isValidEndTime)
                                                {
                                                    return "Valid Time is wrong";
                                                }
                                            }
                                            if (StartTime >= EndTime)
                                            {
                                                await transaction.RollbackAsync();
                                                return "End date must be greater than start date.";
                                            }

                                            // Kiểm tra thời gian nằm trong khoảng thời gian của Request
                                            if (StartTime < StartDate && EndTime > EndDate)
                                            {
                                                await transaction.RollbackAsync();
                                                return "Date range must be within the request date range.";
                                            }
                                            requestDates.Add(new RequestDate
                                            {
                                                RequestDateId = Guid.NewGuid().ToString(),
                                                RequestCharacterId = requestCharacter.RequestCharacterId,
                                                Status = RequestDateStatus.Pending,
                                                StartDate = StartTime,
                                                EndDate = EndTime
                                            });
                                        }
                                    }
                                }

                                if (requestDates.Any())
                                {
                                    var RequestDates = await _requestDatesRepository.AddListRequestDates(requestDates);
                                    if (!RequestDates)
                                    {
                                        await transaction.RollbackAsync();
                                        return "Failed to add request dates";
                                    }
                                }
                            }
                        }
                    }

                    var accounts = await _accountRepository.GetAllAccount(null, "R002");
                    foreach (var account in accounts)
                    {
                        SendMail sendMail = new SendMail();
                        var resultSendMail = await sendMail.SendEmailRequestForManager(account.Email);
                        if (!resultSendMail)
                        {
                            await transaction.RollbackAsync();
                            return "Can not Send Mail to manager";
                        }
                        else
                        {
                            var services = await _serviceRepository.GetService(newRequest.ServiceId);
                            string message = $"There are some request from {services.ServiceName} was assigned, you need to review.";
                            await _notificationService.SendNotification(account.AccountId, message);
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
                DateTime StartDate = DateTime.UtcNow.AddHours(7);
                DateTime EndDate = DateTime.UtcNow.AddHours(7);

                if (!string.IsNullOrEmpty(UpdateRequestDtos.StartDate) || !string.IsNullOrEmpty(UpdateRequestDtos.EndDate))
                {
                    string[] dateFormats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };

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
                    if (StartDate < DateTime.UtcNow.AddHours(7))
                    {
                        return ("Start date cannot be in the past.");
                    }
                    if (EndDate < DateTime.UtcNow.AddHours(7))
                    {
                        return ("End date cannot be in the past.");
                    }
                    if (StartDate > EndDate)
                    {
                        return ("End date must be greater than event date.");
                    }
                    if ((StartDate - DateTime.UtcNow.AddHours(7)).TotalDays < 3)
                    {
                        return "Start Date must be 3 days from today";
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
                        //bool checkTask = await taskRepository.CheckTaskIsValid(account, StartDate, EndDate);
                        //if (!checkTask)
                        //{
                        //    await transaction.RollbackAsync();
                        //    return "This cosplayer is has another job. Please change datetime.";
                        //}
                        var cosplayer = await _accountRepository.GetAccount(r.CosplayerId);
                        if (cosplayer.RoleId != "R004" || cosplayer == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                        {
                            await transaction.RollbackAsync();
                            return "This cosplayer not found";
                        }
                    }
                    var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(r.RequestCharacterId);
                    var character = await _characterRepository.GetCharacter(requestCharacter.CharacterId);
                    if (requestCharacter == null)
                    {
                        await transaction.RollbackAsync();
                        return $"Can not find character {character.CharacterName} in Request";
                    }
                    else
                    {
                        int quantity = (requestExisting.ServiceId == "S002") ? 1 : (r.Quantity ?? 1);
                        if (quantity > character.Quantity)
                        {
                            await transaction.RollbackAsync();
                            return $"Not enough stock for character {character.CharacterName}.";
                        }
                        if(requestCharacter.CharacterId != r.CharacterId)
                        {
                            var oldCharacter = await _characterRepository.GetCharacter(requestCharacter.CharacterId);
                            if (oldCharacter != null)
                            {
                                oldCharacter.Quantity += requestCharacter.Quantity;
                                await _characterRepository.UpdateCharacter(oldCharacter);
                            }
                            var newcharacter = await _characterRepository.GetCharacter(r.CharacterId);
                            newcharacter.Quantity -= quantity;
                            await _characterRepository.UpdateCharacter(newcharacter);

                        }
                        else
                        {
                            character.Quantity = character.Quantity + requestCharacter.Quantity - quantity;
                            await _characterRepository.UpdateCharacter(character);
                        }
                       

                        requestCharacter.CreateDate = StartDate;
                        requestCharacter.UpdateDate = DateTime.UtcNow.AddHours(7);
                        requestCharacter.CharacterId = r.CharacterId;
                        requestCharacter.CosplayerId = r.CosplayerId;
                        requestCharacter.Description = r.Description;
                        requestCharacter.Quantity = quantity;
                        requestCharacter.TotalPrice = character.Price * r.Quantity;
                        requestCharacter.Status = RequestCharacterStatus.Accept;

                        characterInRequest.Add(requestCharacter);

                        
                    }
                }
                if (characterInRequest.Any())
                {
                    var existResult = await _requestCharacterRepository.UpdateListRequestCharacter(characterInRequest);
                    if (!existResult)
                    {
                        await transaction.RollbackAsync();
                        return $"Cannot update the character in request";
                    }
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
                requestExisting.PackageId = requestExisting.ServiceId == "S003" ? UpdateRequestDtos.PackageId : null;
                requestExisting.Range = requestExisting.ServiceId == "S003" ? UpdateRequestDtos.Range : null;
                requestExisting.Price = UpdateRequestDtos.Price;
                requestExisting.UpdateDate = DateTime.UtcNow.AddHours(7);


                await _repository.UpdateRequest(requestExisting);

                await transaction.CommitAsync();
                return "Update request Success";
            }

        }
        #endregion

        #region Update Request Status
        public async Task<string> UpdateStatusRequest(string requestId, RequestStatus requestStatus, string? reason)
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

                if (request.IsValidate == true)
                {
                    DateTime check = DateTime.UtcNow.AddDays(1).AddHours(7);
                    if (request.CreatedDate > check)
                    {
                        return "The task cannot be updated at this time as the appropriate time has not yet arrived.";
                    }
                }

                if (requestStatus == RequestStatus.Cancel)
                {
                    request.Reason = reason;
                    
                    foreach (var requestcharacter in listRequestCharacters)
                    {
                        requestcharacter.Status = RequestCharacterStatus.Cancel;
                        var character = await _characterRepository.GetCharacter(requestcharacter.CharacterId);
                        if (character == null)
                        {
                            await transaction.RollbackAsync();
                            return "Can not find character";
                        }
                        character.Quantity += requestcharacter.Quantity;
                        await _characterRepository.UpdateCharacter(character);
                    }
                   var result = await _requestCharacterRepository.UpdateListRequestCharacter(listRequestCharacters);
                    if (!result)
                    {
                        await transaction.RollbackAsync();
                        return "Update requestCharacter fail";
                    }
                }

                request.Status = requestStatus;
                await _repository.UpdateRequest(request);

                await transaction.CommitAsync();

                string messaage = $"Your request was change to {request.Status}";
                await _notificationService.SendNotification(request.AccountId, messaage);

                return "Status request update success";

            }
        }
        #endregion

        #region Delete Request
        public async Task<string> DeleteRequest(string id, string? reason)
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
                    request.Reason = reason;
                    await _repository.UpdateRequest(request);

                    var listrequestCharacter = await _requestCharacterRepository.GetListRequestCharacterPending(id);
                    foreach (var requestcharacter in listrequestCharacter)
                    {
                        var character = await _characterRepository.GetCharacter(requestcharacter.CharacterId);

                        character.Quantity += requestcharacter.Quantity;
                        await _characterRepository.UpdateCharacter(character);
                    }

                    await transaction.CommitAsync();
                    return "Delete Request Success";
                }
            }
        }
        #endregion

        #region Total Price Request
        public async Task<double> TotalPriceRequest(double packagePrice, double accountCouponPrice, string startDate, string endDate, List<RequestTotalPrice> requestTotalPrices, string serviceId)
        {
            try
            {
                DateTime StartDate = DateTime.UtcNow.AddHours(7);
                DateTime EndDate = DateTime.UtcNow.AddHours(7);

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
                    if (StartDate < DateTime.UtcNow.AddHours(7))
                    {
                        throw new Exception("Start date cannot be in the past.");
                    }
                    if (EndDate < DateTime.UtcNow.AddHours(7))
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
        #endregion

        #region CheckRequest
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
                        //bool checkTask = await taskRepository.CheckTaskIsValid(account, request.StartDate, request.EndDate);
                        //if (checkTask)
                        //{
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
                        //}
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
        #endregion

        #region Add Request Rent Cosplayer
        public async Task<string> AddRequestRentCosplayer(RequestRentCosplayer requestDtos)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                DateTime StartDate = DateTime.UtcNow.AddHours(7);
                DateTime EndDate = DateTime.UtcNow.AddHours(7);

                if (!string.IsNullOrEmpty(requestDtos.StartDate) || !string.IsNullOrEmpty(requestDtos.EndDate))
                {
                    string[] dateFormats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };

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
                        return "Date format is incorrect. Please enter the right format DateTime.";
                    }
                    if (StartDate < DateTime.UtcNow.AddHours(7))
                    {
                        return "Start date cannot be in the past.";
                    }
                    if (EndDate - StartDate > TimeSpan.FromDays(5))
                    {
                        return "The gap between StartDate and EndDate max 5 days.Please try again";
                    }
                    if (EndDate < DateTime.UtcNow.AddHours(7))
                    {
                        return "End date cannot be in the past.";
                    }
                    if (StartDate > EndDate)
                    {
                        return "End date must be greater than event date.";
                    }
                    if ((StartDate - DateTime.UtcNow.AddHours(7)).TotalDays < 3)
                    {
                        return "Start Date must be 3 days from today";
                    }
                }
                if (requestDtos == null)
                {
                    return "Need entry the field";
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
                var newRequest = new Request()
                {
                    RequestId = Guid.NewGuid().ToString(),
                    AccountId = requestDtos.AccountId,
                    ServiceId = "S002",
                    Name = requestDtos.Name,
                    Price = requestDtos.Price,
                    Description = requestDtos.Description,
                    Status = RequestStatus.Pending,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Location = requestDtos.Location,
                    Deposit = requestDtos.Deposit,
                };
                var result = await _repository.AddRequest(newRequest);
                if (!result)
                {
                    await transaction.RollbackAsync();
                    return "Add Request Failed";
                }
                else
                {
                    if (requestDtos.CharactersRentCosplayers != null && requestDtos.CharactersRentCosplayers.Any())
                    {
                        List<RequestCharacter> characteInRequest = new List<RequestCharacter>();

                        foreach (var r in requestDtos.CharactersRentCosplayers)
                        {
                            if (r.CosplayerId == null)
                            {
                                return "please choose cosplayer";
                            }
                            else
                            {
                                if (characteInRequest.Any(c => c.CosplayerId == r.CosplayerId && c.CharacterId == r.CharacterId))
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
                                //bool checkTask = await taskRepository.CheckTaskIsValid(account, StartDate, EndDate);
                                //if (!checkTask)
                                //{
                                //    await transaction.RollbackAsync();
                                //    return "This cosplayer is has another job. Please change datetime.";
                                //}
                                if (account.RoleId != "R004" || account == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                                {
                                    await transaction.RollbackAsync();
                                    return "This cosplayer not found";
                                }
                            }
                            var Getcharacter = await _characterRepository.GetCharacter(r.CharacterId);
                            double totalDate = (EndDate.Date - StartDate.Date).Days + 1;
                            var totalPrice = Getcharacter.Price * 1 * totalDate;
                            // Nếu CosplayerId hợp lệ, thêm vào danh sách
                            characteInRequest.Add(new RequestCharacter
                            {
                                RequestCharacterId = Guid.NewGuid().ToString(),
                                RequestId = newRequest.RequestId,
                                Description = r.Description,
                                CharacterId = r.CharacterId,
                                CreateDate = DateTime.UtcNow.AddHours(7),
                                Status = RequestCharacterStatus.Accept,
                                Quantity = 1,
                                CosplayerId = r.CosplayerId,
                                TotalPrice = totalPrice,
                            });

                            Getcharacter.Quantity -= 1;
                            var resultCharacter = await _characterRepository.UpdateCharacter(Getcharacter);
                            if (!resultCharacter)
                            {
                                await transaction.RollbackAsync();
                                return "Can not update character quantity";
                            }
                        }
                        var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                        if (!requestCharacterAdd)
                        {
                            await transaction.RollbackAsync();
                            return "Failed to add characters in Request";
                        }
                        else
                        {
                            if (requestDtos.CharactersRentCosplayers.Any(c => c.ListRequestDates != null && c.ListRequestDates.Any()))
                            {
                                double? totalHour = 0;
                                foreach (var d in requestDtos.CharactersRentCosplayers)
                                {
                                    var requestCharacter = await _requestCharacterRepository.GetRequestCharacterCosplayerId(newRequest.RequestId, d.CharacterId, d.CosplayerId);
                                    if (requestCharacter != null)
                                    {
                                        List<RequestDate> requestDates = new List<RequestDate>();

                                        foreach (var dateDtos in d.ListRequestDates)
                                        {
                                            DateTime StartTime = DateTime.UtcNow.AddHours(7);
                                            DateTime EndTime = DateTime.UtcNow.AddHours(7);

                                            if (!string.IsNullOrEmpty(dateDtos.StartDate) || !string.IsNullOrEmpty(dateDtos.EndDate))
                                            {

                                                string[] timeFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                                                bool isValidStartTime = DateTime.TryParseExact(dateDtos.StartDate.Trim(), timeFormats,
                                                                                          System.Globalization.CultureInfo.InvariantCulture,
                                                                                          System.Globalization.DateTimeStyles.None, out StartTime);

                                                bool isValidEndTime = DateTime.TryParseExact(dateDtos.EndDate.Trim(), timeFormats,
                                                                                             System.Globalization.CultureInfo.InvariantCulture,
                                                                                             System.Globalization.DateTimeStyles.None, out EndTime);
                                                if (!isValidStartTime && !isValidEndTime)
                                                {
                                                    return "Valid Time is wrong";
                                                }
                                            }
                                            if (StartTime >= EndTime)
                                            {
                                                await transaction.RollbackAsync();
                                                return "End date must be greater than start date.";
                                            }

                                            // Kiểm tra thời gian nằm trong khoảng thời gian của Request
                                            if (StartTime < StartDate && EndTime > EndDate)
                                            {
                                                await transaction.RollbackAsync();
                                                return "Date range must be within the request date range.";
                                            }
                                            requestDates.Add(new RequestDate
                                            {
                                                RequestDateId = Guid.NewGuid().ToString(),
                                                RequestCharacterId = requestCharacter.RequestCharacterId,
                                                Status = RequestDateStatus.Pending,
                                                StartDate = StartTime,
                                                EndDate = EndTime
                                            });

                                            totalHour += (EndTime - StartTime).TotalHours;
                                        }

                                        if (requestDates.Any())
                                        {
                                            var RequestDates = await _requestDatesRepository.AddListRequestDates(requestDates);

                                            if (!RequestDates)
                                            {
                                                await transaction.RollbackAsync();
                                                return "Failed to add request dates";
                                            }
                                        }
                                        var cosplayer = await _accountRepository.GetAccount(d.CosplayerId);
                                        if (cosplayer == null)
                                        {
                                            await transaction.RollbackAsync();
                                            return "Cosplayer is null here";
                                        }

                                        SendMail sendMail = new SendMail();
                                        var accountCosplayer = await _accountRepository.GetAccount(d.CosplayerId);
                                        var resultSendMail = await sendMail.SendEmailRequestForCosplayer(accountCosplayer.Email);
                                        if (!resultSendMail)
                                        {
                                            await transaction.RollbackAsync();
                                            return "Can not Send Mail to Cosplayer";
                                        }
                                        else
                                        {
                                            var services = await _serviceRepository.GetService(newRequest.ServiceId);
                                            string message = $"There are some request from {services.ServiceName}  was assigned, you need to review.";
                                            await _notificationService.SendNotification(accountCosplayer.AccountId, message);
                                        }

                                        requestCharacter.TotalPrice += (totalHour * cosplayer.SalaryIndex);
                                        var resultTotalPrice = await _requestCharacterRepository.UpdateRequestCharacter(requestCharacter);
                                        if (!resultTotalPrice)
                                        {
                                            await transaction.RollbackAsync();
                                            return "Can not update total price";
                                        }
                                    }
                                }
                            }
                        }
                    }

                    var accounts = await _accountRepository.GetAllAccount(null, "R002");

                    foreach (var account in accounts)
                    {
                        SendMail sendMail = new SendMail();
                        var resultSendMail = await sendMail.SendEmailRequestForManager(account.Email);
                        if (!resultSendMail)
                        {
                            await transaction.RollbackAsync();
                            return "Can not Send Mail to manager";
                        }
                        else
                        {
                            var services = await _serviceRepository.GetService(newRequest.ServiceId);
                            string message = $"There are some request from {services.ServiceName} was assigned, you need to review.";
                            await _notificationService.SendNotification(account.AccountId, message);
                        }
                    }

                    await transaction.CommitAsync();
                    return "Add Request Success";
                }
            }
        }
        #endregion

        #region Add Request Rent Costume
        public async Task<string> AddRequestRentCostume(RequestDtos requestDtos)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                DateTime StartDate = DateTime.UtcNow.AddHours(7);
                DateTime EndDate = DateTime.UtcNow.AddHours(7);

                if (!string.IsNullOrEmpty(requestDtos.StartDate) || !string.IsNullOrEmpty(requestDtos.EndDate))
                {
                    string[] dateFormats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };

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
                        return "Date format is incorrect. Please enter the right format DateTime.";
                    }
                    if (StartDate < DateTime.UtcNow.AddHours(7))
                    {
                        return "Start date cannot be in the past.";
                    }
                    if (EndDate - StartDate > TimeSpan.FromDays(5))
                    {
                        return "The gap between StartDate and EndDate max 5 days.Please try again";
                    }
                    if (EndDate < DateTime.UtcNow.AddHours(7))
                    {
                        return "End date cannot be in the past.";
                    }
                    if (StartDate > EndDate)
                    {
                        return "End date must be greater than event date.";
                    }
                    if ((StartDate - DateTime.UtcNow.AddHours(7)).TotalDays < 3)
                    {
                        return "Start Date must be 3 days from today";
                    }
                }
                if (requestDtos == null)
                {
                    return "Need entry the field";
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
                var newRequest = new Request()
                {
                    RequestId = Guid.NewGuid().ToString(),
                    AccountId = requestDtos.AccountId,
                    ServiceId = "S001",
                    Name = requestDtos.Name,
                    Price = requestDtos.Price,
                    Description = requestDtos.Description,
                    Status = RequestStatus.Pending,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Location = requestDtos.Location,
                    Deposit = requestDtos.Deposit,
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
                            var character = await _characterRepository.GetCharacter(r.CharacterId);
                            if (character == null)
                            {
                                return "Please enter your character";
                            }
                            if (r.Quantity > character.Quantity || r.Quantity < 0)
                            {
                                return "The quantity is out of stock. Please try again";
                            }
                            else
                            {
                                double totalDate = (EndDate.Date - StartDate.Date).Days + 1;                             
                                var totalPrice = character.Price * r.Quantity * (totalDate);
                                // Nếu CosplayerId hợp lệ, thêm vào danh sách
                                characteInRequest.Add(new RequestCharacter
                                {
                                    RequestCharacterId = Guid.NewGuid().ToString(),
                                    RequestId = newRequest.RequestId,
                                    Description = r.Description,
                                    CharacterId = r.CharacterId,
                                    CreateDate = DateTime.UtcNow.AddHours(7),
                                    Status = RequestCharacterStatus.Accept,
                                    Quantity = r.Quantity,
                                    CosplayerId = null,
                                    TotalPrice = totalPrice,
                                });

                                character.Quantity -= r.Quantity;
                                var resultCharacter = await _characterRepository.UpdateCharacter(character);
                                if (!resultCharacter)
                                {
                                    await transaction.RollbackAsync();
                                    return "Can not update character quantity";
                                }
                            }
                        }
                        var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                        if (!requestCharacterAdd)
                        {
                            await transaction.RollbackAsync();
                            return "Failed to add characters in Request";
                        }
                    }

                    var accounts = await _accountRepository.GetAllAccount(null, "R002");
                    foreach (var account in accounts)
                    {
                        SendMail sendMail = new SendMail();
                        var resultSendMail = await sendMail.SendEmailRequestForManager(account.Email);
                        if (!resultSendMail)
                        {
                            await transaction.RollbackAsync();
                            return "Can not Send Mail to manager";
                        }
                        else
                        {
                            var services = await _serviceRepository.GetService(newRequest.ServiceId);
                            string message = $"There are some request from {services.ServiceName} was assigned, you need to review.";
                            await _notificationService.SendNotification(account.AccountId, message);
                        }
                    }

                    await transaction.CommitAsync();
                    return "Add Request Success";
                }
            }
        }
        #endregion

        #region Update Deposit Request
        public async Task<string> UpdateDepositRequest(string requestId, UpdateDepositDtos depositDtos)
        {
            var request = await _repository.GetRequestById(requestId);
            if (request == null)
            {
                return $"Request {requestId} not found";
            }
            request.Deposit = depositDtos.Deposit;
            await _repository.UpdateRequest(request);
            return "Update success";
        }
        #endregion
    }


}
