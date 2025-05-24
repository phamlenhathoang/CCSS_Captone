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
using Type = CCSS_Repository.Entities.Type;

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
        Task<bool> UpdateStatusContract(string contractId, string status, double? price, string? reason);
        Task<bool> DeleteContract(string contractId, string reason);
        Task<List<ContractResponse>> GetContract(string? contractName, string? contractStatus, string? startDate, string? endDate, string? accountId, string? contractId);
        Task<ContractResponse> GetContractById(string contractId);
        Task<List<ContractResponse>> GetContractByAccountId(string accountId);
        Task<List<RequestInContractResponse>> GetRequestInContractByAccountId(string accountId);
        Task<bool> UpdateDeliveryContract(DeliveryContractRequest deliveryContractRequest);
        Task<ContractResponse> GetContractByRequestCharacterId(string requestCharacterId);
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
        private readonly IContractImageRepository contractImageRepository;
        private readonly IContractRefundRepository contractRefundRepository;
        private readonly ITaskRepository taskRepository;
        private readonly IPaymentRepository paymentRepository;
        public ContractServices(IMapper mapper, IPackageRepository packageRepository, IContractCharacterService contractCharacterService, INotificationRepository notificationRepository, IHubContext<NotificationHub> hubContext, IAccountRepository _accountRepository, IServiceRepository _serviceRepository, Image Image, IPdfService pdfService, IAccountCouponRepository accountCouponRepository, IRequestRepository _requestRepository, IContractRespository _contractRespository, IContractCharacterRepository contractCharacterRepository, ICharacterRepository characterRepository, IRequestCharacterRepository requestCharacterRepository, ITaskService taskService, IContractImageRepository contractImageRepository, IContractRefundRepository contractRefundRepository, ITaskRepository taskRepository, IPaymentRepository paymentRepository)
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
            this.contractImageRepository = contractImageRepository;
            this.contractRefundRepository = contractRefundRepository;
            this.taskRepository = taskRepository;
            this.paymentRepository = paymentRepository;
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
                    StartDate = request.StartDate.ToString("HH:mm dd/MM/yyyy"),
                    EndDate = request.EndDate.ToString("HH:mm dd/MM/yyyy"),
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
                    RequestId = requestId,
                    CreateBy = request.AccountId,
                    ContractId = Guid.NewGuid().ToString(),
                    CreateDate = DateTime.Now,
                    ContractStatus = ContractStatus.Created,
                    ContractName = request.Service.ServiceName,
                    UrlPdf = await Image.UploadImageToFirebase(await pdfService.ConvertBytesToIFormFile(request, deposit)),
                };


                if (request.Service.ServiceId != "S001")
                {
                    contract.Amount = request.Price - ((request.Price * deposit) / 100);
                }
                else
                {
                    contract.Amount = deposit - request.Price;
                }

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
                if (contract.ContractStatus != ContractStatus.Created)
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
                    Account customer = await _accountRepository.GetAccountByAccountId(contract.CreateBy);
                    if (customer == null)
                    {
                        throw new Exception("Account does not exist");
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
                        CreateBy = customer.Name,
                        CreateDate = contract.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                        UrlPdf = contract.UrlPdf,
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
                    Account customer = await _accountRepository.GetAccountByAccountId(contract.CreateBy);
                    if (customer == null)
                    {
                        throw new Exception("Account does not exist");
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
                        CreateBy = customer.Name,
                        CreateDate = contract.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                        UrlPdf = contract.UrlPdf,
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

                Account customer = await _accountRepository.GetAccountByAccountId(contract.CreateBy);
                if (customer == null)
                {
                    throw new Exception("Account does not exist");
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
                    CreateBy = customer.Name,
                    CreateDate = contract.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                    UrlPdf = contract.UrlPdf,
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


        public async Task<bool> UpdateStatusContract(string contractId, string status, double? price, string? reason)
        {
            //using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                Contract contract = await _contractRespository.GetContractById(contractId);

                if (contract.Request == null)
                {
                    throw new Exception("Request does not exist");
                }

                if (contract.Request.RequestCharacters == null)
                {
                    throw new Exception("RequestCharacter does not exist");
                }


                if (contract == null)
                {
                    //await transaction.RollbackAsync();
                    throw new Exception("Contract does not exist");
                }
                if (status.ToUpper() == ContractStatus.Cancel.ToString().ToUpper())
                {
                    if (contract.ContractStatus == ContractStatus.Created)
                    {
                        if(reason != null)
                        {
                            contract.ContractStatus = ContractStatus.Cancel;
                            contract.Reason = reason;

                            List<RequestCharacter> requestCharacters = new List<RequestCharacter>();

                            foreach(RequestCharacter requestCharacter in contract.Request.RequestCharacters)
                            {
                                requestCharacter.Status = RequestCharacterStatus.Cancel;
                                requestCharacter.Reason = reason;

                                requestCharacters.Add(requestCharacter);

                                Character character = await _characterRepository.GetCharacter(requestCharacter.CharacterId);

                                if (character != null)
                                {
                                    character.Quantity += requestCharacter.Quantity;

                                    bool checkUpdate = await _characterRepository.UpdateCharacter(character);
                                    if (!checkUpdate)
                                    {
                                        throw new Exception("Can not update character");
                                    }
                                }
                                else
                                {
                                    throw new Exception("Character does not exist");
                                }
                            }

                            bool updateRequestCharacter = await _requestCharacterRepository.UpdateListRequestCharacter(requestCharacters);

                            if (!updateRequestCharacter)
                            {
                                throw new Exception("Can not update RequestCharacter");
                            }
                        }
                        else
                        {
                            throw new Exception("Please enter your reason");
                        }
                    }
                    else
                    {
                        throw new Exception("Can not update contract status");
                    }
                }
                if (status.ToUpper() == ContractStatus.Deposited.ToString().ToUpper())
                {
                    if (contract.ContractStatus == ContractStatus.Created)
                    {
                        contract.ContractStatus = ContractStatus.Deposited;
                        contract.DeliveryStatus = DeliveryStatus.Preparing;
                    }
                    else
                    {
                        throw new Exception("Can not update contract status");
                    }
                }
                

                if(status.ToUpper() == ContractStatus.Refund.ToString().ToUpper())
                {
                    if (contract.Request.ServiceId == "S001")
                    {
                        if(contract.ContractStatus == ContractStatus.Deposited)
                        {
                            contract.ContractStatus = ContractStatus.Refund;
                        }
                        else
                        {
                            throw new Exception("Can not update contract status");
                        }
                    }
                    else
                    {
                        throw new Exception("The service of this contract must be S001");
                    }
                }

                if (status.ToUpper() == ContractStatus.Completed.ToString().ToUpper())
                {
                    if(contract.Request.ServiceId != "S001")
                    {
                        if (contract.ContractStatus == ContractStatus.Deposited)
                        {
                            foreach (ContractCharacter contractCharacter in contract.ContractCharacters)
                            {
                                List<CCSS_Repository.Entities.Task> tasks = await taskRepository.GetTaskByContractCharacterId(contractCharacter.ContractCharacterId);
                                foreach (CCSS_Repository.Entities.Task task in tasks)
                                {
                                    if (task.Status != CCSS_Repository.Entities.TaskStatus.Completed)
                                    {
                                        throw new Exception("Can not update status contract because status task of contract must be completed");
                                    }
                                }
                            }
                            contract.ContractStatus = ContractStatus.Completed;
                            contract.Amount = (double)contract.Amount - (double)price;
                        }
                        else
                        {
                            //await transaction.RollbackAsync();
                            throw new Exception("Can not update contract status");
                        }
                    }
                    else
                    {
                        if (contract.ContractStatus == ContractStatus.Refund)
                        {
                            contract.ContractStatus = ContractStatus.Completed;
                        }
                        else
                        {
                            //await transaction.RollbackAsync();
                            throw new Exception("Can not update contract status");
                        }

                        contract.ContractRefund.Status = ContractRefundStatus.Paid;

                        bool updateContractRefund = await contractRefundRepository.UpdateContractRefund(contract.ContractRefund);
                        if (!updateContractRefund)
                        {
                            throw new Exception("Can not update ContractRefund");
                        }

                        Payment payment = new Payment()
                        {
                            ContractId = contract.ContractId,
                            Purpose = PaymentPurpose.Refund,
                            CreatAt = DateTime.UtcNow,
                            Status = PaymentStatus.Complete,
                            Amount = contract.ContractRefund.Amount,
                            Type = "Online",
                        };

                        bool addPayment = await paymentRepository.AddPayment(payment);
                        if (!addPayment)
                        {
                            throw new Exception("Can not add payment");
                        }
                    }

                    foreach (ContractCharacter contractCharacter in contract.ContractCharacters)
                    {
                        Character character = await _characterRepository.GetCharacter(contractCharacter.CharacterId);
                        if (character != null)
                        {
                            character.Quantity += contractCharacter.Quantity;

                            bool checkUpdate = await _characterRepository.UpdateCharacter(character);
                            if (!checkUpdate)
                            {
                                throw new Exception("Can not update character");
                            }
                        }
                        else
                        {
                            throw new Exception("Character does not exist");
                        }
                    }
                }
                bool result = await _contractRespository.UpdateContract(contract);
                if (!result)
                {
                    return false;
                }

                if (contract.ContractStatus == ContractStatus.Deposited)
                {
                    bool checkAddContractCharacter = await contractCharacterService.AddListContractCharacter(contract);
                    if (!checkAddContractCharacter)
                    {
                        //await transaction.RollbackAsync();
                        throw new Exception("Cannot add ContractCharacter");
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

        public async Task<bool> UpdateDeliveryContract(DeliveryContractRequest deliveryContractRequest)
        {
            try
            {
                Contract contract = await _contractRespository.GetContractById(deliveryContractRequest.ContractId);
                List<ContractImage> images = new List<ContractImage>();

                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                if (contract.Request.ServiceId != "S001")
                {
                    throw new Exception("Request of this contract must be SOO1");
                }

                if (contract.ContractStatus != ContractStatus.Deposited)
                {
                    throw new Exception("Status of contract must be deposited");
                }

                if (deliveryContractRequest.Status.ToLower().Equals(DeliveryStatus.Delivering.ToString().ToLower()))
                {
                    if (contract.DeliveryStatus == DeliveryStatus.Preparing || contract.DeliveryStatus == DeliveryStatus.UnReceived)
                    {
                        if (deliveryContractRequest.Images != null)
                        {
                            contract.DeliveryStatus = DeliveryStatus.Delivering;

                            foreach (var imageCharacter in deliveryContractRequest.Images)
                            {
                                ContractImage contractImage = new ContractImage()
                                {
                                    ContractId = contract.ContractId,
                                    CreateDate = DateTime.Now,
                                    Status = ContractImageStatus.Delivering,
                                    UrlImage = await Image.UploadImageToFirebase(imageCharacter),
                                };

                                images.Add(contractImage);
                            }
                        }
                        else
                        {
                            throw new Exception("Please enter image of character in contract");
                        }
                    }
                    else
                    {
                        throw new Exception("Can not update status contract");
                    }
                }

                if (deliveryContractRequest.Status.ToLower().Equals(DeliveryStatus.UnReceived.ToString().ToLower()))
                {
                    if (contract.DeliveryStatus == DeliveryStatus.Delivering)
                    {
                        if (deliveryContractRequest.Reason != null)
                        {
                            contract.DeliveryStatus = DeliveryStatus.UnReceived;

                            ContractImage contractImage = new ContractImage()
                            {
                                ContractId = contract.ContractId,
                                CreateDate = DateTime.Now,
                                Reason = deliveryContractRequest.Reason,
                                Status = ContractImageStatus.Unreceived,
                            };

                            images.Add(contractImage);
                        }
                        else
                        {
                            throw new Exception("Please enter reason");
                        }
                    }
                    else
                    {
                        throw new Exception("Can not update status contract");
                    }
                }

                if (deliveryContractRequest.Status.ToLower().Equals(DeliveryStatus.Received.ToString().ToLower()))
                {
                    if (contract.DeliveryStatus == DeliveryStatus.Delivering)
                    {
                        if (deliveryContractRequest.Images != null)
                        {
                            contract.DeliveryStatus = DeliveryStatus.Received;

                            foreach (var imageCharacter in deliveryContractRequest.Images)
                            {
                                ContractImage contractImage = new ContractImage()
                                {
                                    ContractId = contract.ContractId,
                                    CreateDate = DateTime.Now,
                                    Status = ContractImageStatus.Received,
                                    UrlImage = await Image.UploadImageToFirebase(imageCharacter),
                                };

                                images.Add(contractImage);
                            }
                        }
                        else
                        {
                            throw new Exception("Please enter image of character in contract");
                        }
                    }
                    else
                    {
                        throw new Exception("Can not update contract");
                    }
                }

               

                if (deliveryContractRequest.Status.ToLower().Equals(DeliveryStatus.Refund.ToString().ToLower()))
                {
                    if (contract.DeliveryStatus == DeliveryStatus.Received)
                    {
                        if (deliveryContractRequest.Images != null)
                        {
                            contract.DeliveryStatus = DeliveryStatus.Refund;
                            contract.ContractStatus = ContractStatus.Refund;

                            foreach (var imageCharacter in deliveryContractRequest.Images)
                            {
                                ContractImage contractImage = new ContractImage()
                                {
                                    ContractId = contract.ContractId,
                                    CreateDate = DateTime.Now,
                                    Status = ContractImageStatus.Refund,
                                    UrlImage = await Image.UploadImageToFirebase(imageCharacter),
                                };

                                images.Add(contractImage);
                            }
                        }
                        else
                        {
                            throw new Exception("Please enter image of character in contract");
                        }
                    }
                    else
                    {
                        throw new Exception("Can not update status contract");
                    }
                }
                
                if (deliveryContractRequest.Status.ToLower().Equals(DeliveryStatus.Cancel.ToString().ToLower()))
                {
                    if (contract.DeliveryStatus == DeliveryStatus.Received || contract.DeliveryStatus == DeliveryStatus.Delivering || contract.DeliveryStatus == DeliveryStatus.UnReceived)
                    {
                        if (deliveryContractRequest.Reason != null)
                        {
                            contract.Amount = 0;
                            contract.ContractStatus = ContractStatus.Cancel;
                            contract.Reason = deliveryContractRequest.Reason;
                            contract.DeliveryStatus = DeliveryStatus.Cancel;
                        }
                        else
                        {
                            throw new Exception("Please enter reason");
                        }

                        ContractImage contractImage = new ContractImage()
                        {
                            ContractId = contract.ContractId,
                            CreateDate = DateTime.Now,
                            Reason = deliveryContractRequest.Reason,
                            Status = ContractImageStatus.Cancel,
                        };

                        images.Add(contractImage);
                    }
                    else
                    {
                        throw new Exception("Can not update status contract");
                    }
                }

                bool checkUpdate = await _contractRespository.UpdateContract(contract);

                if (!checkUpdate)
                {
                    throw new Exception("Can not update DeliveryContract");
                }

                if (images.Count > 0)
                {
                    bool checkAdd = await contractImageRepository.AddListContractImage(images);

                    if (!checkAdd)
                    {
                        throw new Exception("Can not add ContractImage");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContractResponse> GetContractByRequestCharacterId(string requestCharacterId)
        {
            try
            {
                RequestCharacter requestCharacter = await _requestCharacterRepository.GetRequestCharacterById(requestCharacterId);
                if (requestCharacter == null)
                {
                    throw new Exception("RequestCharacter does not exist");
                }

                if (requestCharacter.Request == null)
                {
                    throw new Exception("Request does not exist");
                }

                if (requestCharacter.Request.Contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                ContractResponse contractCharacterResponse = new ContractResponse()
                {
                    Amount = requestCharacter.Request.Contract.Amount,
                    ContractId = requestCharacter.Request.Contract.ContractId,
                    ContractName = requestCharacter.Request.Contract.ContractName,
                    CreateBy = requestCharacter.Request.Contract.CreateBy,
                    CreateDate = requestCharacter.Request.Contract.CreateDate?.ToString("dd/MM/yyyy"),
                    StartDate = requestCharacter.Request.StartDate.ToString("dd/MM/yyyy"),
                    EndDate = requestCharacter.Request.EndDate.ToString("dd/MM/yyyy"),
                    Deposit = requestCharacter.Request.Deposit,
                    Price = requestCharacter.Request.Contract.TotalPrice,
                    Reason = requestCharacter.Request.Contract.Reason,
                    RequestId = requestCharacter.Request.RequestId,
                    Status = requestCharacter.Request.Contract.ContractStatus.ToString(),
                    UrlPdf = requestCharacter.Request.Contract.UrlPdf,
                };

                if(requestCharacter.Request.Package != null)
                {
                    contractCharacterResponse.PackageName = requestCharacter.Request.Package.PackageName;
                }

                return contractCharacterResponse;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
