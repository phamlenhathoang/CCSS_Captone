using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ICharacterImageServices
    {
        Task<List<CharacterImage>> GetListCharacterImages(string characterId);
        Task<string> AddCharacterImage(string characterId, IFormFileCollection formFiles);
    }

    public class CharacterImageServices: ICharacterImageServices
    {
        private readonly ICharacterImageRepository _repository;
        private readonly ICharacterRepository _characterRepository;
        private readonly string _projectId = "miracles-ef238";
        private readonly string _bucketName = "miracles-ef238.appspot.com";

        public CharacterImageServices(ICharacterImageRepository repository, ICharacterRepository characterRepository)
        {
            _repository = repository;
            _characterRepository = characterRepository;
        }

        public async Task<List<CharacterImage>> GetListCharacterImages(string characterId)
        {
            return await _repository.GetListImageCharacter(characterId);
        }

        public async Task<string> AddCharacterImage(string characterId, IFormFileCollection formFiles)
        {
            try
            {
                var character = await _characterRepository.GetCharacter(characterId);
                if (character == null)
                {
                    throw new Exception("Product not found");
                }
                List<CharacterImage> characterImages = new List<CharacterImage>();
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
                        characterImages.Add(new CharacterImage()
                        {
                            CharacterId = character.CharacterId,
                            CharacterImageId = Guid.NewGuid().ToString(),
                            UrlImage = downloadUrl,
                            CreateDate = DateTime.UtcNow.AddHours(7),
                            IsAvatar = false,
                        });
                    }
                }
                if (characterImages.Any())
                {
                    var result = await _repository.AddCharacterImages(characterImages);
                    return result ? "Add Success" : "Add Failed ";
                }
                else
                {
                    throw new Exception("No images were uploaded.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error uploading images for product {characterId}: {ex.Message}", ex);
            }
        }
    }
}
