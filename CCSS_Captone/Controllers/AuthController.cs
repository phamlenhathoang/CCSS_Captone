using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var account = await accountService.Login(email, password);  
            return Ok(account);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountRequest accountRequest)
        {
            var account = await accountService.Register(accountRequest);
            return Ok(account);
        }

        [HttpGet("loginGoogle")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = "/api/Auth/googleResponse" };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("googleResponse")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = User.Claims.ToDictionary(c => c.Type, c => c.Value);

            var email = result.GetValueOrDefault(ClaimTypes.Email);
            var googleId = result.GetValueOrDefault(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(googleId))
            {
                return Unauthorized("Missing required claims");
            }
            var result1 = await accountService.LoginByGoogle(email, googleId);
            return Ok(result1);
           
        }

        [HttpPatch]
        public async Task<IActionResult> CodeValidation(string email, string code)
        {
            var account = await accountService.CodeValidation(email, code);
            return Ok(account);
        }
    } 
}
