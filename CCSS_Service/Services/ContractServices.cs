using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Hubs;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using Contract = CCSS_Repository.Entities.Contract;
using Request = CCSS_Repository.Entities.Request;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{
    public interface IContractServices
    {
        ////Task<List<Request>> GetAllContract(string searchterm);
        //Task<Request> GetContract(string id);
        //Task<string> AddContract(ContractRequest contractRequest);
        //Task<string> UpdateContract(string contractId, ContractResponse contractResponse);
        //Task<string> DeleteContract(string id);
        //Task<string> UpdateStatusContract(string contracId, ContractStatus newStatus);
        //Task<string> UploadImageToFirebase(IFormFile file);

        Task<string> AddContract(string requestId, int deposit);
        Task<bool> UpdateStatusContract(string contractId, string status, double? price);
        Task<bool> DeleteContract(string contractId, string reason);
        Task<List<ContractResponse>> GetContract(string? contractName, string? contractStatus, string? startDate, string? endDate, string? accountId, string? contractId);
        Task<ContractResponse> GetContractById(string contractId);
        Task<List<ContractResponse>> GetContractByAccountId(string accountId);
        Task<List<RequestInContractResponse>> GetRequestInContractByAccountId(string accountId);

    }
    public class ContractServices : IContractServices
    {
        private readonly IContractRespository _contractRespository;
        private readonly IContractCharacterRepository _contractCharacterRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IRequestCharacterRepository _requestCharacterRepository;
        private readonly IAccountCouponRepository accountCouponRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IPdfService pdfService;
        private readonly Image Image;
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly INotificationRepository notificationRepository;
        private readonly IContractCharacterService contractCharacterService;
        private readonly IPackageRepository packageRepository;
        private readonly IMapper mapper;
        private readonly string _projectId = "miracles-ef238";
        private readonly string _bucketName = "miracles-ef238.appspot.com";
        private readonly ITaskService taskService;

        public ContractServices(IMapper mapper, IPackageRepository packageRepository, IContractCharacterService contractCharacterService, INotificationRepository notificationRepository, IHubContext<NotificationHub> hubContext, IAccountRepository _accountRepository, IServiceRepository _serviceRepository, Image Image, IPdfService pdfService, IAccountCouponRepository accountCouponRepository, IRequestRepository _requestRepository, IContractRespository _contractRespository, IContractCharacterRepository contractCharacterRepository, ICharacterRepository characterRepository, IRequestCharacterRepository requestCharacterRepository, ITaskService taskService)
        {
            this._contractRespository = _contractRespository;
            _requestCharacterRepository = requestCharacterRepository;
            _contractCharacterRepository = contractCharacterRepository;
            _characterRepository = characterRepository;
            this._requestRepository = _requestRepository;
            this.accountCouponRepository = accountCouponRepository;
            this.pdfService = pdfService;
            this.Image = Image;
            this._serviceRepository = _serviceRepository;
            this._accountRepository = _accountRepository;
            this.hubContext = hubContext;
            this.notificationRepository = notificationRepository;
            this.contractCharacterService = contractCharacterService;
            this.packageRepository = packageRepository;
            this.mapper = mapper;
            this.taskService = taskService;
            //this.transactionRepository = transactionRepository; 
        }

        public async Task<List<RequestInContractResponse>> GetRequestInContractByAccountId(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new Exception("Need entry this field");
            }
            List<RequestInContractResponse> list = new List<RequestInContractResponse>();
            var listcontract = await _contractRespository.GetAllContractByAccountId(accountId);


            foreach (var item in listcontract)
            {
                var listRequestCharacter = await _requestCharacterRepository.GetAllRequestCharacter();
                //var contract = await _contractRespository.GetContractById(item.ContractId);
                var request = await _requestRepository.GetRequestById(item.RequestId);
                List<CharacterRequestResponse> characterResponses = listRequestCharacter.Where(sc => sc.RequestId.Equals(item.RequestId)).Select(c => new CharacterRequestResponse()
                {
                    CharacterId = c.CharacterId,
                    CosplayerId = c.CosplayerId,
                    Description = c.Description,
                    Quantity = c.Quantity
                }).ToList();

                RequestResponse requestResponse = new RequestResponse()
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
                    CharactersListResponse = characterResponses

                };

                RequestInContractResponse requestContract = new RequestInContractResponse()
                {
                    ContractId = item.ContractId,
                    RequestResponse = requestResponse,
                };
                list.Add(requestContract);
            }
            return list;
        }


        public async Task<string> AddContract(string requestId, int deposit)
        {
            try
            {
                Request request = await _requestRepository.GetRequestByIdInclude(requestId);
                if (request == null)
                {
                    throw new Exception("Request does not exist");
                }
                if (request.Status != RequestStatus.Browsed)
                {
                    throw new Exception("Request not browsed yet");
                }

                if (request.Service == null)
                {
                    throw new Exception("Service does not exist");
                }

                if (request.Account == null)
                {
                    throw new Exception("Account does not exist");
                }

                if (request.Contract != null)
                {
                    throw new Exception("This request created contract");
                }

                Contract contract = new Contract()
                {
                    Deposit = deposit.ToString(),
                    TotalPrice = request.Price,
                    Amount = request.Price - ((request.Price * deposit) / 100),
                    RequestId = requestId,
                    CreateBy = request.AccountId,
                    ContractId = Guid.NewGuid().ToString(),
                    CreateDate = DateTime.Now,
                    ContractStatus = ContractStatus.Active,
                    ContractName = request.Service.ServiceName,
                    UrlPdf = await Image.UploadImageToFirebase(await pdfService.ConvertBytesToIFormFile(request, deposit)),
                };

                bool result = await _contractRespository.AddContract(contract);
                if (result)
                {
                    return "Success";
                }
                return "Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteContract(string contractId, string reason)
        {
            try
            {
                Contract contract = await _contractRespository.GetContractById(contractId);
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }
                if (contract.ContractStatus != ContractStatus.Active)
                {
                    throw new Exception("Contract can not delete");
                }
                contract.ContractStatus = ContractStatus.Cancel;
                contract.Reason = reason;
                bool result = await _contractRespository.UpdateContract(contract);
                if (result)
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


        public async Task<List<ContractResponse>> GetContract(string? contractName, string? contractStatus, string? startDate, string? endDate, string? accountId, string? contractId)
        {
            try
            {
                List<ContractResponse> crs = new List<ContractResponse>();
                List<ListContractCharcterResponse> listContractCharcterResponses = new List<ListContractCharcterResponse>();
                List<Contract> contracts = await _contractRespository.GetContract(contractName, contractStatus, startDate, endDate, accountId, contractId);
                if (contracts == null)
                {
                    return crs;
                }
                Package package = null;
                foreach (var contract in contracts)
                {
                    ContractResponse crsItem = new ContractResponse()
                    {
                        ContractId = contract.ContractId,
                        RequestId = contract.RequestId,
                        Amount = contract.Amount ?? 0,
                        ContractName = contract.ContractName,
                        Deposit = contract.Deposit,
                        EndDate = contract.Request.EndDate.ToString("HH:mm dd/MM/yyyy"),
                        StartDate = contract.Request.StartDate.ToString("HH:mm dd/MM/yyyy"),
                        Price = (double)contract.TotalPrice,
                        Status = contract.ContractStatus.ToString(),
                        Reason = contract.Reason,
                    };

                    if (contract.Request.PackageId != null)
                    {
                        package = await packageRepository.GetPackage(contract.Request.PackageId);
                        if (package == null)
                        {
                            throw new Exception("Package does not exist");
                        }
                        crsItem.PackageName = package.PackageName;
                    }
                    else
                    {
                        crsItem.PackageName = null;
                    }

                    if (contract.Request.AccountCouponId != null)
                    {
                        AccountCoupon accountCoupon = await accountCouponRepository.GetAccountCoupon(contract.Request.AccountCouponId);
                        if (accountCoupon == null)
                        {
                            throw new Exception("AccountCoupon does not exist");
                        }
                        if (accountCoupon.Coupon == null)
                        {
                            throw new Exception("Coupont does not exist");
                        }
                        crsItem.AccountCoupon = accountCoupon.Coupon.Amount;
                    }
                    else
                    {
                        crsItem.AccountCoupon = 0;
                    }

                    if (contract.ContractCharacters != null)
                    {
                        foreach (var contractCharacter in contract.ContractCharacters)
                        {
                            Account account = new Account();
                            if (contractCharacter.CosplayerId != null)
                            {
                                account = await _accountRepository.GetAccount(contractCharacter.CosplayerId);
                                if (account == null)
                                {
                                    throw new Exception("Account does not exist");
                                }
                            }
                            Character character = await _characterRepository.GetCharacter(contractCharacter.CharacterId);
                            if (character == null)
                            {
                                throw new Exception("Character does not exist");
                            }

                            ListContractCharcterResponse listContractCharcterResponse = new ListContractCharcterResponse()
                            {
                                CharacterName = character.CharacterName,
                                Quantity = (int)contractCharacter.Quantity,
                            };

                            if (account != null)
                            {
                                listContractCharcterResponse.CosplayerName = account.Name;
                            }
                            else
                            {
                                listContractCharcterResponse.CosplayerName = null;
                            }

                            listContractCharcterResponses.Add(listContractCharcterResponse);

                        }

                        crsItem.ContractCharacters = listContractCharcterResponses;

                        crs.Add(crsItem);

                        listContractCharcterResponses = new List<ListContractCharcterResponse>();
                    }
                }

                return crs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ContractResponse>> GetContractByAccountId(string accountId)
        {

            try
            {
                List<ContractResponse> crs = new List<ContractResponse>();
                List<ListContractCharcterResponse> listContractCharcterResponses = new List<ListContractCharcterResponse>();
                List<Contract> contracts = await _contractRespository.GetContract(null, null, null, null, accountId, null);

                if (contracts == null)
                {
                    return null;
                }

                Package package = null;
                foreach (var contract in contracts)
                {
                    ContractResponse crsItem = new ContractResponse()
                    {
                        ContractId = contract.ContractId,
                        RequestId = contract.RequestId,
                        Amount = contract.Amount ?? 0,
                        ContractName = contract.ContractName,
                        Deposit = contract.Deposit,
                        EndDate = contract.Request.EndDate.ToString("HH:mm dd/MM/yyyy"),
                        StartDate = contract.Request.StartDate.ToString("HH:mm dd/MM/yyyy"),
                        Price = (double)contract.TotalPrice,
                        Status = contract.ContractStatus.ToString(),
                        Reason = contract.Reason,
                    };

                    if (contract.Request.PackageId != null)
                    {
                        package = await packageRepository.GetPackage(contract.Request.PackageId);
                        if (package == null)
                        {
                            throw new Exception("Package does not exist");
                        }
                        crsItem.PackageName = package.PackageName;
                    }
                    else
                    {
                        crsItem.PackageName = null;
                    }

                    if (contract.Request.AccountCouponId != null)
                    {
                        AccountCoupon accountCoupon = await accountCouponRepository.GetAccountCoupon(contract.Request.AccountCouponId);
                        if (accountCoupon == null)
                        {
                            throw new Exception("AccountCoupon does not exist");
                        }
                        if (accountCoupon.Coupon == null)
                        {
                            throw new Exception("Coupont does not exist");
                        }
                        crsItem.AccountCoupon = accountCoupon.Coupon.Amount;
                    }
                    else
                    {
                        crsItem.AccountCoupon = 0;
                    }

                    if (contract.ContractCharacters != null)
                    {
                        foreach (var contractCharacter in contract.ContractCharacters)
                        {
                            Account account = new Account();
                            if (contractCharacter.CosplayerId != null)
                            {
                                account = await _accountRepository.GetAccount(contractCharacter.CosplayerId);
                                if (account == null)
                                {
                                    throw new Exception("Account does not exist");
                                }
                            }
                            Character character = await _characterRepository.GetCharacter(contractCharacter.CharacterId);
                            if (character == null)
                            {
                                throw new Exception("Character does not exist");
                            }

                            ListContractCharcterResponse listContractCharcterResponse = new ListContractCharcterResponse()
                            {
                                CharacterName = character.CharacterName,
                                Quantity = (int)contractCharacter.Quantity,
                            };

                            if (account != null)
                            {
                                listContractCharcterResponse.CosplayerName = account.Name;
                            }
                            else
                            {
                                listContractCharcterResponse.CosplayerName = null;
                            }

                            listContractCharcterResponses.Add(listContractCharcterResponse);

                        }

                        crsItem.ContractCharacters = listContractCharcterResponses;

                        crs.Add(crsItem);

                        listContractCharcterResponses = new List<ListContractCharcterResponse>();
                    }
                }

                return crs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContractResponse> GetContractById(string contractId)
        {
            try
            {
                List<ListContractCharcterResponse> listContractCharcterResponses = new List<ListContractCharcterResponse>();

                Contract contract = await _contractRespository.GetContractById(contractId);

                if (contract == null)
                {
                    return null;
                }

                ContractResponse crsItem = new ContractResponse()
                {
                    ContractId = contract.ContractId,
                    RequestId = contract.RequestId,
                    Amount = contract.Amount ?? 0,
                    ContractName = contract.ContractName,
                    Deposit = contract.Deposit,
                    EndDate = contract.Request.EndDate.ToString("HH:mm dd/MM/yyyy"),
                    StartDate = contract.Request.StartDate.ToString("HH:mm dd/MM/yyyy"),
                    Price = (double)contract.TotalPrice,
                    Status = contract.ContractStatus.ToString(),
                    Reason = contract.Reason,
                };

                Package package = new Package();

                if (contract.Request.PackageId != null)
                {
                    package = await packageRepository.GetPackage(contract.Request.PackageId);
                    if (package == null)
                    {
                        throw new Exception("Package does not exist");
                    }
                    crsItem.PackageName = package.PackageName;
                }
                else
                {
                    crsItem.PackageName = null;
                }

                if (contract.Request.AccountCouponId != null)
                {
                    AccountCoupon accountCoupon = await accountCouponRepository.GetAccountCoupon(contract.Request.AccountCouponId);
                    if (accountCoupon == null)
                    {
                        throw new Exception("AccountCoupon does not exist");
                    }
                    if (accountCoupon.Coupon == null)
                    {
                        throw new Exception("Coupont does not exist");
                    }
                    crsItem.AccountCoupon = accountCoupon.Coupon.Amount;
                }
                else
                {
                    crsItem.AccountCoupon = 0;
                }

                if (contract.ContractCharacters != null)
                {
                    foreach (var contractCharacter in contract.ContractCharacters)
                    {
                        Account account = new Account();
                        if (contractCharacter.CosplayerId != null)
                        {
                            account = await _accountRepository.GetAccount(contractCharacter.CosplayerId);
                            if (account == null)
                            {
                                throw new Exception("Account does not exist");
                            }
                        }
                        Character character = await _characterRepository.GetCharacter(contractCharacter.CharacterId);
                        if (character == null)
                        {
                            throw new Exception("Character does not exist");
                        }

                        ListContractCharcterResponse listContractCharcterResponse = new ListContractCharcterResponse()
                        {
                            CharacterName = character.CharacterName,
                            Quantity = (int)contractCharacter.Quantity,
                        };

                        if (account != null)
                        {
                            listContractCharcterResponse.CosplayerName = account.Name;
                        }
                        else
                        {
                            listContractCharcterResponse.CosplayerName = null;
                        }

                        listContractCharcterResponses.Add(listContractCharcterResponse);

                    }

                    crsItem.ContractCharacters = listContractCharcterResponses;
                }

                return crsItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> UpdateStatusContract(string contractId, string status, double? price)
        {
            //using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                Contract contract = await _contractRespository.GetContractById(contractId);
                if (contract == null)
                {
                    //await transaction.RollbackAsync();
                    throw new Exception("Contract does not exist");
                }
                if (status.ToUpper() == ContractStatus.Cancel.ToString().ToUpper())
                {
                    if (contract.ContractStatus == ContractStatus.Active)
                    {
                        contract.ContractStatus = ContractStatus.Cancel;
                    }
                    else
                    {
                        //await transaction.RollbackAsync();
                        throw new Exception("Can not update contract status");
                    }
                }
                if (status.ToUpper() == ContractStatus.Progressing.ToString().ToUpper())
                {
                    if (contract.ContractStatus == ContractStatus.Active)
                    {
                        contract.ContractStatus = ContractStatus.Progressing;
                    }
                    else
                    {
                        //await transaction.RollbackAsync();
                        throw new Exception("Can not update contract status");
                    }
                }
                if (status.ToUpper() == ContractStatus.Completed.ToString().ToUpper())
                {
                    if (contract.ContractStatus == ContractStatus.Progressing)
                    {
                        if (price != null)
                        {
                            contract.ContractStatus = ContractStatus.Completed;
                            double amount = (double)contract.Amount - (double)price;
                        }
                        else
                        {
                            throw new Exception("Please enter price");
                        }
                    }
                    else
                    {
                        //await transaction.RollbackAsync();
                        throw new Exception("Can not update contract status");
                    }
                }

                bool result = await _contractRespository.UpdateContract(contract);
                if (!result)
                {
                    return false;
                }

                if (contract.ContractStatus == ContractStatus.Progressing)
                {
                    bool checkAddContractCharacter = await contractCharacterService.AddListContractCharacter(contract);
                    if (!checkAddContractCharacter)
                    {
                        //await transaction.RollbackAsync();
                        throw new Exception("Cannot add ContractCharacter");
                    }
                }
                if (contract.ContractStatus == ContractStatus.Completed)
                {
                    bool checkTask = await taskService.UpdateStatusTaskByContractId(contract.ContractId);
                    if (!checkTask)
                    {
                        //await transaction.RollbackAsync();
                        throw new Exception("Cannot update status task");
                    }
                }
                //scope.Complete();
                return true;
            }
            catch (Exception ex)
            {
                //await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }

        }

        private async Task<bool> NortificationCustomer(Contract contract)
        {

            try
            {
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                Notification notification = new Notification();

                string connectionId = NotificationHub.GetConnectionId(contract.CreateBy);
                string message = $"Your request has been approved. Please log in to the system to view contract information and make payment.";

                if (!string.IsNullOrEmpty(connectionId))
                {
                    await hubContext.Clients.Client(connectionId).SendAsync("ReceiveTaskNotification", message);
                }
                else
                {
                    Console.WriteLine($"User {contract.CreateBy} không online, không thể gửi thông báo");
                    notification.AccountId = contract.CreateBy;
                    notification.Message = message;
                    notification.Id = Guid.NewGuid().ToString();
                }
                bool result = await notificationRepository.AddNotification(notification) ? true : false;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
