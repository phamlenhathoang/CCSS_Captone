using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = CCSS_Repository.Entities.Contract;

namespace CCSS_Service.Services
{
    public interface IPaymentService
    {
        Task<List<PaymentResponse>> GetAllPayment();
        Task<List<PaymentResponse>> GetAllPaymentByContractId(string contracId);
        Task<List<PaymentResponse>> GetAllPaymentByAccountIdAndPurpose(string accountId, string? purpose);
        Task<PaymentResponse> GetPaymentByPaymentId(string paymentId);
    }
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IContractRespository contractRespository;

        public PaymentService(IPaymentRepository paymentRepository, IContractRespository contractRespository)
        {
            this.paymentRepository = paymentRepository;
            this.contractRespository = contractRespository;
        }
        public async Task<List<PaymentResponse>> GetAllPayment()
        {
            try
            {
                List<PaymentResponse> paymentResponses = new List<PaymentResponse> { };
                List<Payment> payments = await paymentRepository.GetAllPayment();

                if (payments.Count > 0)
                {
                    foreach (Payment payment in payments)
                    {
                        PaymentResponse paymentResponse = new PaymentResponse()
                        {
                            Amount = payment.Amount,
                            CreatAt = payment.CreatAt?.ToString("dd/MM/yyyy"),
                            PaymentId = payment.PaymentId,
                            Purpose = payment.Purpose.ToString(),
                            Status = payment.Status.ToString(),
                            TransactionId = payment.TransactionId,
                            Type = payment.Type,
                        };
                        paymentResponses.Add(paymentResponse);
                    }
                }

                return paymentResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PaymentResponse>> GetAllPaymentByAccountIdAndPurpose(string accountId, string? purpose)
        {
            try
            {
                List<PaymentResponse> paymentResponses = new List<PaymentResponse>();
                List<Contract> contracts = await contractRespository.GetAllContractByAccountId(accountId);
                if (contracts.Count > 0)
                {
                    foreach(Contract contract in contracts)
                    {
                        List<Payment> payments = await paymentRepository.GetAllPaymentByAccountIdAndPurpose(contract.ContractId, purpose); 
                        if(payments.Count > 0)
                        {
                            foreach (Payment payment in payments)
                            {
                                PaymentResponse paymentResponse = new PaymentResponse()
                                {
                                    Amount = payment.Amount,
                                    CreatAt = payment.CreatAt?.ToString("dd/MM/yyyy"),
                                    PaymentId = payment.PaymentId,
                                    Purpose = payment.Purpose.ToString(),
                                    Status = payment.Status.ToString(),
                                    TransactionId = payment.TransactionId,
                                    Type = payment.Type,
                                };
                                paymentResponses.Add(paymentResponse);
                            }
                        }
                    }
                }
                return paymentResponses;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PaymentResponse>> GetAllPaymentByContractId(string contracId)
        {
            try
            {
                List<PaymentResponse> paymentResponses = new List<PaymentResponse> { };
                List<Payment> payments = await paymentRepository.GetAllPaymentByContractId(contracId);

                if (payments.Count > 0)
                {
                    foreach(Payment payment in payments)
                    {
                        PaymentResponse paymentResponse = new PaymentResponse()
                        {
                            Amount = payment.Amount,
                            CreatAt = payment.CreatAt?.ToString("dd/MM/yyyy"),
                            PaymentId = payment.PaymentId,  
                            Purpose = payment.Purpose.ToString(),
                            Status = payment.Status.ToString(),
                            TransactionId = payment.TransactionId,
                            Type = payment.Type,
                        };
                        paymentResponses.Add(paymentResponse);
                    }
                }

                return paymentResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaymentResponse> GetPaymentByPaymentId(string paymentId)
        {
            try
            {
                Payment payment = await paymentRepository.GetPayment(paymentId);
                if(payment == null)
                {
                    throw new Exception("Payment does not exist");
                }
                PaymentResponse paymentResponse = new PaymentResponse()
                {
                    Amount = payment.Amount,
                    CreatAt = payment.CreatAt?.ToString("dd/MM/yyyy"),
                    PaymentId = payment.PaymentId,
                    Purpose = payment.Purpose.ToString(),
                    Status = payment.Status.ToString(),
                    TransactionId = payment.TransactionId,
                    Type = payment.Type,
                };

                return paymentResponse;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
