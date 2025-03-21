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
        Task<RequestResponse> GetRequestById(string id);
        Task<string> DeleteRequest(string id);
        Task<string> AddRequest(RequestDtos requestDtos, RequestDescription requestDescription);
        Task<string> UpdateRequest(string requestId, UpdateRequestDtos requestDtos);
        Task<string> UpdateStatusRequest(string requestId, RequestStatus requestStatus);
        Task<double> TotalPriceRequest(double packagePrice, double accountCouponPrice, string startDate, string endDate, List<RequestTotalPrice> requestTotalPrices);
    }
    public class RequestServices : IRequestServices
    {
        private readonly IRequestRepository _repository;
        private readonly IRequestCharacterRepository _requestCharacterRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly ITaskRepository taskRepository;

        public RequestServices(ITaskRepository taskRepository, IRequestRepository repository, IRequestCharacterRepository requestCharacterRepository, IAccountRepository accountRepository, ICharacterRepository characterRepository)
        {
            _repository = repository;
            _characterRepository = characterRepository;
            _requestCharacterRepository = requestCharacterRepository;
            _accountRepository = accountRepository;
            this.taskRepository = taskRepository;
        }

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
                    Quantity = c.Quantity
                }).ToList();

                RequestResponse response = new RequestResponse()
                {
                    RequestId = item.RequestId,
                    AccountId = item.AccountId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Status = item.Status,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Location = item.Location,
                    ServiceId = item.ServiceId,
                    PackageId = item.PackageId,
                    ContractId = item.ContractId,
                    CharactersListResponse = characterResponses
                };
                listRequest.Add(response); ;
            }
            return listRequest;
        }

        public async Task<RequestResponse> GetRequestById(string id)
        {
            var request = await _repository.GetRequestById(id);
            var listRequestCharacter = await _requestCharacterRepository.GetAllRequestCharacter();

            List<CharacterRequestResponse> characterResponses = listRequestCharacter.Where(sc => sc.RequestId.Equals(request.RequestId)).Select(c => new CharacterRequestResponse()
            {
                CharacterId = c.CharacterId,
                CosplayerId = c.CosplayerId,
                Description = c.Description,
                Quantity = c.Quantity
            }).ToList();

            var response = new RequestResponse()
            {
                RequestId = request.RequestId,
                AccountId = request.AccountId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Status = request.Status,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                ServiceId = request.ServiceId,
                PackageId = request.PackageId,
                ContractId = request.ContractId,
                CharactersListResponse = characterResponses
            };
            return response;
        }
        
        private (bool IsValid, string ErrorMessage, DateTime StartDate, DateTime EndDate) ValidateAndParseDates(string startDateStr, string endDateStr)
        {
            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;

            if (!string.IsNullOrEmpty(startDateStr) || !string.IsNullOrEmpty(endDateStr))
            {
                string[] dateFormats = { "HH:mm dd/MM/yyyy", "HH:mm d/MM/yyyy", "HH:mm dd/M/yyyy", "HH:mm d/M/yyyy" };

                bool isValidDate = DateTime.TryParseExact(startDateStr, dateFormats,
                                                          System.Globalization.CultureInfo.InvariantCulture,
                                                          System.Globalization.DateTimeStyles.None,
                                                          out StartDate);

                bool isValidEndDate = DateTime.TryParseExact(endDateStr, dateFormats,
                                                             System.Globalization.CultureInfo.InvariantCulture,
                                                             System.Globalization.DateTimeStyles.None,
                                                             out EndDate);

                if (!isValidDate || !isValidEndDate)
                {
                    return (false, "Date format is incorrect. Please enter the right format DateTime.", StartDate, EndDate);
                }
                if (StartDate < DateTime.Now)
                {
                    return (false, "Start date cannot be in the past.", StartDate, EndDate);
                }
                if (EndDate < DateTime.Now)
                {
                    return (false, "End date cannot be in the past.", StartDate, EndDate);
                }
                if (StartDate > EndDate)
                {
                    return (false, "End date must be greater than event date.", StartDate, EndDate);
                }
            }

            return (true, "", StartDate, EndDate);
        }
        public async Task<string> AddRequest(RequestDtos requestDtos, RequestDescription requestDescription)
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

            foreach (var character in requestDtos.ListRequestCharacters)
            {
                if (character.CosplayerId != null)
                {
                    Character checkCharacter = await _characterRepository.GetCharacter(character.CharacterId);
                    if (checkCharacter == null)
                    {
                        return "Character does not exist";
                    }

                    Account account = await _accountRepository.GetAccount(character.CosplayerId);
                    bool checkAccount = await _characterRepository.CheckCharacterForAccount(account, character.CharacterId);
                    if (!checkAccount)
                    {
                        return "Cosplayer does not suitable.";
                    }

                    bool checkTask = await taskRepository.CheckTaskIsValid(account, StartDate, EndDate);
                    if (!checkTask)
                    {
                        return "This cosplayer is has another job. Please change datetime.";
                    }
                }
            }

            if (requestDtos == null)
            {
                return "Need fill request";
            }

            var newRequest = new Request()
            {
                RequestId = Guid.NewGuid().ToString(),
                AccountId = requestDtos.AccountId,
                Name = requestDtos.Name,
                Price = requestDtos.Price,
                Status = RequestStatus.Pending,
                StartDate = StartDate,
                EndDate = EndDate,
                Location = requestDtos.Location,
                ServiceId = requestDtos.ServiceId,
                PackageId = requestDtos.PackageId,
                ContractId = null,
                AccountCouponId = requestDtos.AccountCouponId,
            };

            if (requestDescription == RequestDescription.RentCosplayer)
            {
                newRequest.Description = RequestDescription.RentCosplayer;
                await _repository.AddRequest(newRequest);
                if (requestDtos.ListRequestCharacters != null && requestDtos.ListRequestCharacters.Any())
                {
                    List<RequestCharacter> characteInRequest = new List<RequestCharacter>();

                    foreach (var r in requestDtos.ListRequestCharacters)
                    {
                        var character = await _accountRepository.GetAccount(r.CosplayerId);
                        if (character.RoleId != "R004" || character == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                        {
                            await _repository.DeleteRequest(newRequest);
                            return "This cosplayer not found";
                        }
                        if (characteInRequest.Any(c => c.CosplayerId == r.CosplayerId))
                        {
                            await _repository.DeleteRequest(newRequest);
                            return $"Cosplayer with ID {r.CosplayerId} is already added.";
                        }
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
                        });
                        if (r.Quantity > 1)
                        {
                            return "Rent Cosplayer just only 1 Character for 1 Cosplayer";
                        }
                    }

                    var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                    if (!requestCharacterAdd)
                    {
                        return "Failed to add characters.";
                    }
                }
            }
            else if (requestDescription == RequestDescription.CreateEvent)
            {
                newRequest.Description = RequestDescription.CreateEvent;
                await _repository.AddRequest(newRequest);
                if (requestDtos.ListRequestCharacters != null && requestDtos.ListRequestCharacters.Any())
                {
                    List<RequestCharacter> characteInRequest = new List<RequestCharacter>();

                    foreach (var r in requestDtos.ListRequestCharacters)
                    {
                        var character = await _accountRepository.GetAccount(r.CosplayerId);
                        if (character.RoleId != "R004" || character == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                        {
                            await _repository.DeleteRequest(newRequest);
                            return "This cosplayer not found";
                        }

                        // Nếu CosplayerId hợp lệ, thêm vào danh sách
                        characteInRequest.Add(new RequestCharacter
                        {
                            RequestCharacterId = Guid.NewGuid().ToString(),
                            RequestId = newRequest.RequestId,
                            CharacterId = r.CharacterId,
                            CreateDate = newRequest.StartDate,
                            Description = r.Description,
                            Quantity = r.Quantity,
                            CosplayerId = null,
                            
                        });
                    }

                    var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                    if (!requestCharacterAdd)
                    {
                        return "Failed to add characters.";
                    }
                }
            }
            else
            {
                newRequest.Description = RequestDescription.RentCostumes;
                if (requestDtos.ListRequestCharacters != null && requestDtos.ListRequestCharacters.Any())
                {
                    List<RequestCharacter> characteInRequest = new List<RequestCharacter>();

                    foreach (var r in requestDtos.ListRequestCharacters)
                    {
                        var character = await _accountRepository.GetAccount(r.CosplayerId);
                        if (character.RoleId != "R004" || character == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                        {
                            await _repository.DeleteRequest(newRequest);
                            return "This cosplayer not found";
                        }

                        // Nếu CosplayerId hợp lệ, thêm vào danh sách
                        characteInRequest.Add(new RequestCharacter
                        {
                            RequestCharacterId = Guid.NewGuid().ToString(),
                            RequestId = newRequest.RequestId,
                            CharacterId = r.CharacterId,
                            CreateDate = newRequest.StartDate,
                            Description = r.Description,
                            Quantity = r.Quantity,
                            CosplayerId = null,
                        });
                    }

                    var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                    if (!requestCharacterAdd)
                    {
                        return "Failed to add characters.";
                    }
                }
                await _repository.AddRequest(newRequest);
            }

            return "Add Request Success";
        }

        public async Task<string> UpdateRequest(string requestId, UpdateRequestDtos UpdateRequestDtos)
        {
            var (isValid, errorMessage, StartDate, EndDate) = ValidateAndParseDates(UpdateRequestDtos.StartDate, UpdateRequestDtos.EndDate);

            var requestExisting = await _repository.GetRequestById(requestId);
            if (requestExisting == null)
            {
                return "Request is not found";
            }

            requestExisting.Name = UpdateRequestDtos.Name;
            requestExisting.StartDate = StartDate;
            requestExisting.EndDate = EndDate;
            requestExisting.Location = UpdateRequestDtos.Location;
            requestExisting.ServiceId = UpdateRequestDtos.ServiceId;


            List<RequestCharacter> characterInRequest = new List<RequestCharacter>();
            List<string> missingCharacters = new List<string>();

            foreach (var r in UpdateRequestDtos.ListUpdateRequestCharacters)
            {
                var cosplayer = await _accountRepository.GetAccount(r.CosplayerId);
                if (cosplayer.RoleId != "R004" || cosplayer == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                {
                    return "This cosplayer not found";
                }
                var requestCharacter = await _requestCharacterRepository.GetRequestCharacter(requestExisting.RequestId, r.CharacterId);
                var character = await _characterRepository.GetCharacter(r.CharacterId);
                if (requestCharacter == null)
                {
                    missingCharacters.Add(r.CharacterId);
                }
                else
                {
                    requestCharacter.CreateDate = StartDate;
                    requestCharacter.Quantity = r.Quantity;
                    requestCharacter.CosplayerId = r.CosplayerId;
                    requestCharacter.Description = r.Description;

                    characterInRequest.Add(requestCharacter);
                }
            }
            if (missingCharacters.Any())
            {
                return $"Characters with IDs {string.Join(", ", missingCharacters)} do not exist in the request.";
            }

            if (characterInRequest.Any())
            {
                await _requestCharacterRepository.UpdateListRequestCharacter(characterInRequest);
            }
            await _repository.UpdateRequest(requestExisting);

            return "Update request Success";

        }

        public async Task<string> UpdateStatusRequest(string requestId, RequestStatus requestStatus)
        {
            var request = await _repository.GetRequestById(requestId);
            if (request == null)
            {
                return "Request not found";
            }
            request.Status = requestStatus;

            await _repository.UpdateRequest(request);

            return "Status is update success";
        }
        public async Task<string> DeleteRequest(string id)
        {
            var request = await _repository.GetRequestById(id);
            if (request == null)
            {
                return "Request not found";
            }
            await _repository.DeleteRequest(request);
            return "Delete Request Success";
        }

        public async Task<double> TotalPriceRequest(double packagePrice, double accountCouponPrice, string startDate, string endDate, List<RequestTotalPrice> requestTotalPrices)
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

                int totalDay = (int)Math.Ceiling((EndDate - StartDate).TotalDays);
                double totalPrice = 0;

                foreach (var request in requestTotalPrices)
                {
                    totalPrice += request.CharacterPrice * (request.SalaryIndex != 0 ? request.SalaryIndex : 1);
                }

                return totalDay * totalPrice + packagePrice + accountCouponPrice;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
