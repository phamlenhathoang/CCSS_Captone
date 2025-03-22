using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{
    public interface IProductImageServices
    {
        Task<List<ProductImage>> GetAllProductImages();
        Task<string> AddListImageProduct(string productId, IFormFileCollection formFiles);
    }

    public class ProductImageServices: IProductImageServices
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductRepository _productRepository;
        private readonly string _projectId = "miracles-ef238";
        private readonly string _bucketName = "miracles-ef238.appspot.com";

        public ProductImageServices(IProductImageRepository productImageRepository, IProductRepository productRepository)
        {
            _productImageRepository = productImageRepository;
            _productRepository = productRepository;
        }

        public async Task<List<ProductImage>> GetAllProductImages()
        {
            return await _productImageRepository.GetAllImageProduct();
        }

        public async Task<string> AddListImageProduct(string productId, IFormFileCollection formFiles)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                if (product == null)
                {
                    throw new Exception("Product not found");
                }
                List<ProductImage> productImages = new List<ProductImage>();
                foreach (var file in formFiles)
                {
                    if (file == null || file.Length == 0)
                    {
                        throw new Exception("File không hợp lệ");
                    }
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        var bytes = memoryStream.ToArray();

                        // Initialize Firebase Admin SDK
                        var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile("CCSS.json");
                        var storage = StorageClient.Create(credential);

                        // Construct the object name (path) in Firebase Storage
                        var objectName = $"images/{DateTime.Now.Ticks}_{file.FileName}";

                        // Upload the file to Firebase Storage
                        var response = await storage.UploadObjectAsync(
                            bucket: _bucketName,
                            objectName: objectName,
                            contentType: file.ContentType,
                            source: new MemoryStream(bytes)
                        );

                        // Return the download URL
                        var downloadUrl = $"https://storage.googleapis.com/{_bucketName}/{objectName}";
                        productImages.Add(new ProductImage()
                        {
                            ProductId = productId,
                            ProductImageId = Guid.NewGuid().ToString(),
                            UrlImage = downloadUrl
                        });
                    }                      
                }
                if (productImages.Any())
                {
                    await _productImageRepository.AddListImageProduct(productImages);
                    return "Add Success";
                }
                else
                {
                    throw new Exception("No images were uploaded.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error uploading images for product {productId}: {ex.Message}", ex);
            }
        }
    }
}
