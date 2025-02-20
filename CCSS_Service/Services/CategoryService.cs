using AutoMapper;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using iText.IO.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponse> GetCategory(string id);
        Task<List<CategoryResponse>> GetAll();
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<List<CategoryResponse>> GetAll()
        {
            return mapper.Map<List<CategoryResponse>>(await _categoryRepository.GetAll());
        }

        public async Task<CategoryResponse> GetCategory(string id)
        {
            return mapper.Map<CategoryResponse>(await _categoryRepository.GetCategory(id)); 
        }
    }
}
