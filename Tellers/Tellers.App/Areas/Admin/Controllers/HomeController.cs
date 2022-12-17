using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tellers.Constants;

namespace Tellers.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin/{controller=Home}/{action=Index}/{id?}")]
    [Authorize(Roles = $"{RoleNames.MasterAdminRoleName}, {RoleNames.AdminRoleName}, {RoleNames.ModeratorRoleName}")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
