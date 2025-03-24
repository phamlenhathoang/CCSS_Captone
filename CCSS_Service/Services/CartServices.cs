using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{
    public interface ICartServices
    {
        Task<Cart> GetCartById(string id);
        Task<Cart> GetCartByAccount(string accountId);
        Task<string> AddCart(CartRequest cartRequest);
    }

    public class CartServices: ICartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly IAccountRepository _accountRepository;

        public CartServices(ICartRepository cartRepository, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Cart> GetCartById(string id)
        {
            return await _cartRepository.GetCartById(id);
        }

        public async Task<Cart> GetCartByAccount(string accountId)
        {
            return await _cartRepository.GetcartByAccount(accountId);
        }

        public async Task<string> AddCart(CartRequest cartRequest)
        {
            var account = await _accountRepository.GetAccount(cartRequest.AccountId);
            if (account == null)
            {
                return "Account not found";
            }
            if(account.RoleId != "R005")
            {
                return "You must be a customer ";
            }
            if(cartRequest == null)
            {
                return "Please entry field";
            }
            var cart = new Cart()
            {
                CartId = Guid.NewGuid().ToString(),
                AccountId = cartRequest.AccountId,
                TotalPrice = 0,
                CreateDate = DateTime.Now,
                UpdateDate = null,
            };

           var result = await _cartRepository.AddCart(cart);
            return result ? "Add Success" : "Add Failed";
        }
    }
}
