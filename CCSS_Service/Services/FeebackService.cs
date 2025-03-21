using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IFeedbackService
    {
        Task<bool> AddFeedback(List<FeedbackRequest> feedbackRequests, string accountId);
        Task<bool> UpdateFeedback(UpdateFeedbackRequest feedbackRequest, string accountId);
        Task<List<FeedbackResponse>> GetFeedbackByContractId(string contractId);
        Task<List<FeedbackResponse>> GetAllFeedback();
        Task<List<FeedbackResponse>> ViewFeedbackByCosplayerId(string cosplayerId);
        
    }
    public class FeebackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IContractRespository contractRespository;
        private readonly IAccountRepository _accountRepository;
        private readonly IContractCharacterRepository _contractCharacterRepository;
        private readonly IMapper mapper;

        public FeebackService(IMapper mapper, IContractCharacterRepository _contractCharacterRepository, IFeedbackRepository feedbackRepository, IContractRespository contractRespository, IAccountRepository accountRepository)
        {
            _feedbackRepository = feedbackRepository;
            this.contractRespository = contractRespository;
            _accountRepository = accountRepository;
            this._contractCharacterRepository = _contractCharacterRepository;
            this.mapper = mapper;
        }

        public async Task<bool> AddFeedback(List<FeedbackRequest> feedbackRequests, string accountId)
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
                    ContractCharacter contractCharacter = await _contractCharacterRepository.GetContractCharacterById(feedbackRequest.ContractCharacterId);
                    if (contractCharacter == null)
                    {
                        throw new Exception("ContractCharacter does not exist");
                    }
                    if(contractCharacter.Contract.ContractStatus != ContractStatus.Completed)
                    {
                        throw new Exception("Contract does not completed");
                    }
                    Feedback feedback = new Feedback()
                    {
                        AccountId = feedbackRequest.CosplayerId,
                        ContractCharacterId = feedbackRequest.ContractCharacterId,
                        CreateDate = DateTime.UtcNow,
                        CreateBy = account.AccountId,
                        Description = feedbackRequest.Description,
                        FeedbackId = Guid.NewGuid().ToString(),
                        Star = feedbackRequest.Star,
                        UpdateDate = null,
                    };

                    bool checkAdd = await _feedbackRepository.AddFeedback(feedback);

                    if (!checkAdd)
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

        public async Task<List<FeedbackResponse>> GetAllFeedback()
        {
            return mapper.Map<List<FeedbackResponse>>(await _feedbackRepository.GetAllFeedback());
        }

        public async Task<List<FeedbackResponse>> GetFeedbackByContractId(string contractId)
        {
            try
            {
                List<FeedbackResponse> feedbackResponses = new List<FeedbackResponse> ();
                Contract contract = await contractRespository.GetContractById(contractId);
                if(contract == null)
                {
                    throw new Exception("Contract does not exist");
                }
                if(contract.ContractStatus != ContractStatus.Completed)
                {
                    throw new Exception("Contract not completed");    
                }
                if (!contract.ContractCharacters.Any())
                {
                    throw new Exception("ContractCharacters do not exist");
                }
                if (contract.ContractCharacters.Any(cc => cc.Feedback != null))
                {
                    throw new Exception("This contract has not feedback");
                }

                foreach (var contractCharacter in contract.ContractCharacters)
                {
                    Feedback feedback = await _feedbackRepository.GetFeedbackByContractCharacterId(contractCharacter.ContractCharacterId);
                    if (feedback == null)
                    {
                        throw new Exception("Feedback does not exist");
                    }
                    FeedbackResponse response = new FeedbackResponse()
                    {
                        AccountId = feedback.AccountId,
                        Description = feedback.Description,
                        Star = feedback.Star,
                    };
                    feedbackResponses.Add(response);
                }
                return feedbackResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }

        public async Task<bool> UpdateFeedback(UpdateFeedbackRequest feedbackRequest, string accountId)
        {
            try
            {
                Account account = await _accountRepository.GetAccount(accountId);
                if (account == null)
                {
                    throw new Exception("Account does not exist");
                }

                Feedback feedback = await _feedbackRepository.GetFeedbackByFeedbackId(feedbackRequest.FeedbackId);
                if (feedback == null)
                {
                    throw new Exception("Feedback does not exist");
                }

                feedback.Star = feedbackRequest.Star;
                feedback.Description = feedbackRequest.Description;

                bool checkUpdate = await _feedbackRepository.UpdateFeedback(feedback);

                if (!checkUpdate)
                {
                    throw new Exception("Can not update feedback");
                }

                List<Feedback> feedbacks = await _feedbackRepository.GetAllFeedbacksByCosplayerId(feedback.AccountId);

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

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FeedbackResponse>> ViewFeedbackByCosplayerId(string cosplayerId)
        {
            return mapper.Map<List<FeedbackResponse>>(await _feedbackRepository.GetAllFeedbacksByCosplayerId(cosplayerId));
        }
    }
}
