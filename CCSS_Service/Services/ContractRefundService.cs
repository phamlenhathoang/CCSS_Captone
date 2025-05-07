using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = CCSS_Repository.Entities.Contract;
using Type = CCSS_Repository.Entities.Type;

namespace CCSS_Service.Services
{
    public interface IContractRefundService
    {
        Task<bool> AddContractRefund(ContractRefundRequest contractRefundRequest);
        Task<bool> UpdateContractRefund(string contractRefundId, UpdateContractRefundRequest contractRefundRequest);
        Task<ContractRefundResponse> GetContractRefundByContractId(string contractId);
        Task<List<ContractRefundResponse>> GetAllContractRefund();
    }
    public class ContractRefundService : IContractRefundService
    {
        private readonly IContractRefundRepository contractRefundRepository;
        private readonly IContractRespository contractRepository;
        private readonly IContractImageRepository contractImageRepository;

        public ContractRefundService(IContractRefundRepository contractRefundRepository, IContractRespository contractRepository, IContractImageRepository contractImageRepository)
        {
            this.contractRefundRepository = contractRefundRepository;
            this.contractRepository = contractRepository;
            this.contractImageRepository = contractImageRepository;
        }
        public async Task<bool> AddContractRefund(ContractRefundRequest contractRefundRequest)
        {
            try
            {
                Contract contract = await contractRepository.GetContractById(contractRefundRequest.ContractId);
                Image image = new Image();
                if (contract == null)
                {
                    throw new Exception("Contract doest not exist");
                }

                if(contract.Request == null)
                {
                    throw new Exception("Request of this contract does not exist");
                }

                if (contract.ContractStatus != ContractStatus.Refund)
                {
                    throw new Exception("Status of contract must be refund");
                }

                if (contract.ContractRefund == null)
                {
                    ContractRefund contractRefund = new ContractRefund()
                    {
                        ContractId = contractRefundRequest.ContractId,
                        CreateDate = DateTime.Now,
                        Description = contractRefundRequest.Description,
                        Price = contractRefundRequest.Price,   
                        Amount = contract.Amount - contractRefundRequest.Price,
                    };

                    if(contractRefund.Amount > 0)
                    {
                        contractRefund.Type = Type.SystemRefund;
                        contractRefund.Status = ContractRefundStatus.Pending;
                        
                    }

                    if (contractRefund.Amount < 0)
                    {
                        contractRefund.Type = Type.CustomerRefund;
                        contractRefund.Status = ContractRefundStatus.Pending;
                    }

                    if (contractRefund.Amount == 0)
                    {
                        contractRefund.Type = Type.DepositRetained;
                        contractRefund.Status = ContractRefundStatus.Paid;
                    }

                    bool checkAdd = await contractRefundRepository.AddContractRefund(contractRefund);
                    if (!checkAdd)
                    {
                        throw new Exception("Can not add ContractRefund");
                    }
                }
                else
                {
                    contract.ContractRefund.Price += contractRefundRequest.Price;
                    contract.ContractRefund.Description = contract.ContractRefund.Description + ", " + contractRefundRequest.Description;
                    contract.ContractRefund.UpdateDate = DateTime.Now;
                    contract.ContractRefund.Amount -= contractRefundRequest.Price; 

                    if (contract.ContractRefund.Amount > 0)
                    {
                        contract.ContractRefund.Type = Type.SystemRefund;
                        contract.ContractRefund.Status = ContractRefundStatus.Pending;
                    }

                    if (contract.ContractRefund.Amount < 0)
                    {
                        contract.ContractRefund.Type = Type.CustomerRefund;
                        contract.ContractRefund.Status = ContractRefundStatus.Pending;
                    }

                    if (contract.ContractRefund.Amount == 0)
                    {
                        contract.ContractRefund.Type = Type.DepositRetained;
                        contract.ContractRefund.Status = ContractRefundStatus.Paid;

                    }

                    bool check = await contractRefundRepository.UpdateContractRefund(contract.ContractRefund);
                    if (!check)
                    {
                        throw new Exception("Can not update ContractRefund");
                    }
                }

                bool checkUpdate = await contractRepository.UpdateContract(contract);
                if (!checkUpdate)
                {
                    throw new Exception("Can not update contract");
                }

                if (contractRefundRequest.Images.Count > 0)
                {
                    List<ContractImage> contractImages = new List<ContractImage>();
                    foreach (var contractImageRequest in contractRefundRequest.Images)
                    {
                        var contractImage = new ContractImage()
                        {
                            ContractId = contract.ContractId,
                            CreateDate = DateTime.Now,
                            Status = ContractImageStatus.Check,
                            UrlImage = await image.UploadImageToFirebase(contractImageRequest),
                        };
                        contractImages.Add(contractImage);
                    }

                    bool checkAddImage = await contractImageRepository.AddListContractImage(contractImages);
                    if (!checkAddImage)
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

        public async Task<List<ContractRefundResponse>> GetAllContractRefund()
        {
            List<ContractRefund> contractRefunds = await contractRefundRepository.GetAllContractRefund();

            List<ContractRefundResponse> contractRefundResponses = new List<ContractRefundResponse>();

            if(contractRefunds.Count > 0)
            {
                foreach(ContractRefund contractRefund in contractRefunds)
                {
                    ContractRefundResponse contractRefundResponse = new ContractRefundResponse()
                    {
                        AccountBankName = contractRefund.AccountBankName,
                        BankName = contractRefund.BankName,
                        ContractId = contractRefund.ContractId,
                        ContractRefundId = contractRefund.ContractRefundId,
                        CreateDate = contractRefund.CreateDate?.ToString("dd/MM/YYYY") ?? null,
                        UpdateDate = contractRefund.UpdateDate?.ToString("dd/MM/YYYY") ?? null,
                        Description = contractRefund.Description,
                        NumberBank = contractRefund.NumberBank,
                        Type = contractRefund.Type.ToString(),
                        Status = contractRefund.Status.ToString(),
                        Price = contractRefund.Price,
                    };
                    contractRefundResponses.Add(contractRefundResponse);
                }
            }

            return contractRefundResponses;
        }

        public async Task<ContractRefundResponse> GetContractRefundByContractId(string contractId)
        {
            try
            {
                Contract contract = await contractRepository.GetContractById(contractId);
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                if(contract.ContractRefund == null)
                {
                    throw new Exception("ContractRefund does not exist");
                }

                var contractRefund = new ContractRefundResponse()
                {
                    AccountBankName = contract.ContractRefund.AccountBankName,
                    BankName = contract.ContractRefund.BankName,
                    ContractId = contract.ContractRefund.ContractId,
                    ContractRefundId = contract.ContractRefund.ContractRefundId,
                    CreateDate = contract.ContractRefund.CreateDate?.ToString("dd/MM/YYYY") ?? null,
                    UpdateDate = contract.ContractRefund.UpdateDate?.ToString("dd/MM/YYYY") ?? null,
                    Description = contract.ContractRefund.Description,
                    NumberBank = contract.ContractRefund.NumberBank,
                    Type = contract.ContractRefund.Type.ToString(),
                    Status = contract.ContractRefund.Status.ToString(),
                    Price = contract.ContractRefund.Price,
                };

                return contractRefund;  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateContractRefund(string contractRefundId, UpdateContractRefundRequest contractRefundRequest)
        {
            try
            {
                ContractRefund contractRefund = await contractRefundRepository.GetContractRefundByContractRefundId(contractRefundId);
                if (contractRefund == null)
                {
                    throw new Exception("ContractRefund does not exist");
                }

                Contract contract = await contractRepository.GetContractById(contractRefundRequest.ContractId);
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                contractRefund.UpdateDate = DateTime.Now;
                contractRefund.ContractId = contract.ContractId;
                contractRefund.AccountBankName = contractRefundRequest.AccountBankName;
                contractRefund.BankName = contractRefundRequest.BankName;
                if (contractRefundRequest.Type.ToLower().Equals(Type.DepositRetained.ToString().ToLower()))
                {
                    contractRefund.Type = Type.DepositRetained;
                }

                if (contractRefundRequest.Type.ToLower().Equals(Type.CustomerRefund.ToString().ToLower()))
                {
                    contractRefund.Type = Type.CustomerRefund;
                }

                if (contractRefundRequest.Type.ToLower().Equals(Type.SystemRefund.ToString().ToLower()))
                {
                    contractRefund.Type = Type.SystemRefund;
                }

                contractRefund.Price = contractRefundRequest.Price;

                bool result = await contractRefundRepository.UpdateContractRefund(contractRefund);
                if (!result)
                {
                    throw new Exception("Can not update ContractRefund");
                }

                return result;  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
