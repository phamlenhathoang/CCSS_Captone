﻿using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{
    public interface ICharacterService
    {
        Task<CharacterResponse> GetCharacter(string characterId);
        Task<List<CharacterResponse>> GetAllCharacters();
        Task<List<CharacterResponse>> GetCharacters(string? characterId, string? categoryId, string? characterName, double? MaxHeight, double? MinHeight, double? Maxweight, double? MinWeight, double? MinPrice, double? MaxPrice);
        Task<Character> GetCharacterById(string characterId);
        Task<string> AddCharacter(CharacterRequest characterResponse, List<IFormFile> imageFiles);
        Task<string> UpdateCharacter(string id, CharacterRequest newCharacter, List<CharacterImageRequest>? characterImageRequests);
        Task<string> DeleteCharacter(string id);
        Task<List<CharacterResponse>> GetCharactersByCategoryId(string categoryId);
        Task<List<CharacterResponse>> GetCharactersByDate(string startDate, string endDate);
        Task<CharacterResponse> GetCharactersByDateAndCharacterId(string startDate, string endDate, string characterId);
    }
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly Image image;
        private readonly IMapper mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICharacterImageRepository _imageRepository;
        private readonly IBeginTransactionRepository _beginTransactionRepository;
        private readonly IRequestCharacterRepository requestCharacterRepository;
        private readonly IRequestDatesRepository requestDatesRepository;
        private readonly IRequestRepository requestRepository;
        private readonly IEventCharacterRepository eventCharacterRepository;
        private readonly IEventRepository eventRepository;
        public CharacterService(Image image, IBeginTransactionRepository beginTransactionRepository, ICategoryRepository _categoryRepository, ICharacterRepository characterRepository, IMapper mapper, ICharacterImageRepository _imageRepository, IRequestCharacterRepository requestCharacterRepository, IRequestDatesRepository requestDatesRepository, IRequestRepository requestRepository, IEventCharacterRepository eventCharacterRepository, IEventRepository eventRepository)
        {
            _characterRepository = characterRepository;
            this.mapper = mapper;
            this._categoryRepository = _categoryRepository;
            this._imageRepository = _imageRepository;
            this.image = image;
            _beginTransactionRepository = beginTransactionRepository;
            this.requestCharacterRepository = requestCharacterRepository;
            this.requestDatesRepository = requestDatesRepository;
            this.requestRepository = requestRepository;
            this.eventCharacterRepository = eventCharacterRepository;
            this.eventRepository = eventRepository;
        }
        public async Task<List<CharacterResponse>> GetAllCharacters()
        {
            var characters = await _characterRepository.GetAll();
            return mapper.Map<List<CharacterResponse>>(characters);
        }
        public async Task<List<CharacterResponse>> GetCharacters(string? characterId, string? categoryId, string? characterName, double? MaxHeight, double? MinHeight, double? Maxweight, double? MinWeight, double? MinPrice, double? MaxPrice)
        {
            List<CharacterResponse> characterResponses = new List<CharacterResponse>();
            List<CharacterImageResponse> characterImageResponses = new List<CharacterImageResponse>();
            List<Character> characters = await _characterRepository.GetCharacters(characterId, categoryId, characterName, MaxHeight, MinHeight, Maxweight, MinWeight, MinPrice, MaxPrice);

            if (characters == null)
            {
                return characterResponses;
            }
            foreach (var character in characters)
            {
                foreach (var image in character.CharacterImages)
                {
                    CharacterImageResponse characterImageResponse = new CharacterImageResponse()
                    {
                        CharacterImageId = image.CharacterImageId,
                        CreateDate = image.CreateDate,
                        IsAvatar = image.IsAvatar,
                        UpdateDate = image.UpdateDate,
                        UrlImage = image.UrlImage,
                    };
                    characterImageResponses.Add(characterImageResponse);
                }

                CharacterResponse characterResponse = new CharacterResponse()
                {
                    CharacterId = character.CharacterId,
                    CategoryId = character.CategoryId,
                    CharacterName = character.CharacterName,
                    CreateDate = character.CreateDate.ToString("HH:mm dd/MM/yyyy") ?? null,
                    Description = character.Description,
                    IsActive = character.IsActive,
                    UpdateDate = character.UpdateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                    Price = character.Price,
                    Images = characterImageResponses,
                    MaxHeight = character.MaxHeight,
                    MinHeight = character.MinHeight,
                    MinWeight = character.MinWeight,
                    MaxWeight = character.MaxWeight,
                    Quantity = character.Quantity,
                };

                characterResponses.Add(characterResponse);
                characterImageResponses = new List<CharacterImageResponse>();
            }

            return characterResponses;
        }

        public async Task<CharacterResponse> GetCharacter(string characterId)
        {
            List<CharacterImageResponse> characterImageResponses = new List<CharacterImageResponse>();
            var character = await _characterRepository.GetCharacter(characterId);
            if (character == null)
            {
                return null;
            }

            foreach (var image in character.CharacterImages)
            {
                CharacterImageResponse characterImageResponse = new CharacterImageResponse()
                {
                    CharacterImageId = image.CharacterImageId,
                    CreateDate = image.CreateDate,
                    IsAvatar = image.IsAvatar,
                    UpdateDate = image.UpdateDate,
                    UrlImage = image.UrlImage,
                };
                characterImageResponses.Add(characterImageResponse);
            }

            CharacterResponse characterResponse = new CharacterResponse()
            {
                CharacterId = character.CharacterId,
                CategoryId = character.CategoryId,
                CharacterName = character.CharacterName,
                CreateDate = character.CreateDate.ToString("HH:mm dd/MM/yyyy") ?? null,
                Description = character.Description,
                IsActive = character.IsActive,
                UpdateDate = character.UpdateDate?.ToString("HH:mm dd/MM/yyyy") ?? null,
                Price = character.Price,
                Images = characterImageResponses,
                MaxHeight = character.MaxHeight,
                MinHeight = character.MinHeight,
                MinWeight = character.MinWeight,
                MaxWeight = character.MaxWeight,
                Quantity = character.Quantity,
            };

            return characterResponse;
        }

        public async Task<Character> GetCharacterById(string characterId)
        {
            return await _characterRepository.GetCharacter(characterId);
        }

        public async Task<string> AddCharacter(CharacterRequest characterResponse, List<IFormFile> imageFiles)
        {
            Category category = await _categoryRepository.GetCategory(characterResponse.CategoryId);
            if (category == null)
            {
                throw new Exception("Category does not exist");
            }

            if (characterResponse.MaxHeight <= 0 || characterResponse.MinHeight <= 0 || characterResponse.MaxWeight <= 0 || characterResponse.MinWeight <= 0)
            {
                throw new Exception("MaxHeight, MinHeight, MaxWeight, MinWeight must be greater than 0");
            }
            float minWeight = (float)characterResponse.MinWeight;

            if (characterResponse.MaxWeight < minWeight + 10)
            {
                throw new Exception("MaxWeight must be greater than MinWeight is 10");
            }

            float minHeight = (float)characterResponse.MinHeight;

            if (characterResponse.MaxHeight < minHeight + 10)
            {
                throw new Exception("MaxHeight must be greater than MinHeight is 10");
            }
            using (var transaction = await _beginTransactionRepository.BeginTransaction())
            {
                List<CharacterImage> characterImages = new List<CharacterImage>();
                var newCharacter = new Character()
                {
                    CharacterId = Guid.NewGuid().ToString(),
                    CategoryId = characterResponse.CategoryId,
                    CharacterName = characterResponse.CharacterName,
                    Price = characterResponse.Price,
                    Description = characterResponse.Description,
                    IsActive = true,
                    CreateDate = DateTime.UtcNow.AddHours(7),
                    UpdateDate = null,
                    Quantity = characterResponse.Quantity,
                    MaxHeight = characterResponse.MaxHeight,
                    MaxWeight = characterResponse.MaxWeight,
                    MinHeight = characterResponse.MinHeight,
                    MinWeight = characterResponse.MinWeight,
                };

                bool checkAddCharacter = await _characterRepository.CreateCharacter(newCharacter);
                if (!checkAddCharacter)
                {
                    return "Can not add Character";
                }

                int count = 0;

                foreach (var file in imageFiles)
                {
                    CharacterImage characterImage = new CharacterImage()
                    {
                        CharacterId = newCharacter.CharacterId,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        UrlImage = await image.UploadImageToFirebase(file),
                    };

                    if (count == 0)
                    {
                        characterImage.IsAvatar = true;
                    }
                    else
                    {
                        characterImage.IsAvatar = false;
                    }

                    characterImages.Add(characterImage);
                    count++;
                }

                bool result = await _imageRepository.AddCharacterImages(characterImages);
                if (!result)
                {
                    return "Failed";
                }

                await transaction.CommitAsync();
                return "Add Success";
            }
        }

        public async Task<string> UpdateCharacter(string id, CharacterRequest newCharacter, List<CharacterImageRequest>? characterImageRequests)
        {
            Category category = await _categoryRepository.GetCategory(newCharacter.CategoryId);
            if (category == null)
            {
                return "Category does not exist";
            }

            if (newCharacter.MaxHeight <= 0 || newCharacter.MinHeight <= 0 || newCharacter.MaxWeight <= 0 || newCharacter.MinWeight <= 0)
            {
                throw new Exception("MaxHeight, MinHeight, MaxWeight, MinWeight must be greater than 0");
            }
            float minWeight = (float)newCharacter.MinWeight;

            if (newCharacter.MaxWeight < minWeight + 10)
            {
                throw new Exception("MaxWeight must be greater than MinWeight is 10");
            }

            float minHeight = (float)newCharacter.MinHeight;

            if (newCharacter.MaxHeight < minHeight + 10)
            {
                throw new Exception("MaxHeight must be greater than MinHeight is 10");
            }

            var character = await _characterRepository.GetCharacter(id);
            if (character == null)
            {
                return "Character is null";
            }

            character.CharacterName = newCharacter.CharacterName;
            character.Price = newCharacter.Price;
            character.Description = newCharacter.Description;
            character.UpdateDate = DateTime.UtcNow.AddHours(7);
            character.Description = newCharacter.Description;
            character.Price = character.Price;
            character.CategoryId = category.CategoryId;
            character.Quantity = newCharacter.Quantity;
            character.MinHeight = newCharacter.MinHeight;
            character.MaxHeight = newCharacter.MaxHeight;
            character.MinWeight = character.MinWeight;
            character.MaxWeight = character.MaxWeight;

            bool result = await _characterRepository.UpdateCharacter(character);
            if (!result)
            {
                return "Can not update Character";
            }

            if (characterImageRequests != null)
            {
                foreach (var characterImageRequest in characterImageRequests)
                {
                    CharacterImage characterImage = await _imageRepository.GetCharacterImageById(characterImageRequest.CharactetImageId);
                    if (characterImage == null)
                    {
                        return "CharacterImage does not exist";
                    }
                    characterImage.UpdateDate = DateTime.Now;
                    characterImage.UrlImage = await image.UploadImageToFirebase(characterImageRequest.Image);

                    bool checkUpdateImage = await _imageRepository.UpdateCharacterImage(characterImage);
                    if (!checkUpdateImage)
                    {
                        return "Can not update CharacterImage";
                    }
                }
            }

            return "Update character Success";
        }

        public async Task<string> DeleteCharacter(string id)
        {
            var character = await _characterRepository.GetCharacter(id);
            if (character == null)
            {
                return "Character is not found here";
            }
            character.IsActive = false;
            bool result = await _characterRepository.UpdateCharacter(character);
            if (!result)
            {
                return "Can not delete Character";
            }
            return $"{character.CharacterName} deleted";
        }

        public async Task<List<CharacterResponse>> GetCharactersByCategoryId(string categoryId)
        {
            try
            {
                Category category = await _categoryRepository.GetCategoryIncludeCharacter(categoryId);
                if (category == null)
                {
                    throw new Exception("Category does not exist");
                }
                if (!category.Characters.Any())
                {
                    throw new Exception($"Character belong {category.CategoryId} do not exist");
                }

                return mapper.Map<List<CharacterResponse>>(category.Characters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CharacterResponse>> GetCharactersByDate(string startDate, string endDate)
        {
            try
            {
                string format = "dd/MM/yyyy";
                CultureInfo culture = CultureInfo.InvariantCulture;
                DateTime start = DateTime.ParseExact(startDate, format, culture);
                DateTime end = DateTime.ParseExact(endDate, format, culture);

                List<CharacterResponse> characterResponses = new List<CharacterResponse>();
                List<Character> characters = await _characterRepository.GetAll();

                foreach (var character in characters)
                {
                    int quantity = (int)character.Quantity;
                    List<RequestCharacter> requestCharacters = await requestCharacterRepository.GetListRequestCharacterByCharacterId(character.CharacterId);
                    if (requestCharacters.Count > 0)
                    {
                        foreach (RequestCharacter requestCharacter in requestCharacters)
                        {
                            if (requestCharacter.RequestDates.Count > 0)
                            {
                                bool result = await requestDatesRepository.CheckValidCharacterRequestDate(requestCharacter.RequestCharacterId, start, end);

                                if (!result)
                                {
                                    quantity -= 1;
                                }
                            }

                            if (requestCharacter.RequestDates.Count == 0)
                            {

                                bool result = await requestRepository.CheckRequestValid(requestCharacter.Request.RequestId, start, end);

                                if (!result)
                                {
                                    quantity -= 1;
                                }
                            }
                        }
                    }

                    List<EventCharacter> eventCharacters = await eventCharacterRepository.GetEventCharacterByCharacterId(character.CharacterId);
                    if (eventCharacters.Count > 0)
                    {
                        foreach (EventCharacter eventCharacter in eventCharacters)
                        {
                            bool result = await eventRepository.CheckEventValid(eventCharacter.Event.EventId, start, end);
                            if (!result)
                            {
                                quantity -= 1;
                            }
                        }
                    }

                    if (quantity > 0)
                    {
                        List<CharacterImageResponse> characterImageResponses = new List<CharacterImageResponse>();
                        List<CharacterImage> images = await _imageRepository.GetListImageCharacter(character.CharacterId);
                        foreach (CharacterImage image in images)
                        {
                            var characterImage = new CharacterImageResponse()
                            {
                                CharacterImageId = image.CharacterImageId,
                                CreateDate = image.CreateDate,
                                IsAvatar = image.IsAvatar,
                                UpdateDate = image.UpdateDate,
                                UrlImage = image.UrlImage,
                            };
                            characterImageResponses.Add(characterImage);
                        }

                        var characterResponse = new CharacterResponse()
                        {
                            Quantity = quantity,
                            CategoryId = character.CategoryId,
                            CharacterId = character.CharacterId,
                            CharacterName = character.CharacterName,
                            CreateDate = character.CreateDate.ToString("dd/MM/yyyy"),
                            Description = character.Description,
                            IsActive = character.IsActive,
                            MaxHeight = character.MaxHeight,
                            MaxWeight = character.MaxWeight,
                            MinHeight = character.MinHeight,
                            MinWeight = character.MinWeight,
                            Price = character.Price,
                            UpdateDate = character.UpdateDate?.ToString("dd/MM/yyyy"),
                            Images = characterImageResponses
                        };

                        characterResponses.Add(characterResponse);
                    }
                }
                return characterResponses;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CharacterResponse> GetCharactersByDateAndCharacterId(string startDate, string endDate, string characterId)
        {
            try
            {
                string format = "dd/MM/yyyy";
                CultureInfo culture = CultureInfo.InvariantCulture;
                DateTime start = DateTime.ParseExact(startDate, format, culture);
                DateTime end = DateTime.ParseExact(endDate, format, culture);

                CharacterResponse? characterResponse = null;

                Character character = await _characterRepository.GetCharacter(characterId);
                if (character == null)
                {
                    return null; // hoặc throw nếu không tìm thấy
                }

                int quantity = (int)character.Quantity;

                // Kiểm tra RequestCharacter
                List<RequestCharacter> requestCharacters = await requestCharacterRepository.GetListRequestCharacterByCharacterId(character.CharacterId);
                foreach (var requestCharacter in requestCharacters)
                {
                    if (requestCharacter.RequestDates != null && requestCharacter.RequestDates.Count > 0)
                    {
                        bool isValid = await requestDatesRepository.CheckValidCharacterRequestDate(requestCharacter.RequestCharacterId, start, end);
                        if (!isValid)
                        {
                            quantity -= 1;
                        }
                    }
                    else
                    {
                        bool isValid = await requestRepository.CheckRequestValid(requestCharacter.Request.RequestId, start, end);
                        if (!isValid)
                        {
                            quantity -= 1;
                        }
                    }
                }

                // Kiểm tra EventCharacter
                List<EventCharacter> eventCharacters = await eventCharacterRepository.GetEventCharacterByCharacterId(character.CharacterId);
                foreach (var eventCharacter in eventCharacters)
                {
                    bool isValid = await eventRepository.CheckEventValid(eventCharacter.Event.EventId, start, end);
                    if (!isValid)
                    {
                        quantity -= 1;
                    }
                }

                if (quantity > 0)
                {
                    var characterImageResponses = new List<CharacterImageResponse>();
                    var images = await _imageRepository.GetListImageCharacter(character.CharacterId);
                    foreach (var image in images)
                    {
                        characterImageResponses.Add(new CharacterImageResponse
                        {
                            CharacterImageId = image.CharacterImageId,
                            CreateDate = image.CreateDate,
                            IsAvatar = image.IsAvatar,
                            UpdateDate = image.UpdateDate,
                            UrlImage = image.UrlImage
                        });
                    }

                    characterResponse = new CharacterResponse
                    {
                        Quantity = quantity,
                        CategoryId = character.CategoryId,
                        CharacterId = character.CharacterId,
                        CharacterName = character.CharacterName,
                        CreateDate = character.CreateDate.ToString("dd/MM/yyyy"),
                        Description = character.Description,
                        IsActive = character.IsActive,
                        MaxHeight = character.MaxHeight,
                        MaxWeight = character.MaxWeight,
                        MinHeight = character.MinHeight,
                        MinWeight = character.MinWeight,
                        Price = character.Price,
                        UpdateDate = character.UpdateDate?.ToString("dd/MM/yyyy"),
                        Images = characterImageResponses
                    };
                }

                return characterResponse;
            }
            catch (Exception ex)
            {
                // Tránh throw Exception mới mà làm mất stacktrace
                throw;
            }
        }

    }
}
