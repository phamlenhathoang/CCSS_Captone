﻿using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Customer, Admin, Manager, Consultant")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpPost("GetAccountByCharacterAndDateAndRange")]
        public async Task<IActionResult> GetAccountByCharacterAndDateAndRange(CheckAccountRequestForRange checkAccountRequestForRange)
        {
            var account = await accountService.GetAccountByCharacterAndDateAndRange(checkAccountRequestForRange.CharacterId, checkAccountRequestForRange.Dates, checkAccountRequestForRange.RequestId);
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
        
        [HttpGet("requestId")]
        public async Task<IActionResult> GetAccountByRequestId(string requestId)
        {
            var account = await accountService.GetAccountByRequestId(requestId);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> AddCosplayer(string username, string password)
        {
            var account = await accountService.AddCosplayer(username, password);
            return Ok(account);
        }

        [HttpPut("UpdateStatusAccount")]
        public async Task<IActionResult> UpdateStatusAccount(string accountId, bool IsActive)
        {
            if (ModelState.IsValid)
            {
                var result = await accountService.UpdateStatusAccount(accountId, IsActive);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("CreateAccountByAdmin")]
        public async Task<IActionResult> CreateAccountByAdmin(CreateAccountRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await accountService.CreateAccountByAdmin(request);
                    return Ok(result);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
