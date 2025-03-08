using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        //[HttpGet("contractId")]
        //public async Task<ActionResult<AccountResponse>> GetListAccountToContactByContractId(string contractId)
        //{
        //    var accounts = await accountService.GetListAccountToContactByContractId(contractId);
        //    if (accounts == null)
        //    {
        //        return NotFound(new { message = "Accounts not found." });
        //    }
        //    return Ok(accounts);
        //}

        //[HttpPost]
        //public async Task<ActionResult> CheckForCharactersWithDuplicateCosplayers(string accountId, List<string> chacracters)
        //{
        //    var accounts = await accountService.CheckForCharactersWithDuplicateCosplayers(accountId, chacracters);
        //    return Ok(accounts);
        //}

        //[HttpGet]
        //public async Task<ActionResult> GetAccountsForTask(string taskId, string accountId)
        //{
        //    var accounts = await accountService.GetAccountsForTask(taskId, accountId);
        //    if (accounts == null)
        //    {
        //        return NotFound(new { message = "Accounts not found." });
        //    }
        //    return Ok(accounts);
        //}

        //[HttpPut]
        //public async Task<IActionResult> ChangeAccountForTask(string taskId, string accountId)
        //{
        //    var result = await accountService.ChangeAccountForTask(taskId, accountId);
        //    return Ok(result);
        //}

    }
}
