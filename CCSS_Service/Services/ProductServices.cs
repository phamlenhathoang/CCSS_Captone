using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
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
        Task<List<Product>> GetAllProduct(string searchterm);
        Task<Product> GetProductById(string productId);
        Task<string> AddProduct(ProductRequest productRequest, IFormFile formFile);
        Task<string> UpdateProduct(Product product);
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

        public async Task<List<Product>> GetAllProduct(string? searchterm)
        {
            return await _repository.GetAllProduct(searchterm);
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await _repository.GetProductById(productId);
        }

        public async Task<string> AddProduct(ProductRequest productRequest, IFormFile formFile)
        {
            if (productRequest == null)
            {
                return "Need to entry field";
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

            if (!result)
            {
                return "Add Product failed";
            }
            List<ProductImage> productImages = new List<ProductImage>();
            foreach (var item in productRequest.ListImageProduct)
            {
                var imageUrl = new Image();
                productImages.Add(new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = item.ProductId,
                    UrlImage = await imageUrl.UploadImageToFirebase(formFile),
                });
            }
            await _imageRepository.AddListImageProduct(productImages);
            return "Add Success";
        }

        public async Task<string> UpdateProduct(Product product)
        {
            await _repository.UpdateProduct(product);
            return "Update Success";
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
