using CCSS_Service.Model.Requests;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        //    private readonly IImageService _service;

        //    public ImageController(IImageService service)
        //    {
        //        _service = service;
        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> GetAllImage()
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var result = await _service.GetAllImages();
        //            return Ok(result);
        //        }
        //        return BadRequest(ModelState);
        //    }

        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetImageById(string id)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var result = await _service.GetImageById(id);
        //            return Ok(result);
        //        }
        //        return BadRequest(ModelState);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> AddImage(ImageRequest request)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var result = await _service.AddImage(request);
        //            return Ok(result);
        //        }
        //        return BadRequest(ModelState);
        //    }

        //    [HttpDelete]
        //    public async Task<IActionResult> DeleteImage(string id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var result = await _service.DeleteImage(id);
        //        return Ok(result);
        //    }
    }
}
