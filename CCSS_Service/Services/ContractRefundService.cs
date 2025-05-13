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
        Task<ContractRefundResponse> GetContractRefundByContractRefundId(string contractRefundId);
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

                ContractRefund contractRefund = new ContractRefund()
                {
                    Price = contractRefundRequest.Price,
                    ContractId = contractRefundRequest.ContractId,
                    Amount = contract.Amount - contractRefundRequest.Price,
                    Description = contractRefundRequest.Description,   
                    CreateDate = DateTime.Now,
                    Status = ContractRefundStatus.Pending,
                };

                if (contractRefund.Amount > 0)
                {
                    contractRefund.Type = Type.SystemRefund;
                }

                if (contractRefund.Amount == 0)
                {
                    contractRefund.Type = Type.DepositRetained;
                }


                bool result = await contractRefundRepository.AddContractRefund(contractRefund);
                if (!result)
                {
                    throw new Exception("Can not add ContractRefund");
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

        public async Task<ContractRefundResponse> GetContractRefundByContractRefundId(string contractRefundId)
        {
            try
            {
                ContractRefund contractRefund = await contractRefundRepository.GetContractRefundByContractRefundId(contractRefundId);
                if (contractRefund == null)
                {
                    throw new Exception("ContractRefund does not exist");
                }

                var contractRefundResponse = new ContractRefundResponse()
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

                return contractRefundResponse;
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
                contractRefund.Price = contractRefundRequest.Price;
                contractRefund.Amount = contract.Amount - contractRefundRequest.Price;
                if (contractRefund.Amount > 0)
                {
                    contractRefund.Type = Type.SystemRefund;
                }

                if (contractRefund.Amount == 0)
                {
                    contractRefund.Type = Type.DepositRetained;
                }

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
