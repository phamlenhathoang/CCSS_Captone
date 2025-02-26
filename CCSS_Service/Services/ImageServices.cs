using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IImageService
    {
        Task<List<Image>> GetAllImages();
        Task<Image> GetImageById(string id);
        Task<string> DeleteImage(string id);
        Task<string> AddImage(ImageRequest request);
    }
    public class ImageServices: IImageService  
    {
        private readonly IImageRepository _imageRepository;
        private readonly string _projectId = "miracles-ef238";
        private readonly string _bucketName = "miracles-ef238.appspot.com";

        public ImageServices(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<List<Image>> GetAllImages()
        {
            return await _imageRepository.GetAllImage();
        }

        public async Task<Image> GetImageById(string id)
        {
            return await _imageRepository.GetImageById(id);
        }

        public async Task<string> DeleteImage(string id)
        {
            var image = await GetImageById(id);
            if (image == null)
            {
                return "Image not found";
            }
            await _imageRepository.DeleteImage(image);
            return "Delete Success";
        }

        public async Task<string> AddImage(ImageRequest request)
        {
            if (request.ImageUrl == null || request.ImageUrl.Length == 0)
            {
                return "File không hợp lệ";
            }
            if (request == null)
            {
                return "Please enter the Image";
            }
            using (var memoryStream = new MemoryStream())
            {
                await request.ImageUrl.CopyToAsync(memoryStream);
                var bytes = memoryStream.ToArray();

                // Initialize Firebase Admin SDK
                var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile("CCSS.json");
                //tạm thời hardcode, thay sau FromFile thành đường dẫn file net1701-jewelry...
                var storage = StorageClient.Create(credential);

                // Construct the object name (path) in Firebase Storage
                var objectName = $"images/{DateTime.Now.Ticks}_{request.ImageUrl.FileName}";

                // Upload the file to Firebase Storage
                var response = await storage.UploadObjectAsync(
                    bucket: _bucketName,
                    objectName: objectName,
                    contentType: request.ImageUrl.ContentType,
                    source: new MemoryStream(bytes)
                );
                // Tải file lên Firebase Storage
                //var storageObject = await storage.GetObjectAsync(_bucketName, objectName);
                var downloadUrl = /*storageObject.MediaLink*/ $"https://storage.googleapis.com/{_bucketName}/{objectName}";

                Image image = new Image()
                {
                    ImageId = Guid.NewGuid().ToString(),
                    ImageUrl = downloadUrl,
                    CreateDate = DateTime.Now,
                    UpdateDate = null,
                    ProductId = request.ProductId,
                    EventId = request.EventId,
                    CharacterId = request.CharacterId,
                };
                await _imageRepository.AddImage(image);
                return "Add Success";
            }
        }

        public async Task<string> UpdateImage(string id, ImageRequest request)
        {
            var image = GetImageById(id);   
            if (image == null)
            {
                return "Image not found";
            }
            throw new NotImplementedException();
        }
    }
}
