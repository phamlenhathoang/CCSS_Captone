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
        Task<bool> AddFeedback(List<FeedbackRequest> feedbackRequests, string accountId, string contractId);
        Task<bool> UpdateFeedback(UpdateFeedbackRequest feedbackRequest, string accountId);
        Task<List<FeedbackResponse>> GetFeedbackByContractId(string contractId);
        Task<List<FeedbackResponse>> GetAllFeedback();
        Task<List<FeedbackResponse>> GetFeedbackByCosplayerId(string cosplayerId);
        Task<FeedbackResponse> GetFeedbackByFeedbackId(string feedbackId);
        
    }
    public class FeebackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IContractRespository contractRespository;
        private readonly IAccountRepository _accountRepository;
        private readonly IContractCharacterRepository _contractCharacterRepository;
        private readonly IMapper mapper;
        private readonly IBeginTransactionRepository _beginTransactionRepository;

        public FeebackService(IMapper mapper, IContractCharacterRepository _contractCharacterRepository, IFeedbackRepository feedbackRepository, IContractRespository contractRespository, IAccountRepository accountRepository, IBeginTransactionRepository beginTransactionRepository)
        {
            _feedbackRepository = feedbackRepository;
            this.contractRespository = contractRespository;
            _accountRepository = accountRepository;
            this._contractCharacterRepository = _contractCharacterRepository;
            this.mapper = mapper;
            _beginTransactionRepository = beginTransactionRepository;
        }

        public async Task<bool> AddFeedback(List<FeedbackRequest> feedbackRequests, string accountId, string contractId)
        {
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                try
                {
                    Account account = await _accountRepository.GetAccount(accountId);
                    if (account == null)
                    {
                        throw new Exception("Account does not exist");
                    }

                    if (account.Role.RoleName != RoleName.Customer)
                    {
                        throw new Exception("Account must be customer");
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
                        
                        ContractCharacter contractCharacter = await _contractCharacterRepository.GetContractCharacterById(feedbackRequest.ContractCharacterId);
                        if (contractCharacter == null)
                        {
                            throw new Exception("ContractCharacter does not exist");
                        }

                        Account cosplayer = await _accountRepository.GetAccountByAccountId(contractCharacter.CosplayerId);
                        if (cosplayer == null)
                        {
                            throw new Exception("Cosplayer does not exist");
                        }

                        if (contractCharacter.Contract.ContractStatus != ContractStatus.Completed)
                        {
                            throw new Exception("StatusContract must be completed");
                        }
                        if (!contractCharacter.Contract.Request.AccountId.ToLower().Equals(accountId.ToLower()))
                        {
                            throw new Exception("Account must be create contract");
                        }
                        if (!contractCharacter.Contract.ContractId.ToLower().Equals(contractId.ToLower()))
                        {
                            throw new Exception("ContractCharacter does not belong contract");
                        }   
                        Feedback checkExist = await _feedbackRepository.GetFeedbackByContractCharacterId(feedbackRequest.ContractCharacterId);
                        if (checkExist != null)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception("ContractCharacter does exist");
                        }

                        Feedback feedback = new Feedback()
                        {
                            AccountId = contractCharacter.CosplayerId,
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
                            await transaction.RollbackAsync();
                            throw new Exception("Can not add feedback");
                        }

                        List<Feedback> feedbacks = await _feedbackRepository.GetAllFeedbacksByCosplayerId(contractCharacter.CosplayerId);

                        if (!feedbacks.Any())
                        {
                            await transaction.RollbackAsync();
                            throw new Exception("CosplayerId does not exist");
                        }

                        int count = 0;
                        int totalStar = 0;

                        foreach (var fb in feedbacks)
                        {
                            count++;
                            totalStar += (int)fb.Star;
                        }

                        decimal avgStar = ((decimal)totalStar + (decimal)(cosplayer.AverageStar ?? 0)) / (count + 1);
                        cosplayer.AverageStar = (double)Math.Floor(avgStar * 10) / 10;

                        bool result = await _accountRepository.UpdateAccount(cosplayer);

                        if (!result)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception("Can not update average star of cosplayer");
                        }
                    }

                    contract.ContractStatus = ContractStatus.Feedbacked;
                    bool checkUpdate = await contractRespository.UpdateContract(contract);

                    if (!checkUpdate)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("Can not update status contract");
                    }

                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
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
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
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
                    if (feedback.Account == null)
                    {
                        throw new Exception("Cosplayer does not exist");
                    }

                    feedback.Star = feedbackRequest.Star;
                    feedback.Description = feedbackRequest.Description;

                    bool checkUpdate = await _feedbackRepository.UpdateFeedback(feedback);

                    if (!checkUpdate)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("Can not update feedback");
                    }

                    List<Feedback> feedbacks = await _feedbackRepository.GetAllFeedbacksByCosplayerId(feedback.AccountId);

                    if (!feedbacks.Any())
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("CosplayerId does not exist");
                    }

                    int count = 0;
                    int totalStar = 0;

                    foreach (var fb in feedbacks)
                    {
                        count++;
                        totalStar += (int)fb.Star;
                    }

                    decimal avgStar = ((decimal)totalStar + (decimal)(feedback.Account.AverageStar ?? 0)) / (count + 1);
                    feedback.Account.AverageStar = (double)Math.Floor(avgStar * 10) / 10;

                    bool result = await _accountRepository.UpdateAccount(feedback.Account);

                    if (!result)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("Can not update average star of cosplayer");
                    }

                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<List<FeedbackResponse>> GetFeedbackByCosplayerId(string cosplayerId)
        {
            return mapper.Map<List<FeedbackResponse>>(await _feedbackRepository.GetAllFeedbacksByCosplayerId(cosplayerId));
        }

        public async Task<FeedbackResponse> GetFeedbackByFeedbackId(string feedbackId)
        {
            return mapper.Map<FeedbackResponse>(await _feedbackRepository.GetFeedbackByFeedbackId(feedbackId));
        }
    }
}
