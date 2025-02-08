using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AuthController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromQuery][Required] string email, [FromQuery][Required] string password)
        {
            try
            {
                var result = await accountService.Login(email, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromQuery][Required] string email, [FromQuery][Required] string password)
        {
            try
            {
                var result = await accountService.Login(email, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
