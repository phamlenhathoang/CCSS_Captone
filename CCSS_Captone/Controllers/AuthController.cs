using CCSS_Service.Models.Requests;
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
        public async Task<IActionResult> Register([FromQuery] AccountLoginRequest accountLoginRequest, [FromQuery][Required] string role)
        {
            try
            {
                var result = await accountService.Register(accountLoginRequest, role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("CodeValidation")]
        public async Task<IActionResult> CodeValidation([FromQuery][Required] string email, [FromQuery][Required] string code)
        {
            try
            {
                var result = await accountService.CodeValidation(email, code);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromQuery][Required] string email, [FromQuery] string? newPassword, [FromQuery] string? code)
        {
            try
            {
                var result = await accountService.ForgotPassword(email, newPassword ,code);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
