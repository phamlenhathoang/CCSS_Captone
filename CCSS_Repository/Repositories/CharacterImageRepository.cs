using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Repositories
{
    public interface ICharacterImageRepository
    {
        Task<bool> AddCharacterImages(List<CharacterImage> characterImages);
        Task<bool> UpdateCharacterImage(CharacterImage characterImage);
        Task<CharacterImage> GetCharacterImageById(string id);

    }
    public class CharacterImageRepository : ICharacterImageRepository
    {
        private readonly CCSSDbContext _dbContext;

        public CharacterImageRepository(CCSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddCharacterImages(List<CharacterImage> characterImages)
        {
            await _dbContext.AddRangeAsync(characterImages);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<CharacterImage> GetCharacterImageById(string id)
        {
            return await _dbContext.CharacterImages.FirstOrDefaultAsync(c => c.CharacterImageId.Equals(id));
        }

        public async Task<bool> UpdateCharacterImage(CharacterImage characterImage)
        {
            _dbContext.CharacterImages.Update(characterImage);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
