using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface ICustomerCharacterService
    {
        Task<bool> AddCustomerCharacter(CustomerCharacterRequest customerCharacterRequest);
    }
    public class CustomerCharacterService : ICustomerCharacterService
    {
        private readonly ICustomerCharacterRepository customerCharacterRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICustomerCharacterImageRepository customerCharacterImageRepository;
        private readonly IMapper mapper;
        private readonly Image image;
        public CustomerCharacterService(ICustomerCharacterImageRepository customerCharacterImageRepository, Image image, IMapper mapper, ICategoryRepository categoryRepository, ICustomerCharacterRepository customerCharacterRepository)
        {
            this.customerCharacterRepository = customerCharacterRepository; 
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.image = image;
            this.customerCharacterImageRepository = customerCharacterImageRepository;
        }
        public async Task<bool> AddCustomerCharacter(CustomerCharacterRequest customerCharacterRequest)
        {
            try
            {
                Category category = await categoryRepository.GetCategory(customerCharacterRequest.CategoryId);
                List<CustomerCharacterImage> images = new List<CustomerCharacterImage>();
                if (category == null)
                {
                    throw new Exception("Category does not exist");
                }
                CustomerCharacter customerCharacter = mapper.Map<CustomerCharacter>(customerCharacterRequest);

                customerCharacter.Status = CustomerCharacterStatus.Pending;

                bool checkAddCusCha = await customerCharacterRepository.AddCustomerCharacterRepository(customerCharacter);
                if (!checkAddCusCha)
                {
                    throw new Exception("Can not add CustomerCharacter");
                }
                foreach (var imageCusCha in customerCharacterRequest.CustomerCharacterImages)
                {
                    string urlImage = await image.UploadImageToFirebase(imageCusCha);
                    CustomerCharacterImage customerCharacterImage = new CustomerCharacterImage()
                    {
                        CreateDate = DateTime.Now,
                        CustomerCharacterImageId = Guid.NewGuid().ToString(),
                        CustomerCharacterId = customerCharacter.CustomerCharacterId,
                        UpdateDate = null,
                        UrlImage = urlImage,
                    };

                    images.Add(customerCharacterImage);
                }

                bool result = await customerCharacterImageRepository.AddListCustomerCharacterImage(images);
                if (!result)
                {
                    throw new Exception("Can not add CustomerCharacterImage");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
