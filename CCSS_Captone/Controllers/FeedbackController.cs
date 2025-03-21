//using CCSS_Service.Model.Requests;
//using CCSS_Service.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CCSS_Captone.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FeedbackController : ControllerBase
//    {
//        private readonly IFeedbackService feedbackService;

//        public FeedbackController(IFeedbackService feedbackService)
//        {
//            this.feedbackService = feedbackService;
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddFeedback(List<FeedbackRequest> feedbackRequests, string accountId, string contractId)
//        {
//            var result = await feedbackService.AddFeedback(feedbackRequests, accountId, contractId);    
//            return Ok(result);  
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdateFeedback(UpdateFeedbackRequest feedbackRequests, string accountId, string contractId)
//        {
//            var result = await feedbackService.UpdateFeedback(feedbackRequests, accountId, contractId);
//            return Ok(result);
//        }
//    }
//}
