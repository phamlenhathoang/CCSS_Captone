using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using iText.Signatures;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IProductServices
    {
        Task<List<ProductResponse>> GetAllProduct(string? searchterm);
        Task<ProductResponse> GetProductById(string productId);
        Task<string> AddProduct(ProductRequest productRequest);
        Task<string> UpdateProduct(string productId, ProductRequest productRequest);
        Task<string> DeleteProduct(string ProductId);
    }

    public class ProductServices: IProductServices
    {
        private IProductRepository _repository;
        private IProductImageRepository _imageRepository;

        public ProductServices(IProductRepository repository, IProductImageRepository productImageRepository)
        {
            _repository = repository;
            _imageRepository = productImageRepository;
        }

        public async Task<List<ProductResponse>> GetAllProduct(string? searchterm)
        {
            List<ProductResponse> productRequests = new List<ProductResponse>();
            var listProducts = await _repository.GetAllProduct(searchterm);
            foreach(var r in listProducts)
            {
                var listImage = await _imageRepository.GetListImageByProductId(r.ProductId);
                ProductResponse productResponse = new ProductResponse()
                {
                    ProductId = r.ProductId,
                    ProductName = r.ProductName,
                    Description = r.Description,
                    Quantity = r.Quantity,
                    Price = r.Price,
                    CreateDate = r.CreateDate,
                    UpdateDate = r.UpdateDate,
                    IsActive = r.IsActive,
                    ProductImages = listImage.Select(img => new ProductImageResponse
                    {
                        UrlImage = img.UrlImage,
                        IsAvatar = img.IsAvatar,
                        CreateDate = img.CreateDate,
                        UpdateDate = img.UpdateDate,
                    }).ToList()
                };

                productRequests.Add(productResponse);
            }
            return productRequests;
        }

        public async Task<ProductResponse> GetProductById(string productId)
        {
          var product = await _repository.GetProductById(productId);
            var image = await _imageRepository.GetListImageByProductId(productId);
            ProductResponse productResponse = new ProductResponse()
            {
                ProductId = productId,
                ProductName = product.ProductName,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price,
                CreateDate = product.CreateDate,
                UpdateDate = product.UpdateDate,
                IsActive = product.IsActive,
                ProductImages = image.Select(img => new ProductImageResponse
                {
                    UrlImage = img.UrlImage,
                    IsAvatar = img.IsAvatar,
                    CreateDate = img.CreateDate,
                    UpdateDate = img.UpdateDate,

                }).ToList(),
            };
            return productResponse;
        }

        public async Task<string> AddProduct(ProductRequest productRequest)
        {
            if (productRequest == null)
            {
                return "Need to entry field";
            }
            if(productRequest.Quantity <= 0)
            {
                return "The quantity need > 0";
            }
            if(productRequest.Price <= 0)
            {
                return "The price need higher than 0";
            }      
            Product newProduct = new Product()
            {
                ProductId = Guid.NewGuid().ToString(),
                ProductName = productRequest.ProductName,
                Description = productRequest.Description,
                Quantity = productRequest.Quantity,
                Price = productRequest.Price,
                CreateDate = DateTime.Now,
                UpdateDate = null,
                IsActive = true,

            };
            var result = await _repository.AddProduct(newProduct);         
            return result ? "Add Success" : "Add Failed";
        }

        public async Task<string> UpdateProduct(string productId, ProductRequest productRequest)
        {
            var productExisting = await _repository.GetProductById(productId);
            if (productExisting == null)
            {
                return "Product is not found";
            }
            if(productRequest.Quantity == 0)
            {
                productExisting.IsActive = false;
            }
            if(productRequest.Quantity <  0 || productRequest.Price < 0)
            {
                return "number cannot be negative";
            }
            productExisting.ProductName = productRequest.ProductName;
            productExisting.Description = productRequest.Description;
            productExisting.Quantity = productRequest.Quantity;
            productExisting.Price = productRequest.Price;
            productExisting.UpdateDate = DateTime.Now;
            
            var result = await _repository.UpdateProduct(productExisting);
            return result ? "Update Success" : "Update Failed";
        }

        public async Task<string> DeleteProduct(string ProductId)
        {
            var product = await _repository.GetProductById(ProductId);
            if (product == null)
            {
                return "Product not found";
            }
            await _repository.DeleteProduct(product);
            return "Delete Success";
        }
    }
}
