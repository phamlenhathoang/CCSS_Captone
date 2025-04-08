using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCharacterController : ControllerBase
    {
        private readonly ICustomerCharacterService custromerCharacterService;

        public CustomerCharacterController(ICustomerCharacterService custromerCharacterService)
        {
            this.custromerCharacterService = custromerCharacterService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustromerCharacter(CustomerCharacterRequest customerCharacterRequest)
        {
            var account = await custromerCharacterService.AddCustomerCharacter(customerCharacterRequest);
            return Ok(account);
        }

        [HttpPut]
        [Route("update-customer-character")]
        public async Task<IActionResult> UpdateCustomerCharacter(
                        [FromForm] string accountId,
                        [FromForm] string customerCharacterRequestId,
                        [FromForm] string name,
                        [FromForm] string description,
                        [FromForm] string? categoryId,
                        [FromForm] float? minHeight,
                        [FromForm] float? maxHeight,
                        [FromForm] float? minWeight,
                        [FromForm] float? maxWeight,
                        [FromForm] List<IFormFile>? images,
                        [FromForm] List<string>? customerCharacterImageIds)
        {
            if (images.Count != customerCharacterImageIds.Count)
            {
                return BadRequest("Số lượng ID và số lượng ảnh không khớp.");
            }

            var customerCharacterImages = new List<ListCustomerCharacterImage>();
            for (int i = 0; i < images.Count; i++)
            {
                customerCharacterImages.Add(new ListCustomerCharacterImage
                {
                    CustomerCharacterImageId = customerCharacterImageIds[i],
                    Image = images[i]
                });
            }

            var updateCustomerCharacterRequest = new UpdateCustomerCharacterRequest
            {
                Name = name,
                Description = description,
                CategoryId = categoryId,
                MinHeight = minHeight,
                MaxHeight = maxHeight,
                MinWeight = minWeight,
                MaxWeight = maxWeight,
                CustomerCharacterImages = customerCharacterImages
            };

            var account = await custromerCharacterService.UpdateCustomerCharacter(accountId, customerCharacterRequestId, updateCustomerCharacterRequest);
            return Ok(account);
        }


        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatusCustromerCharacter(string customerCharacterId, string status, string? reason, double? price)
        {
            var account = await custromerCharacterService.UpadateStatusCustomerCharacter(customerCharacterId, status, reason, price);
            return Ok(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerCharacterList(string? customerCharacterId, string? accountId, string? categoryId, string? createDate, string? status)
        {
            var account = await custromerCharacterService.GetCustomerCharacterList(customerCharacterId, accountId, categoryId, createDate, status);
            return Ok(account);
        }

        [HttpGet("GetAllCustomerByAccount")]
        public async Task<IActionResult> GetAllCustomerCharacterByAccount(string accountId)
        {
            if (ModelState.IsValid)
            {
                var result = await custromerCharacterService.GetAllCustomerCharacterByAccountId(accountId);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
