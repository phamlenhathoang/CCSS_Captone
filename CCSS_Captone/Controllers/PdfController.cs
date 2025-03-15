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
        //private readonly IPdfService pdfService;

        //public PdfController(IPdfService pdfService)
        //{
        //    this.pdfService = pdfService;
        //}

        [HttpGet]
        public IActionResult GenerateInvoicePdf()
        {
            using (var document = new PdfDocument())
            {
                string HtmlContent = "<h1>Welcome</h1>";
                PdfGenerator.AddPdfPages(document, HtmlContent, PageSize.A4);
                byte[]? response = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    document.Save(ms);
                    response = ms.ToArray();
                }
                string FileName = "Contract.pdf";
                return File(response, "application/pdf", FileName);
            }
        }
    }
}
