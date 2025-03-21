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
        Task<bool> UpdateStatusContract(string contractId, string status);
        Task<bool> DeleteContract(string contractId, string reason);   
        Task<List<ContractResponse>> GetContract(string? contractName, string? contractStatus, string? startDate, string? endDate,string? accountId, string? contractId);
    }
    public class ContractServices : IContractServices
    {
        private readonly IContractRespository _contractRespository;
        private readonly IContractCharacterRepository _contractCharacterRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IRequestRepository _requestRepository;
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


        public ContractServices(IMapper mapper, IPackageRepository packageRepository, IContractCharacterService contractCharacterService, INotificationRepository notificationRepository, IHubContext<NotificationHub> hubContext, IAccountRepository _accountRepository, IServiceRepository _serviceRepository, Image Image, IPdfService pdfService, IAccountCouponRepository accountCouponRepository, IRequestRepository _requestRepository, IContractRespository _contractRespository, IContractCharacterRepository contractCharacterRepository, ICharacterRepository characterRepository)
        {
            this._contractRespository = _contractRespository;
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
        }
        //private string GenerateCode(int length = 6)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    Random random = new Random();

        //    string code = new string(Enumerable.Repeat(chars, length)
        //        .Select(s => s[random.Next(s.Length)]).ToArray());

        //    return code;
        //}

        //#region UploadImageToFirebase
        //public async Task<string> UploadImageToFirebase(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        throw new Exception("File không hợp lệ");
        //    }

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(memoryStream);
        //        var bytes = memoryStream.ToArray();

        //        // Initialize Firebase Admin SDK
        //        var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile("CCSS.json");
        //        var storage = StorageClient.Create(credential);

        //        // Construct the object name (path) in Firebase Storage
        //        var objectName = $"images/{DateTime.Now.Ticks}_{file.FileName}";

        //        // Upload the file to Firebase Storage
        //        var response = await storage.UploadObjectAsync(
        //            bucket: _bucketName,
        //            objectName: objectName,
        //            contentType: file.ContentType,
        //            source: new MemoryStream(bytes)
        //        );

        //        // Return the download URL
        //        var downloadUrl = $"https://storage.googleapis.com/{_bucketName}/{objectName}";
        //        return downloadUrl;
        //    }
        //}

        //#endregion

        //public async Task<List<Request>> GetAllContract(string? searchterm)
        //{
        //    return await _respository.GetAllContract(searchterm);
        //}

        //public async Task<Request> GetContract(string id)
        //{
        //    return await _respository.GetContractById(id);
        //}

        //public async Task<string> DeleteContract(string contractId)
        //{
        //    var contract = await _respository.GetContractById(contractId);
        //    if (contract == null)
        //    {
        //        return "This Contract is not found";
        //    }
        //    else
        //    {
        //        var result = await _respository.DeleteContract(contract);
        //        return result ? "Delete Success" : "Delete Failed";
        //    }
        //}

        //public async Task<string> AddContract(ContractRequest contractRequest)
        //{
        //    string Code = GenerateCode();
        //    DateTime StartDate = DateTime.Now;
        //    DateTime EndDate = DateTime.Now;
        //    if (!string.IsNullOrEmpty(contractRequest.StartDate) || !string.IsNullOrEmpty(contractRequest.EndDate))
        //    {
        //        string[] dateFormats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };

        //        bool isValidDate = DateTime.TryParseExact(contractRequest.StartDate, dateFormats,
        //                                                  System.Globalization.CultureInfo.InvariantCulture,
        //                                                  System.Globalization.DateTimeStyles.None,
        //                                                  out StartDate);


        //        bool isValidEndDate = DateTime.TryParseExact(contractRequest.EndDate, dateFormats,
        //                                                  System.Globalization.CultureInfo.InvariantCulture,
        //                                                  System.Globalization.DateTimeStyles.None,
        //                                                  out EndDate);
        //        if (!isValidDate || !isValidEndDate)
        //        {
        //            return "Date format is incorrect. Please enter the date in the format dd/MM/yyyy, d/MM/yyyy, dd/M/yyyy, d/M/yyyy.";
        //        }
        //        if (StartDate < DateTime.Now.Date)
        //        {
        //            return "Start date cannot be in the past.";
        //        }

        //        if (EndDate < DateTime.Now.Date)
        //        {
        //            return "End date cannot be in the past.";
        //        }

        //        if (StartDate > EndDate)
        //        {
        //            return "End date must be greater than event date.";
        //        }
        //    }
        //    if (contractRequest == null)
        //    {
        //        return "contract is null";
        //    }
        //    var downloadUrl = await UploadImageToFirebase(contractRequest.UrlImage);
        //    var newContract = new Contract()
        //    {
        //        ContractId = Guid.NewGuid().ToString(),
        //        AccountId = contractRequest.AccountId,
        //        PackageId = contractRequest.PackageId,
        //        ContractName = contractRequest.ContractName,
        //        ContractCode = Code,
        //        Description = contractRequest.Description,
        //        Price = contractRequest.Price,
        //        Amount = contractRequest.Amount,
        //        Location = contractRequest.Location,
        //        Signature = false,
        //        Deposit = contractRequest.Deposit,
        //        Status = ContractStatus.Pending,
        //        StartDate = StartDate,
        //        EndDate = EndDate,
        //        ImageUrl = downloadUrl,
        //    };
        //    var result = await _respository.AddContract(newContract);
        //    if (!result)
        //    {
        //        return "Add Contract Failed";
        //    }

        //    if (contractRequest.contractCharacterRequests != null && contractRequest.contractCharacterRequests.Any())
        //    {
        //        var characterInContract = contractRequest.contractCharacterRequests.Select(c => new RequestCharacter
        //        {
        //            ContractCharacterId = Guid.NewGuid().ToString(),
        //            ContracId = newContract.ContractId,
        //            CharacterId = c.CharacterId,
        //            Quantity = c.Quantity,
        //        }).ToList();

        //        var charactersAdded = await _contractCharacterRepository.AddListCharacterInContract(characterInContract);
        //        if (!charactersAdded)
        //            return "Failed to add characters.";

        //        newContract.CharacterQuantity = await _contractCharacterRepository.CountCharactersInContractAsync(newContract.ContractId);
        //        await _respository.UpdateContract(newContract);
        //    }

        //    return "Contract and Characters added successfully.";
        //}

        //public async Task<string> UpdateContract(string contractId, ContractResponse contractResponse)
        //{
        //    var contractExicting = await _respository.GetContractById(contractId);
        //    if (contractExicting == null)
        //    {
        //        return "Contract is not found";
        //    }
        //    contractExicting.PackageId = contractResponse.PackageId;
        //    contractExicting.ContractName = contractResponse.ContractName;
        //    contractExicting.Description = ContractDescription.CreateEvent;
        //    contractExicting.Price = contractResponse.Price;
        //    contractExicting.Amount = contractResponse.Amount;
        //    contractExicting.Signature = contractResponse.Signature;
        //    contractExicting.Deposit = contractResponse.Deposit;
        //    contractExicting.Status = contractResponse.Status;
        //    contractExicting.EndDate = DateTime.Now;

        //    var result = await _respository.UpdateContract(contractExicting);
        //    return result ? "Update Success" : "Update Failed";
        //}

        //public async Task<string> UpdateStatusContract(string contracId, ContractStatus newStatus)
        //{
        //    var contract = await _respository.GetContractById(contracId);
        //    if (contract == null)
        //    {
        //        return "Contract is not found";
        //    }
        //    switch (contract.Status)
        //    {
        //        case ContractStatus.Pending:

        //            if (newStatus != ContractStatus.Browsed && newStatus != ContractStatus.Cancel)
        //            {
        //                return "Pending contracts can only be changed to Browsed or Canceled.";
        //            }
        //            contract.Status = newStatus;
        //            await _respository.UpdateContract(contract);
        //            break;
        //        case ContractStatus.Browsed:
        //            if (newStatus != ContractStatus.Progressing && newStatus != ContractStatus.Cancel)
        //            {
        //                return "Browsed contracts can only be changed to Progressing or Canceled.";
        //            }
        //            contract.Status = newStatus;
        //            await _respository.UpdateContract(contract);
        //            break;
        //        case ContractStatus.Progressing:
        //            if (newStatus != ContractStatus.Completed & newStatus != ContractStatus.Cancel)
        //            {
        //                return "Progressing contracts can only be changed to Completed or Canceled.";
        //            }
        //            contract.Status = newStatus;
        //            await _respository.UpdateContract(contract);
        //            break;
        //        default:
        //            break;
        //    }

        //    return $"Update status {newStatus} of contract is completed";
        //}
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

                if(request.Contract != null)
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
            catch(Exception ex) 
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
                    if (contract.Request.PackageId != null)
                    {
                        package = await packageRepository.GetPackage(contract.Request.PackageId);
                        if (package == null)
                        {
                            throw new Exception("Package does not exist");
                        }
                    }

                    ContractResponse crsItem = new ContractResponse()
                    {
                        Amount = (double)contract.Amount,
                        ContractName = contract.ContractName,
                        Deposit = contract.Deposit,
                        EndDate = contract.Request.EndDate.ToString("HH:mm dd/MM/yyyy"),
                        StartDate = contract.Request.StartDate.ToString("HH:mm dd/MM/yyyy"),
                        PackageName = package.PackageName,
                        Price = (double)contract.TotalPrice,
                        Status = contract.ContractStatus.ToString(),
                        Reason = contract.Reason,
                    };

                    foreach (var contractCharacter in contract.ContractCharacters)
                    {
                        Account account = new Account();
                        if (contractCharacter.CosplayerId != null)
                        {
                            account = await _accountRepository.GetAccount(contractCharacter.CosplayerId);
                            if(account == null)
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
                }

                return crs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateStatusContract(string contractId, string status)
        {
            try
            {
                Contract contract = await _contractRespository.GetContractById(contractId);
                if (contract == null)
                {
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
                        throw new Exception("Can not update contract status");
                    }
                }
                if (status.ToUpper() == ContractStatus.Completed.ToString().ToUpper())
                {
                    if (contract.ContractStatus == ContractStatus.Progressing)
                    {
                        contract.ContractStatus = ContractStatus.Completed;
                    }
                    else
                    {
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
                        throw new Exception("Cannot add ContractCharacter");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
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
