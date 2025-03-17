//using Azure;
//using CCSS_Service.Libraries;
using CCSS_Repository.Entities;
using CCSS_Service.Libraries;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService pdfService;

        public PdfController(IPdfService pdf)
        {
            this.pdfService = pdf;
        }

        //[HttpGet]
        //public async Task<IFormFile> GenerateInvoicePdf(string requestId, int deposit)
        //{
        //    return await pdfService.ConvertBytesToIFormFile(requestId, deposit);
        //}
    }
}
