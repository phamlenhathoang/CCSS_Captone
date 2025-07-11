﻿using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestCharacterController : ControllerBase
    {
        private readonly IRequestCharacterService _characterServices;

        public RequestCharacterController(IRequestCharacterService characterServices)
        {
            _characterServices = characterServices;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCharacterInRequestById(string requestCharacterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterServices.GetCharacterInRequestById(requestCharacterId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetRequestCharacterByCosplayer")]
        public async Task<IActionResult> GetRequestCharacterByCosplayerId(string cosplayerId)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterServices.GetRequestCharacterByCosplayer(cosplayerId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }


        [HttpPost("GetAllRequestCharacterByListDate")]
        public async Task<IActionResult> GetAllRequestCharacterByListDate(List<Date> dates)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterServices.GetAllRequestCharacterByListDate(dates);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Status")]
        public async Task<IActionResult> UpdateStatusRequestCharacter(string requestCharacterId, RequestCharacterStatus status)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterServices.UpdateStatus(requestCharacterId, status);
                return Ok(result);
            }
            return BadRequest(ModelState);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequestCharacter(string requestCharacterId, CharacterInRequest characterInRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterServices.UpdateCharactetInRRequest(requestCharacterId, characterInRequest);
                return Ok(result);
            }
            return BadRequest(ModelState);

        }

        [HttpGet("CheckRequestCharacter")]
        public async Task<IActionResult> CheckRequestCharacter(string requestId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _characterServices.CheckRequestChracter(requestId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRequestCharacter(AddCharacterInRequest characterInRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterServices.AddCharacterInRequest(characterInRequest);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRequestCharacter(string requestCharacterId)
        {
            if (ModelState.IsValid)
            {
                var result = await _characterServices.DeleteCharacterInRequest(requestCharacterId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
