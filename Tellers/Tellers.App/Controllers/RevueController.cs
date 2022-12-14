using Microsoft.AspNetCore.Mvc;

namespace Tellers.App.Controllers
{
    public class RevueController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
