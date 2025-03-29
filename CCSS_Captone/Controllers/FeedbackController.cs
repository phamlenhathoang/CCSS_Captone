using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback(List<FeedbackRequest> feedbackRequests, string accountId)
        {
            var result = await feedbackService.AddFeedback(feedbackRequests, accountId);
            return Ok(result);
        }

        [HttpPut("accountId/{accountId}")]
        public async Task<IActionResult> UpdateFeedback(UpdateFeedbackRequest feedbackRequests, string accountId)
        {
            var result = await feedbackService.UpdateFeedback(feedbackRequests, accountId);
            return Ok(result);
        }

        [HttpGet("contractId/{contractId}")]
        public async Task<IActionResult> GetFeedbackByContractId(string contractId)
        {
            var result = await feedbackService.GetFeedbackByContractId(contractId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedback()
        {
            var result = await feedbackService.GetAllFeedback();
            return Ok(result);
        }

        [HttpGet("cosplayerId/{cosplayerId}")]
        public async Task<IActionResult> GetFeedbackByCosplayerId(string cosplayerId)
        {
            var result = await feedbackService.GetFeedbackByCosplayerId(cosplayerId);
            return Ok(result);
        }

        [HttpGet("feedbackId/{feedbackId}")]
        public async Task<IActionResult> GetFeedbackByFeedbackId(string feedbackId)
        {
            var result = await feedbackService.GetFeedbackByFeedbackId(feedbackId);
            return Ok(result);
        }
    }
}
