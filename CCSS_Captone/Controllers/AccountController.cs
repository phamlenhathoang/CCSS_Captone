using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("GetAllAccount")]
        public async Task<ActionResult> GetAllAccount(string? searchterm, [Required] string roleId)
        {
            if (ModelState.IsValid)
            {
                var result = await accountService.GetAllAccount(searchterm, roleId);
                if (result == null)
                {
                    return NotFound(500 + "Value not found" );
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        //[HttpPut]
        //public async Task<IActionResult> ChangeAccountForTask(string taskId, string accountId)
        //{
        //    var result = await accountService.ChangeAccountForTask(taskId, accountId);
        //    return Ok(result);
        //}

        [HttpGet("GetAccountByEventCharacterId/{eventCharacterId}")]
        public async Task<ActionResult<AccountResponse>> GetAccountByEventCharacterId(string eventCharacterId)
        {
            try
            {
                var account = await accountService.GetAccountByEventCharacterId(eventCharacterId);

                if (account == null)
                {
                    return NotFound(new { message = "Account not found for the given EventCharacterId." });
                }

                return Ok(account);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the account.", error = ex.Message });
            }
        }
        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccountByAccountId(string accountId)
        {
            var account = await accountService.GetAccountByAccountId(accountId);   
            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccountByAccountId([FromForm] string accountId, [FromForm]UpdateAccountRequest updateAccountRequest)
        {
            var account = await accountService.UpdateAccountByAccountId(accountId, updateAccountRequest);
            return Ok(account);
        }

        [HttpPost("characterId")]
        public async Task<IActionResult> GetAccountByCharacterAndDate(CheckAccountRequest checkAccountRequest)
        {
            var account = await accountService.GetAccountByCharacterAndDate(checkAccountRequest.CharacterId, checkAccountRequest.Dates, checkAccountRequest.AccountId);
            return Ok(account);
        }
        
        [HttpPost("GetAccountByCharacterAndDateForCreateEvent")]
        public async Task<IActionResult> GetAccountByCharacterAndDateForCreateEvent(CheckAccountRequest checkAccountRequest)
        {
            var account = await accountService.GetAccountByCharacterAndDateForCreateEvent(checkAccountRequest.CharacterId, checkAccountRequest.Dates, checkAccountRequest.AccountId);
            return Ok(account);
        }

        [HttpGet("characterName/{characterName}")]
        public async Task<IActionResult> ViewAllAccountByCharacterName(string characterName, string? start, string? end)
        {
            var account = await accountService.ViewAllAccountByCharacterName(characterName.ToLower(),start, end);
            return Ok(account);
        }

        [HttpGet("contractId/{contractId}")]
        public async Task<IActionResult> ViewAllCosplayerByContractId(string contractId)
        {
            var account = await accountService.ViewAllCosplayerByContractId(contractId);
            return Ok(account);
        }
        
        [HttpGet("roleId/{roleId}")]
        public async Task<IActionResult> GetAllAccountByRoleId(string roleId)
        {
            var account = await accountService.GetAllAccountByRoleId(roleId);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> AddCosplayer(string username, string password)
        {
            var account = await accountService.AddCosplayer(username, password);
            return Ok(account);
        }
    }
}
