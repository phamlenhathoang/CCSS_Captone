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
        Task<string> AddProduct(ProductRequest productRequest, List<IFormFile> formFiles);
        Task<string> UpdateProduct(string productId, UpdateProductRequest productRequest);
        Task<string> DeleteProduct(string ProductId);
    }

    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;
        private readonly IProductImageRepository _imageRepository;
        private readonly Image _image;
        private readonly IBeginTransactionRepository _transactionRepository;

        public ProductServices(IProductRepository repository, Image image, IProductImageRepository productImageRepository, IBeginTransactionRepository transactionRepository)
        {
            _repository = repository;
            _image = image;
            _imageRepository = productImageRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<List<ProductResponse>> GetAllProduct(string? searchterm)
        {
            List<ProductResponse> productRequests = new List<ProductResponse>();
            var listProducts = await _repository.GetAllProduct(searchterm);
            foreach (var r in listProducts)
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
                        ProductImageId = img.ProductImageId,
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
                    ProductImageId = img.ProductImageId,
                    UrlImage = img.UrlImage,
                    IsAvatar = img.IsAvatar,
                    CreateDate = img.CreateDate,
                    UpdateDate = img.UpdateDate,

                }).ToList(),
            };
            return productResponse;
        }

        public async Task<string> AddProduct(ProductRequest productRequest, List<IFormFile> formFiles)
        {
            if (productRequest == null)
            {
                return "Need to entry field";
            }
            if (productRequest.Quantity <= 0)
            {
                return "The quantity need > 0";
            }
            if (productRequest.Price <= 0)
            {
                return "The price need higher than 0";
            }
            using (var transaction = await _transactionRepository.BeginTransaction())
            {
                try
                {
                    List<ProductImage> productImages = new List<ProductImage>();
                    Product newProduct = new Product()
                    {
                        ProductId = Guid.NewGuid().ToString(),
                        ProductName = productRequest.ProductName,
                        Description = productRequest.Description,
                        Quantity = productRequest.Quantity,
                        Price = productRequest.Price,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        UpdateDate = null,
                        IsActive = true,
                    };
                    var result = await _repository.AddProduct(newProduct);
                    if (!result)
                    {
                        await transaction.RollbackAsync();
                        return "Add Failed";
                    }
                    foreach (var file in formFiles)
                    {
                        int count = 0;
                        ProductImage productImage = new ProductImage()
                        {
                            ProductImageId = Guid.NewGuid().ToString(),
                            ProductId = newProduct.ProductId,
                            UrlImage = await _image.UploadImageToFirebase(file),
                            CreateDate = DateTime.UtcNow.AddHours(7),
                            UpdateDate = null,
                        };
                        if (count == 0)
                        {
                            productImage.IsAvatar = true;
                        }
                        else
                        {
                            productImage.IsAvatar = false;
                        }
                        productImages.Add(productImage);
                        count++;
                    }
                    var result2 = await _imageRepository.AddListImageProduct(productImages);
                    if (!result2)
                    {
                        await transaction.RollbackAsync();
                        return "Add Image failed";
                    }

                    await transaction.CommitAsync();
                    return "Add Success";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("An error occurred", ex);
                }
            }
        }

        public async Task<string> UpdateProduct(string productId, UpdateProductRequest productRequest)
        {
            var productExisting = await _repository.GetProductById(productId);
            if (productExisting == null)
            {
                return "Product is not found";
            }
            if (productRequest.Quantity == 0)
            {
                productExisting.IsActive = false;
            }
            if (productRequest.Quantity < 0 || productRequest.Price < 0)
            {
                return "number cannot be negative";
            }
            using (var transaction = await _transactionRepository.BeginTransaction())
            {
                productExisting.ProductName = productRequest.ProductName;
                productExisting.Description = productRequest.Description;
                productExisting.Quantity = productRequest.Quantity;
                productExisting.Price = productRequest.Price;
                productExisting.UpdateDate = DateTime.UtcNow.AddHours(7);
                productExisting.IsActive = productRequest.IsActive;

                var result = await _repository.UpdateProduct(productExisting);
                if (!result)
                {
                    await transaction.RollbackAsync();
                    return " Update Product failed";
                }

                await transaction.CommitAsync();
                return "Update Product Success";
            }
        }

        public async Task<string> DeleteProduct(string ProductId)
        {
            var product = await _repository.GetProductById(ProductId);
            if (product == null)
            {
                return "Product not found";
            }
            product.IsActive = false;   

            await _repository.UpdateProduct(product);
            return "Delete Success";
        }
    }
}
