using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountImageController : ControllerBase
    {
        private readonly IAccountImageService _accountImageService;

        public AccountImageController(IAccountImageService accountImageService)
        {
            _accountImageService = accountImageService;
        }

        [HttpGet("{accountImageId}")]
        public async Task<IActionResult> GetAccountImageById(string accountImageId)
        {
            var account = await _accountImageService.GetAccountImageById(accountImageId);
            return Ok(account);
        }

        [HttpGet("accountId/{accountId}")]
        public async Task<IActionResult> GetAccountImageByAccountId(string accountId)
        {
            var account = await _accountImageService.GetAccountImageByAccountId(accountId);
            return Ok(account);
        }
    }
}
