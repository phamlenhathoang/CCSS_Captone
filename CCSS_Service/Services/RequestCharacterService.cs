using CCSS_Repository.Entities;
using CCSS_Repository.Model;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IRequestCharacterService
    {
        Task<RequestCharacterResponse> GetCharacterInRequestById(string Id);
        Task<List<RequestCharacter>> GetAllCharacterInRequest();
        Task<string> AddCharacterInRequest(AddCharacterInRequest characterInRequest);
        Task<string> UpdateCharactetInRRequest(string requestCharacterId, CharacterInRequest characterInRequest);
        Task<string> DeleteCharacterInRequest(string requestCharacterId);
        Task<RequestCharacter> GetRequestCharacter(string requestId, string characterId);
        Task<List<RequestCharacterResponse>> GetRequestCharacterByCosplayer(string cosplayerId);
        Task<string> UpdateStatus(string requestcharacterId, RequestCharacterStatus status);
        Task<string> CheckRequestChracter(string requestId);
        Task<List<RequestCharacterDateResponse>> GetAllRequestCharacterByListDate(List<Date> dates);
    }

    public class RequestCharacterService : IRequestCharacterService
    {
        private readonly IRequestCharacterRepository _requestCharacterRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IRequestDatesRepository _requestDatesRepository;
        private readonly IRequestRepository _requestRepository;
        public readonly IBeginTransactionRepository _beginTransactionRepository;
        public readonly IAccountRepository _accountRepository;
        public readonly ITaskRepository _taskRepository;

        public RequestCharacterService(IRequestCharacterRepository requestCharacterRepository, ICharacterRepository characterRepository, IRequestDatesRepository requestDatesRepository, IRequestRepository requestRepository, IBeginTransactionRepository beginTransactionRepository, IAccountRepository accountRepository, ITaskRepository taskRepository)
        {
            _requestCharacterRepository = requestCharacterRepository;
            _characterRepository = characterRepository;
            _requestDatesRepository = requestDatesRepository;
            _requestRepository = requestRepository;
            _beginTransactionRepository = beginTransactionRepository;
            _accountRepository = accountRepository;
            _taskRepository = taskRepository;
        }

        #region GetAllCharacterInRequest
        public async Task<List<RequestCharacter>> GetAllCharacterInRequest()
        {
            return await _requestCharacterRepository.GetAllRequestCharacter();
        }

        #endregion

        #region Check Character In Request
        public async Task<string> CheckRequestChracter(string requestId)
        {
            var request = await _requestRepository.GetRequestById(requestId);
            if (request == null)
            {
                return "Request is not found";
            }
            var listRequestCharacter = await _requestCharacterRepository.GetListCharacterByRequest(requestId);
            if (listRequestCharacter == null)
            {
                return "This Request do not have requestCharacter";
            }
            foreach (var character in listRequestCharacter)
            {
                if (character.Status == RequestCharacterStatus.Busy)
                {
                    request.Status = RequestStatus.Pending;
                    await _requestRepository.UpdateRequest(request);

                    return "This request has a requestCharacter busy, need to wait customer change requestCharacter";
                }
                if (character.Status == RequestCharacterStatus.Pending)
                {
                    return "There are still people not accept. Please try again";
                }
            }
            return "This request can change status";

        }
        #endregion

        #region Get RequestCharacter By Id
        public async Task<RequestCharacterResponse> GetCharacterInRequestById(string Id)
        {
            var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(Id);
            var character = await _characterRepository.GetCharacter(requestCharacter.CharacterId);
            RequestCharacterResponse requestCharacterResponse = new RequestCharacterResponse()
            {
                RequestCharacterId = requestCharacter.RequestCharacterId,
                RequestId = requestCharacter.RequestId,
                CharacterId = requestCharacter.CharacterId,
                CharacterName = character.CharacterName,
                MaxHeight = character.MaxHeight,
                MinHeight = character.MinHeight,
                MaxWeight = character.MaxWeight,
                MinWeight = character.MinWeight,
                Status = requestCharacter.Status,
                Reason = requestCharacter.Reason,
                TotalPrice = requestCharacter.TotalPrice,
                CreateDate = requestCharacter.CreateDate?.ToString("dd/MM/yyyy"),
                UpdateDate = requestCharacter.UpdateDate?.ToString("dd/MM/yyyy"),
                Description = requestCharacter.Description,
                CosplayerId = requestCharacter.CosplayerId,
                Quantity = requestCharacter.Quantity,
                RequestDateInCharacterResponses = requestCharacter.RequestDates.OrderBy(s => s.StartDate).Select(rd =>
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
            };
            return requestCharacterResponse;
        }
        #endregion

        #region Get List Request Character By Cosplayer
        public async Task<List<RequestCharacterResponse>> GetRequestCharacterByCosplayer(string cosplayerId)
        {
            List<RequestCharacterResponse> requestCharacters = new List<RequestCharacterResponse>();
            var listrequestcharacter = await _requestCharacterRepository.GetRequestCharacterByCosplayer(cosplayerId);
            foreach (var item in listrequestcharacter)
            {
                var character = await _characterRepository.GetCharacter(item.CharacterId);
                var listrequestdates = await _requestDatesRepository.GetAllRequestDates();
                RequestCharacterResponse requestchracter = new RequestCharacterResponse()
                {
                    RequestCharacterId = item.RequestCharacterId,
                    RequestId = item.RequestId,
                    CharacterId = item.CharacterId,
                    CharacterName = character.CharacterName,
                    MaxHeight = character.MaxHeight,
                    MinHeight = character.MinHeight,
                    MaxWeight = character.MaxWeight,
                    MinWeight = character.MinWeight,
                    Status = item.Status,
                    Reason = item.Reason,
                    TotalPrice = item.TotalPrice,
                    CreateDate = item.CreateDate?.ToString("dd/MM/yyyy"),
                    UpdateDate = item.UpdateDate?.ToString("dd/MM/yyyy"),
                    Description = item.Description,
                    CosplayerId = item.CosplayerId,
                    Quantity = item.Quantity,
                    RequestDateInCharacterResponses = item.RequestDates.OrderBy(s => s.StartDate).Select(rd =>
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

                };
                requestCharacters.Add(requestchracter);
            }
            return requestCharacters;
        }
        #endregion

        #region Update Status
        public async Task<string> UpdateStatus(string requestcharacterId, RequestCharacterStatus status)
        {
            var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(requestcharacterId);
            if (requestCharacter == null)
            {
                return "request Character is not found";
            }

            requestCharacter.Status = status;
            requestCharacter.UpdateDate = DateTime.UtcNow.AddHours(7);

            var result = await _requestCharacterRepository.UpdateRequestCharacter(requestCharacter);
            return result ? "Update Successfull" : "Update Failed";
        }
        #endregion

        #region Add Character In Request
        public async Task<string> AddCharacterInRequest(AddCharacterInRequest characterInRequest)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                if (characterInRequest == null)
                {
                    return "Request Character is null here";
                }
                if (characterInRequest.CharacterId == null && characterInRequest.RequestId == null)
                {
                    return "This field is need to required";
                }
                var character = await _characterRepository.GetCharacter(characterInRequest.CharacterId);
                if (character == null)
                {
                    await transaction.RollbackAsync();
                    return "Character is not found";
                }
                if (character.Quantity <= 0)
                {
                    await transaction.RollbackAsync();
                    return "Character is out of stock";
                }
                var request = await _requestRepository.GetRequestById(characterInRequest.RequestId);
                if (request == null)
                {
                    await transaction.RollbackAsync();
                    return "Request is not found";
                }
                if (characterInRequest.CosplayerId != null)
                {
                    if (request.RequestCharacters.Any(c => c.CosplayerId == characterInRequest.CosplayerId && c.CharacterId == characterInRequest.CharacterId))
                    {
                        await transaction.RollbackAsync();
                        return $"Cosplayer with ID {characterInRequest.CosplayerId} is already added in {characterInRequest.CharacterId}";
                    }
                    var account = await _accountRepository.GetAccount(characterInRequest.CosplayerId);
                    bool checkAccount = await _characterRepository.CheckCharacterForAccount(account, character.CharacterId);
                    if (!checkAccount)
                    {
                        await transaction.RollbackAsync();
                        return "Cosplayer does not suitable.";
                    }
                    //bool checkTask = await _taskRepository.CheckTaskIsValid(account, request.StartDate, request.EndDate);
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
                double totalDate = (request.EndDate.Date - request.StartDate.Date).Days + 1;
                var totalPrice = character.Price * characterInRequest.Quantity * totalDate;
                var newCharacterInRequest = new RequestCharacter()
                {
                    RequestCharacterId = Guid.NewGuid().ToString(),
                    CharacterId = character.CharacterId,
                    RequestId = request.RequestId,
                    Description = characterInRequest.Description,
                    Quantity = characterInRequest.Quantity,
                    Status = RequestCharacterStatus.Accept,
                    TotalPrice = totalPrice,
                    CreateDate = DateTime.UtcNow.AddHours(7),
                    UpdateDate = null,
                    CosplayerId = characterInRequest.CosplayerId,
                };

                character.Quantity -= newCharacterInRequest.Quantity;
                var resultCharacter = await _characterRepository.UpdateCharacter(character);
                if (!resultCharacter)
                {
                    await transaction.RollbackAsync();
                    return "Can not update character quantity";
                }

                var result = await _requestCharacterRepository.AddRequestCharacter(newCharacterInRequest);
                if (!result)
                {
                    await transaction.RollbackAsync();
                    return "Add Character in Request Failed";
                }
                else
                {
                    if (characterInRequest.AddRequestDates != null && characterInRequest.AddRequestDates.Any())
                    {
                        double? totalHour = 0;
                        List<RequestDate> requestDates = new List<RequestDate>();
                        foreach (var date in characterInRequest.AddRequestDates)
                        {
                            DateTime StartTime = DateTime.Now;
                            DateTime EndTime = DateTime.Now;

                            if (!string.IsNullOrEmpty(date.StartDate) || !string.IsNullOrEmpty(date.EndDate))
                            {

                                string[] timeFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                                bool isValidStartTime = DateTime.TryParseExact(date.StartDate.Trim(), timeFormats,
                                                                          System.Globalization.CultureInfo.InvariantCulture,
                                                                          System.Globalization.DateTimeStyles.None, out StartTime);

                                bool isValidEndTime = DateTime.TryParseExact(date.EndDate.Trim(), timeFormats,
                                                                             System.Globalization.CultureInfo.InvariantCulture,
                                                                             System.Globalization.DateTimeStyles.None, out EndTime);
                                if (!isValidStartTime && !isValidEndTime)
                                {
                                    return "Valid Time is wrong";
                                }
                                if (StartTime > EndTime)
                                {
                                    await transaction.RollbackAsync();
                                    return "End date must be greater than start date.";
                                }
                                if (StartTime < request.StartDate && EndTime > request.EndDate)
                                {
                                    await transaction.RollbackAsync();
                                    return "Date range must be within the request date range.";
                                }
                                requestDates.Add(new RequestDate
                                {
                                    RequestDateId = Guid.NewGuid().ToString(),
                                    RequestCharacterId = newCharacterInRequest.RequestCharacterId,
                                    Status = RequestDateStatus.Pending,
                                    StartDate = StartTime,
                                    EndDate = EndTime,
                                });

                                totalHour += (EndTime - StartTime).TotalHours;
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
                            if (characterInRequest.CosplayerId != null)
                            {
                                var cosplayer = await _accountRepository.GetAccount(characterInRequest.CosplayerId);
                                var requestCharacter = await _requestCharacterRepository.GetRequestCharacterCosplayerId(request.RequestId, character.CharacterId, characterInRequest.CosplayerId);
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
                    await transaction.CommitAsync();
                    return "Add Request character Success";
                }
            }
        }
        #endregion

        #region Update Character in Request
        public async Task<string> UpdateCharactetInRRequest(string requestCharacterId, CharacterInRequest characterInRequest)
        {
            var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(requestCharacterId);
            var character = await _characterRepository.GetCharacter(requestCharacter.CharacterId);
            var newCharacter = await _characterRepository.GetCharacter(characterInRequest.CharacterId);
            var request = await _requestRepository.GetRequestById(requestCharacter.RequestId);
            if(request == null)
            {
                return "request not found";
            }          
            if(character == null || newCharacter == null)
            {
                return "Character not found";
            }
            if (requestCharacter == null)
            {
                return "Character in request is not found";
            }

            Account cosplayer = await _accountRepository.GetAccount(characterInRequest.CosplayerId);
            if (cosplayer == null)
            {
                return "Account does not exist";
            }

            if (cosplayer.Role.RoleName != RoleName.Cosplayer)
            {
                return "Account must be cosplayer";
            }

            if (character.CharacterId == characterInRequest.CharacterId)
            {
                character.Quantity = character.Quantity + requestCharacter.Quantity - characterInRequest.Quantity;
                await _characterRepository.UpdateCharacter(character);
            }
            else
            {
                character.Quantity += requestCharacter.Quantity;
                await _characterRepository.UpdateCharacter(character);
                 newCharacter = await _characterRepository.GetCharacter(characterInRequest.CharacterId);
                newCharacter.Quantity -= characterInRequest.Quantity;
                await _characterRepository.UpdateCharacter(character);
            }

            double totalHour = 0;

            foreach(RequestDate requestDate in requestCharacter.RequestDates)
            {
                totalHour += (requestDate.EndDate - requestDate.StartDate).Hours;
            }

            double totalDate = (request.EndDate - request.StartDate).TotalDays + 1;
            var totalPrice = (newCharacter.Price * totalDate * characterInRequest.Quantity) + (cosplayer.SalaryIndex + totalHour);

            requestCharacter.CharacterId = characterInRequest.CharacterId;
            requestCharacter.CosplayerId = characterInRequest.CosplayerId;
            requestCharacter.Quantity = characterInRequest.Quantity;
            requestCharacter.TotalPrice = totalPrice;
            requestCharacter.UpdateDate = DateTime.UtcNow.AddHours(7);
            requestCharacter.Description = characterInRequest.Description;

            var result = await _requestCharacterRepository.UpdateRequestCharacter(requestCharacter);

            double totalPriceRequest = 0;

            foreach(RequestCharacter requestCharacter1 in request.RequestCharacters)
            {
                totalPriceRequest += (double)requestCharacter1.TotalPrice;
            }

            await _requestRepository.UpdateRequest(request);

            return result ? "Update Success" : "Update Failed";

        }
        #endregion

        #region Delete Character in Request
        public async Task<string> DeleteCharacterInRequest(string requestCharacterId)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                var requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(requestCharacterId);
                if (requestCharacter == null)
                {
                    await transaction.RollbackAsync();
                    return "Character is not found in Request";
                }
                var requestDate = await _requestDatesRepository.GetListRequestDateByRequestCharacterId(requestCharacterId);
                if (requestDate != null && requestDate.Any())
                {
                    var result = await _requestDatesRepository.DeleteListRequestDateByRequestCharacterId(requestCharacterId);
                    if (!result)
                    {
                        await transaction.RollbackAsync();
                        return "Request Dates is delete failed";
                    }
                }
                var result1 = await _requestCharacterRepository.DeleteRequestCharacter(requestCharacter);
                if (!result1)
                {
                    await transaction.RollbackAsync();
                    return "Request Character is deleted failed";
                }

                var character = await _characterRepository.GetCharacter(requestCharacter.CharacterId);
                character.Quantity += requestCharacter.Quantity;

                var resultCharacter = await _characterRepository.UpdateCharacter(character);
                if (!resultCharacter)
                {
                    await transaction.RollbackAsync();
                    return "Can not update character quantity";
                }

                await transaction.CommitAsync();
                return "Delete Success";
            }
        }
        #endregion

        #region Get Request Character by requestid and characterid
        public async Task<RequestCharacter> GetRequestCharacter(string requestId, string characterId)
        {
            return await _requestCharacterRepository.GetRequestCharacter(requestId, characterId);
        }
        #endregion

        public async Task<List<RequestCharacterDateResponse>> GetAllRequestCharacterByListDate(List<Date> dates)
        {
            List<RequestCharacterDateResponse> requestCharacterDateResponses = new List<RequestCharacterDateResponse>();
            string format = "HH:mm dd/MM/yyyy";
            CultureInfo culture = CultureInfo.InvariantCulture;

            List<DateRepo> dateRepos = new List<DateRepo>();

            foreach (var date in dates)
            {
                DateTime start = DateTime.ParseExact(date.StartDate, format, culture);
                DateTime end = DateTime.ParseExact(date.EndDate, format, culture);

                if (start > end)
                {
                    throw new Exception("Start can not greater than EndDate");
                }

                DateRepo dateRepo = new DateRepo()
                {
                    StartDate = start,
                    EndDate = end,
                };
                dateRepos.Add(dateRepo);
            }

            List<RequestDate> requestDates = await _requestDatesRepository.GetAllRequestDateByListDate(dateRepos);

            foreach (var requestDate in requestDates)
            {
                RequestCharacterDateResponse requestCharacterDateResponse = new RequestCharacterDateResponse()
                {
                    CharacterId = requestDate.RequestCharacter.CharacterId,
                    RequestId = requestDate.RequestCharacter.RequestId,
                    CosplayerId = requestDate.RequestCharacter.CosplayerId,
                    CreateDate = requestDate.RequestCharacter.CreateDate?.ToString("dd/MM/yyyy"),
                    UpdateDate = requestDate.RequestCharacter.UpdateDate?.ToString("dd/MM/yyyy"),
                    Description = requestDate.RequestCharacter.Description,
                    Quantity = requestDate.RequestCharacter.Quantity,
                    Reason = requestDate.RequestCharacter.Reason,
                    RequestCharacterId = requestDate.RequestCharacter.RequestId,
                    Status = requestDate.RequestCharacter.Status?.ToString(),
                    TotalPrice = requestDate.RequestCharacter.TotalPrice
                };

                requestCharacterDateResponses.Add(requestCharacterDateResponse);
            }

            return requestCharacterDateResponses.Distinct().ToList();
        }

    }
}
