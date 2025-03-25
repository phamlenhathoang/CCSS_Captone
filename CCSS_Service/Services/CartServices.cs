using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{
    public interface ICartServices
    {
        Task<CartResponse> GetCartById(string id);
        Task<CartResponse> GetCartByAccount(string accountId);
        Task<string> AddCart(CartRequest cartRequest);
    }

    public class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IProductRepository _productRepository;

        public CartServices(ICartRepository cartRepository, ICartProductRepository cartProductRepository, IAccountRepository accountRepository, IProductRepository productRepository)
        {
            _accountRepository = accountRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _cartProductRepository = cartProductRepository;
        }

        public async Task<CartResponse> GetCartById(string id)
        {
            var cart = await _cartRepository.GetCartById(id);
            var listCartProduct = await _cartProductRepository.GetListProductInCart(id);
            CartResponse cartResponse = new CartResponse()
            {
                CartId = cart.CartId,
                AccountId = cart.AccountId,
                TotalPrice = cart.TotalPrice,
                CreateDate = cart.CreateDate,
                UpdateDate = cart.UpdateDate,
                ListCartProduct = listCartProduct.Select(cp => new CartProductResponse
                {
                    CartProductId = cp.ProductId,
                    ProductId = cp.ProductId,
                    Price = cp.Price,
                    Quantity = cp.Quantity,
                    CreatedDate = cp.CreatedDate,
                }).ToList(),
            };
            return cartResponse;

        }

        public async Task<CartResponse> GetCartByAccount(string accountId)
        {
            try
            {
                var cart = await _cartRepository.GetcartByAccount(accountId);
                if (cart == null)
                {
                    throw new Exception("Cart not found");
                }
                var listCartProduct = await _cartProductRepository.GetListProductInCart(cart.CartId);
                CartResponse cartResponse = new CartResponse()
                {
                    CartId = cart.CartId,
                    AccountId = cart.AccountId,
                    TotalPrice = cart.TotalPrice,
                    CreateDate = cart.CreateDate,
                    UpdateDate = cart.UpdateDate,
                    ListCartProduct = listCartProduct.Select(cp => new CartProductResponse
                    {
                        CartProductId = cp.ProductId,
                        ProductId = cp.ProductId,
                        Price = cp.Price,
                        Quantity = cp.Quantity,
                        CreatedDate = cp.CreatedDate,
                    }).ToList(),
                };
                return cartResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> AddCart(CartRequest cartRequest)
        {
            var account = await _accountRepository.GetAccount(cartRequest.AccountId);
            if (account == null)
            {
                return "Account not found";
            }
            if (account.RoleId != "R005")
            {
                return "You must be a customer ";
            }
            if (cartRequest == null)
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
