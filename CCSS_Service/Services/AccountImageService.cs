using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IAccountImageService
    {
        Task<AccountImageResponse> GetAccountImageById(string id);
        Task<List<AccountImageResponse>> GetAccountImageByAccountId(string id);
    }
    public class AccountImageService : IAccountImageService
    {
        private readonly IAccountImageRepository _accountImageRepository;

        public AccountImageService(IAccountImageRepository accountImageRepository)
        {
            _accountImageRepository = accountImageRepository;
        }

        public async Task<List<AccountImageResponse>> GetAccountImageByAccountId(string id)
        {
            try
            {
                List<AccountImageResponse> accountImageResponses = new List<AccountImageResponse>();
                var accountImages = await _accountImageRepository.GetListAccountImagesByAccountId(id);
                foreach (var accountImage in accountImages)
                {
                    var accountImageResponse = new AccountImageResponse()
                    {
                        AccountImageId = accountImage.AccountImageId,
                        CreateDate = accountImage.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                        UpdateDate = accountImage.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                        IsAvatar = accountImage.IsAvatar,
                        UrlImage = accountImage.UrlImage,
                    };
                    accountImageResponses.Add(accountImageResponse);
                }
                return accountImageResponses;   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountImageResponse> GetAccountImageById(string id)
        {
            try
            {
                var accountImage = await _accountImageRepository.GetAccountImageById(id);
                AccountImageResponse accountImageResponse = new AccountImageResponse()
                {
                    AccountImageId = accountImage.AccountImageId,
                    CreateDate = accountImage.CreateDate?.ToString("HH:mm dd/MM/yyyy"),
                    UpdateDate = accountImage.UpdateDate?.ToString("HH:mm dd/MM/yyyy"),
                    IsAvatar = accountImage.IsAvatar,
                    UrlImage = accountImage.UrlImage,
                };
                return accountImageResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
