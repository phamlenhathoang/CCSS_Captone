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
    public interface ICartProductServices
    {
        Task<List<CartProduct>> GetAllCartProduct();
        Task<CartProduct> GetCartProductById(string id);
        Task<CartProduct> GetCartProduct(string productId, string cartId);
        Task<List<CartProduct>> GetListProductInCart(string cartId);
        Task<string> AddCartProduct(string cartId, List<CartProductRequest> cartProductRequests);
        Task<string> UpdateCartProduct(string cartId, List<UpdateCartProductRequest> updateCartProductRequests);
        Task<string> DeleteCartProduct(string cartId, List<CartPorductRequestDtos> cartProductRequests);
        Task<string> DeleteCartProductAfterPayment(string cartId, List<CartProductRequestDTO> cartProductRequests);

    }

    public class CartProductServices : ICartProductServices
    {
        private readonly ICartProductRepository _repository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBeginTransactionRepository _beginTransactionRepository;

        public CartProductServices(ICartProductRepository repository, IBeginTransactionRepository beginTransactionRepository, ICartRepository cartRepository, IProductRepository productRepository)
        {
            _repository = repository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _beginTransactionRepository = beginTransactionRepository;

        }


        #region AddCartProduct
        public async Task<string> AddCartProduct(string cartId, List<CartProductRequest> cartProductRequests)
        {
            if (cartProductRequests == null || !cartProductRequests.Any())
            {
                return "No cart products to add.";
            }
            if (cartId == null)
            {
                return "Required this filed";
            }
            var cart = await _cartRepository.GetCartById(cartId);
            if (cart == null)
            {
                return "Cart not found";
            }
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                foreach (var cp in cartProductRequests)
                {
                    var product = await _productRepository.GetProductById(cp.ProductId);
                    if (product == null)
                    {
                        await transaction.RollbackAsync();
                        return "Product not found";
                    }
                    if (product.Quantity == 0 || product.Quantity < cp.Quantity)
                    {
                        await transaction.RollbackAsync();
                        return "This product is out of stock";
                    }

                    int addedQuantity = cp.Quantity ?? 1;
                    double addedPrice = (double)product.Price * addedQuantity;


                    var cartProductExisting = await _repository.GetCartProduct(cp.ProductId, cartId);
                    if (cartProductExisting != null)
                    {
                        cartProductExisting.Quantity += addedQuantity;
                        cartProductExisting.Price = product.Price * cartProductExisting.Quantity;

                        await _repository.UpdateCartProduct(cartProductExisting);
                    }
                    else
                    {
                        var cartProduct = new CartProduct()
                        {
                            CartProductId = Guid.NewGuid().ToString(),
                            ProductId = cp.ProductId,
                            CartId = cartId,
                            Quantity = cp.Quantity ?? 1,
                            Price = product.Price * cp.Quantity,
                            CreatedDate = DateTime.Now,
                        };

                        var result = await _repository.AddCartProduct(cartProduct);
                        if (!result)
                        {
                            await transaction.RollbackAsync();
                            return "Add Failed";
                        }
                    }

                    cart.TotalPrice += addedPrice;
                    cart.UpdateDate = DateTime.Now;
                    var result1 = await _cartRepository.UpdateCart(cart);
                    if (!result1)
                    {
                        await transaction.RollbackAsync();
                        return "Add Failed";
                    }
                }
                await transaction.CommitAsync();
                return "Add Success";
            }
        }
        #endregion

        #region DeleteCartProduct
        public async Task<string> DeleteCartProduct(string cartId, List<CartPorductRequestDtos> cartProductRequests)
        {
            if (cartId == null)
            {
                return "required this field";
            }
            var cart = await _cartRepository.GetCartById(cartId);
            if (cart == null)
            {
                return "Cart not found";
            }
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                foreach (var cp in cartProductRequests)
                {
                    var cartProduct = await _repository.GetCartProductById(cp.CartProductId);
                    if (cartProduct == null)
                    {
                        return "this Product is not in Cart";
                    }
                    var product = await _productRepository.GetProductById(cartProduct.ProductId);
                    if (product == null)
                    {
                        return "Prouduct ot found";
                    }
                    var result = await _repository.DeleteCartProduct(cartProduct);
                    if (!result)
                    {
                        await transaction.RollbackAsync();
                        return "Delete Failed";
                    }

                    cart.TotalPrice -= (double)cartProduct.Price;
                    cart.UpdateDate = DateTime.Now;
                    var result2 = await _cartRepository.UpdateCart(cart);
                    if (!result2)
                    {
                        await transaction.RollbackAsync();
                        return "Delete Failed";
                    }

                }
                await transaction.CommitAsync();
                return "Delete Success";
            }
        }
        #endregion

        #region UpdateCartProduct
        public async Task<string> UpdateCartProduct(string cartId, List<UpdateCartProductRequest> updateCartProductRequests)
        {
            if (cartId == null)
            {
                return "Required this field";
            }
            var cart = await _cartRepository.GetCartById(cartId);
            if (cart == null)
            {
                return "Cart is not found";
            }
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                foreach (var cp in updateCartProductRequests)
                {
                    var cartproduct = await _repository.GetCartProductById(cp.CartProductId);
                    if (cartproduct == null)
                    {
                        return "This product is not in Cart";
                    }
                    if (cp.Quantity == 0)
                    {
                        return "Quanitty of Product mmust higher than 0";
                    }
                    var product = await _productRepository.GetProductById(cartproduct.ProductId);
                    if (product == null)
                    {
                        return "This product is not found";
                    }

                    double oldPrice = (double)cartproduct.Price;

                    //if (cp.Quantity == 0)
                    //{
                    //    var deleteResult = await _repository.DeleteCartProduct(cartproduct);
                    //    if (!deleteResult)
                    //    {
                    //        return "Failed to delete product from cart";
                    //    }

                    //    // Adjust the Cart's total price by subtracting the removed product's price
                    //    cart.TotalPrice -= oldPrice;
                    //    cart.UpdateDate = DateTime.Now;
                    //    await _cartRepository.UpdateCart(cart);

                    //}

                    cartproduct.Quantity = cp.Quantity;
                    cartproduct.Price = cp.Quantity * product.Price;
                    await _repository.UpdateCartProduct(cartproduct);


                    double priceDifference = (double)cartproduct.Price - oldPrice;

                    cart.TotalPrice += priceDifference;
                    cart.UpdateDate = DateTime.Now;
                    var result2 = await _cartRepository.UpdateCart(cart);
                    if (!result2)
                    {
                        await transaction.RollbackAsync();
                        return "Update Failed";
                    }

                }

                await transaction.CommitAsync();
                return "Update Success";
            }
        }
        #endregion

        #region DeleteCartProductAfterPayment
        public async Task<string> DeleteCartProductAfterPayment(string cartId, List<CartProductRequestDTO> cartProductRequests)
        {
            if (cartId == null)
            {
                return "required this field";
            }
            var cart = await _cartRepository.GetCartById(cartId);
            if (cart == null)
            {
                return "Cart not found";
            }
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                foreach (var cp in cartProductRequests)
                {
                    var cartProduct = await _repository.GetCartProduct(cp.ProductId, cartId);
                    if (cartProduct == null)
                    {
                        return "this Product is not in Cart";
                    }
                    var product = await _productRepository.GetProductById(cartProduct.ProductId);
                    if (product == null)
                    {
                        return "Prouduct not found";
                    }
                    var result = await _repository.DeleteCartProduct(cartProduct);
                    if (!result)
                    {
                        await transaction.RollbackAsync();
                        return "Delete Failed";
                    }

                    cart.TotalPrice -= (double)cartProduct.Price;
                    cart.UpdateDate = DateTime.Now;
                    var result2 = await _cartRepository.UpdateCart(cart);
                    if (!result2)
                    {
                        await transaction.RollbackAsync();
                        return "Delete Failed";
                    }

                }
                await transaction.CommitAsync();
                return "Delete Success";
            }
        }
        #endregion

        #region GetAllCartProduct
        public async Task<List<CartProduct>> GetAllCartProduct()
        {
            return await _repository.GetAllCartProduct();
        }
        #endregion

        #region GetCartProduct
        public async Task<CartProduct> GetCartProduct(string productId, string cartId)
        {
            return await _repository.GetCartProduct(productId, cartId);
        }
        #endregion

        #region GetCartProductById
        public async Task<CartProduct> GetCartProductById(string id)
        {
            return await _repository.GetCartProductById(id);
        }
        #endregion

        #region GetListProductInCart
        public async Task<List<CartProduct>> GetListProductInCart(string cartId)
        {
            return await _repository.GetListProductInCart(cartId);
        }
        #endregion

    }
}
