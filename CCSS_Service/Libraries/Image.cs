using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Libraries
{
    public class Image
    {
        private readonly string _projectId = "miracles-ef238";
        private readonly string _bucketName = "miracles-ef238.appspot.com";


        #region UploadImageToFirebase
        public async Task<string> UploadImageToFirebase(IFormFile file)
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
                return downloadUrl;
            }
        }
    
    }
    #endregion
}
