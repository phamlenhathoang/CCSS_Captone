using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("register/{role}")]
        public async Task<IActionResult> Register(AccountRequest accountRequest, string role)
        {
            var account = await accountService.Register(accountRequest, role);
            return Ok(account);
        }

        [HttpPatch]
        public async Task<IActionResult> CodeValidation(string email, string code)
        {
            var account = await accountService.CodeValidation(email, code);
            return Ok(account);
        }
    } 
}
