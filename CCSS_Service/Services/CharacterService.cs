using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{
    public interface ICharacterService
    {
        //Task<CharacterResponse> GetCharacter(string characterId);
        //Task<List<CharacterResponse>> GetAll();
        //Task<Character> GetCharacterById(string characterId);
        //Task<string> AddCharacter(CharacterRequest characterResponse, List<IFormFile> imageFiles);
        //Task<string> UpdateCharacter(string id, CharacterRequest newCharacter);
        //Task<string> DeleteCharacter(string id);
    }
    public class CharacterService : ICharacterService
    {
        //private readonly ICharacterRepository _characterRepository;
        //private readonly IMapper mapper;
        //private readonly IContractServices _contractServices;
        //private readonly IImageRepository _imageRepository;
        //public CharacterService(IImageRepository imageRepository ,ICharacterRepository characterRepository, IMapper mapper, IContractServices contractServices )
        //{
        //    _characterRepository = characterRepository;
        //    this.mapper = mapper;
        //    _contractServices = contractServices;
        //    _imageRepository = imageRepository;
        //}
        //public async Task<List<CharacterResponse>> GetAll()
        //{
        //    return mapper.Map<List<CharacterResponse>>(await _characterRepository.GetAll());
        //}

        //public async Task<CharacterResponse> GetCharacter(string characterId)
        //{
        //    return mapper.Map<CharacterResponse>(await _characterRepository.GetCharacter(characterId));
        //}

        //public async Task<Character> GetCharacterById(string characterId)
        //{
        //    return await _characterRepository.GetCharacter(characterId);
        //}

        //public async Task<string> AddCharacter(CharacterRequest characterResponse, List<IFormFile> imageFiles)
        //{
        //    var newCharacter = new Character()
        //    {
        //        CharacterId = Guid.NewGuid().ToString(),
        //        CategoryId = characterResponse.CategoryId,
        //        CharacterName = characterResponse.CharacterName,
        //        Price = characterResponse.Price,
        //        Description = characterResponse.Description,
        //        IsActive = characterResponse.IsActive,
        //        CreateDate = DateTime.Now,
        //        UpdateDate = null,
        //    };
        //    await _characterRepository.CreateCharacter(newCharacter);


        //    var imagesFireBase = imageFiles.Select(async (file) =>
        //    {
        //        string imageUrl = await _contractServices.UploadImageToFirebase(file);

        //        return new EventImage
        //        {
        //            ImageId = Guid.NewGuid().ToString(),
        //            ImageUrl = imageUrl,
        //            CharacterId = newCharacter.CharacterId,
        //            CreateDate = DateTime.Now,
        //            UpdateDate = null,
        //        };
        //    }).ToList();

        //    var images = await Task.WhenAll(imagesFireBase);
        //    var result = await _imageRepository.AddListImage(images.ToList());
        //    return "Add Success";
        //}

        //public async Task<string> UpdateCharacter(string id, CharacterRequest newCharacter)
        //{
        //    var character = await GetCharacterById(id);
        //    if (character == null)
        //    {
        //        return "Character is null";
        //    }
        //    character.CharacterName = newCharacter.CharacterName;
        //    character.Price = newCharacter.Price;
        //    character.Description = newCharacter.Description;
        //    character.IsActive = newCharacter.IsActive;
        //    character.UpdateDate = DateTime.Now;

        //    await _characterRepository.UpdateCharacter(character);
        //    return "Update character Success";
        //}

        //public async Task<string> DeleteCharacter(string id)
        //{
        //    var character = await GetCharacterById(id);
        //    if (character == null)
        //    {
        //        return "Character is not found here";
        //    }
        //    await _characterRepository.DeleteCharacter(character);
        //    return $"{character.CharacterName} deleted";
        //}
    }
}
