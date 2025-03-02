using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Repository.Repositories
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAllImage();
        Task<Image> GetImageById(string id);
        Task AddImage(Image image);
        Task<bool> AddListImage(List<Image> imageList);
        Task DeleteImage(Image image);
        Task UpdateImage(Image image);
    }

    public class ImageRepository: IImageRepository
    {
        private readonly CCSSDbContext _context;

        public ImageRepository(CCSSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Image>> GetAllImage()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetImageById(string id)
        {
            return await _context.Images.FirstOrDefaultAsync(sc => sc.ImageId.Equals(id));
        }

        public async Task AddImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddListImage(List<Image> imageList)
        {
            _context.Images.AddRange(imageList);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
