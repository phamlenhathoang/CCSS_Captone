using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IFeedbackService
    {
        Task<bool> AddFeedback(List<FeedbackRequest> feedbackRequests, string accountId, string contractId);
    }
    public class FeebackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IContractRespository contractRespository;
        private readonly IAccountRepository _accountRepository;

        public FeebackService(IFeedbackRepository feedbackRepository, IContractRespository contractRespository, IAccountRepository accountRepository)
        {
            _feedbackRepository = feedbackRepository;
            this.contractRespository = contractRespository;
            _accountRepository = accountRepository;
        }

        public async Task<bool> AddFeedback(List<FeedbackRequest> feedbackRequests, string accountId, string contractId)
        {
            try
            {
                var uniqueElements = new HashSet<string>();

                foreach (var feedbackRequest in feedbackRequests)
                {
                    bool checkAccount = uniqueElements.Add(feedbackRequest.CosplayerId);

                    if (!checkAccount)
                    {
                        throw new Exception("Cosplayer is duplicate");
                    }
                }

                Account account = await _accountRepository.GetAccount(accountId);

                if (account == null)
                {
                    throw new Exception("Account does not exist");
                }

                Contract contract = await contractRespository.GetContractById(contractId);
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                if (!feedbackRequests.Any())
                {
                    throw new Exception("FeedbackRequests are null");
                } 

                foreach (var feedbackRequest in feedbackRequests)
                {
                    Account cosplayer = await _accountRepository.GetAccountByAccountId(feedbackRequest.CosplayerId);
                    if (cosplayer == null)
                    {
                        throw new Exception("Cosplayer does not exist");
                    }
                    Feedback feedback = new Feedback()
                    {
                        AccountId = feedbackRequest.CosplayerId,
                        ContractId = contractId,
                        CreateDate = DateTime.UtcNow,   
                        CreateBy = account.AccountId,
                        Description = feedbackRequest.Description,
                        FeedbackId = Guid.NewGuid().ToString(),
                        Star = feedbackRequest.Star,
                        UpdateDate = null,
                    };
                    
                    bool checkAdd = await _feedbackRepository.AddFeedback(feedback);

                    if (checkAdd)
                    {
                        throw new Exception("Can not add feedback");
                    }

                    List<Feedback> feedbacks = await _feedbackRepository.GetAllFeedbacksByCosplayerId(feedbackRequest.CosplayerId);

                    if (!feedbacks.Any())
                    {
                        throw new Exception("CosplayerId does not exist");
                    }

                    int count = 0;
                    int totalStar = 0;

                    foreach (var fb in feedbacks)
                    {
                        count++;
                        totalStar += (int)fb.Star;
                    }

                    account.AverageStar = totalStar / count;

                    bool result = await _accountRepository.UpdateAccount(account);

                    if (!result) 
                    {
                        throw new Exception("Can not update average star of cosplayer");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
