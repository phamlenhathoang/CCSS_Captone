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
        Task<string> AddRequest(RequestDtos requestDtos);
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
        private readonly IServiceRepository _serviceRepository;
        private readonly IAccountCouponRepository _accountCouponRepository;

        public RequestServices(ITaskRepository taskRepository, IRequestRepository repository, IRequestCharacterRepository requestCharacterRepository, IAccountRepository accountRepository, ICharacterRepository characterRepository, IServiceRepository serviceRepository, IAccountCouponRepository accountCouponRepository)
        {
            _repository = repository;
            _characterRepository = characterRepository;
            _requestCharacterRepository = requestCharacterRepository;
            _accountRepository = accountRepository;
            this.taskRepository = taskRepository;
            _serviceRepository = serviceRepository;
            _accountCouponRepository = accountCouponRepository;
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
        #endregion

        #region Add Request
        public async Task<string> AddRequest(RequestDtos requestDtos)
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
            var service = await _serviceRepository.GetService(requestDtos.ServiceId);
            if (service == null)
            {
                return "please choose services you want";
            }
            if (service.ServiceId != "S003")
            {
                requestDtos.PackageId = null;
            }
            var accountCoupon = await _accountCouponRepository.GetAccountCouponById(requestDtos.AccountCouponId);
            if (accountCoupon == null)
            {
                return "This Account is not found";
            }
            if (accountCoupon.Coupon.Type != CouponType.ForContract)
            {
                return "This coupon not use for contract";
            }
            if (accountCoupon.IsActive == true)
            {
                return "This coupon be used";
            }

            foreach (var r in requestDtos.ListRequestCharacters)
            {
                if (r.CosplayerId != null)
                {
                    var checkCharacter = await _characterRepository.GetCharacter(r.CharacterId);
                    if (checkCharacter == null)
                    {
                        return "Character does not exist";
                    }

                    var account = await _accountRepository.GetAccount(r.CosplayerId);
                    bool checkAccount = await _characterRepository.CheckCharacterForAccount(account, r.CharacterId);
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
                var character = await _accountRepository.GetAccount(r.CosplayerId);
                if (character.RoleId != "R004" || character == null) // Kiểm tra cosplayerId có phải là cosplayer hay ko
                {

                    return "This cosplayer not found";
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
                ContractId = null,
                AccountCouponId = requestDtos.AccountCouponId,
            };
            var result = await _repository.AddRequest(newRequest);
            if (!result)
            {
                return "Add Request Failed";
            }
            else
            {
                if (requestDtos.ListRequestCharacters != null && requestDtos.ListRequestCharacters.Any())
                {
                    List<RequestCharacter> characteInRequest = new List<RequestCharacter>();

                    foreach (var r in requestDtos.ListRequestCharacters)
                    {
                        if (characteInRequest.Any(c => c.CosplayerId == r.CosplayerId))
                        {
                            await _repository.DeleteRequest(newRequest);
                            return $"Cosplayer with ID {r.CosplayerId} is already added.";
                        }
                        if (service.ServiceId == "S001")
                        {
                            r.CosplayerId = null;
                        }
                        if (service.ServiceId != "S001")
                        {
                            r.Quantity = 1;
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
                    }
                    var requestCharacterAdd = await _requestCharacterRepository.AddListRequestCharacter(characteInRequest);
                    if (!requestCharacterAdd)
                    {
                        return "Failed to add characters in Request";
                    }
                }
                return "Add Request Success";
            }
        }
        #endregion

        #region Update Request
        public async Task<string> UpdateRequest(string requestId, UpdateRequestDtos UpdateRequestDtos)
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
        #endregion

        #region Update Request Status
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
        #endregion

        #region Delete Request
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
        #endregion

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
