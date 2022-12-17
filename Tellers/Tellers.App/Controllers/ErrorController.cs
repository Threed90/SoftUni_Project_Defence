using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Tellers.App.Controllers
{
    [Route("/Error")]
    public class ErrorController : Controller
    {

        public ErrorController()
        {
            
        }

        [Route("500")]
        public IActionResult AppError()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            
            return View();
        }

        [Route("404")]
        public IActionResult PageNotFound()
        {
            string originalPath = "unknown";
            if (HttpContext.Items.ContainsKey("originalPath"))
            {
                originalPath = HttpContext.Items["originalPath"] as string;
            }
            return View();
        }
    }
}
