using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tellers.ViewModels.Profiles;

namespace Tellers.App.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public IActionResult Info(string profileId)
        {
            return View(new ProfileInfoViewModel()
            {
                UserId= profileId, //has to be userId not profileId
            });
        }
    }
}
