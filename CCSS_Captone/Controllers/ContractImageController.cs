using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractImageController : ControllerBase
    {
        private readonly IContractImageService _contractImageService;

        public ContractImageController(IContractImageService contractImageService)
        {
            _contractImageService = contractImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContractImageByContractIdAndStatus(string contractId, string status)
        {
            var account = await _contractImageService.GetContractImageByContractIdAndStatus(contractId, status);
            return Ok(account);
        }
        
        [HttpGet("{contractImageId}")]
        public async Task<IActionResult> GetContractImageByContractImageId(string contractImageId)
        {
            var account = await _contractImageService.GetContractImageByContractImageId(contractImageId);
            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContractImage(string contractImageId, ContractImageRequest contractImageRequest)
        {
            var account = await _contractImageService.UpdateContractImage(contractImageId, contractImageRequest);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> AddContractImage(string contractId, List<IFormFile>? UrlImages)
        {
            var account = await _contractImageService.AddContractImage(contractId, UrlImages);
            return Ok(account);
        }
    }
}
