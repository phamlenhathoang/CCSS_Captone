using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateService validateService;

        public ValidateController(IValidateService validateService)
        {
            this.validateService = validateService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateValidate(bool validate)
        {
            var account = await validateService.UpdateValidate(validate);
            return Ok(account);
        }
    }
}
