namespace Tellers.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                // do redirect logic here

                // maybe add logger info
            }

            return View();
        }
    }
}