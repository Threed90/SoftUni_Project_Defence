using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Profiles;

namespace Tellers.App.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [Authorize]
        public async Task<IActionResult> Info(string profileId)
        {
            return View(await this.profileService.GetProfileInfo(profileId));
        }
    }
}
