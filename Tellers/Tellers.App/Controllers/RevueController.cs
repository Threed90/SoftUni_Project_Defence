using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Revues;

namespace Tellers.App.Controllers
{
    public class RevueController : Controller
    {
        private readonly IRevueService revueService;
        private readonly IProfileService profileService;

        public RevueController(
            IRevueService revueService, 
            IProfileService profileService)
        {
            this.revueService = revueService;
            this.profileService = profileService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create(string storyId)
        {
            var profile = await profileService.GetProfile(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = new CreateRevueViewModel()
            {
                StoryId = storyId,
                CreatorPictureUrl = profile.PictureUrl,

            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(string storyId, CreateRevueViewModel model)
        {
            await revueService.CreateRevue(model.StoryId, User.FindFirstValue(ClaimTypes.NameIdentifier), model.Text, model.Rating);

            return RedirectToAction(nameof(StoryController.Read), nameof(StoryController).Replace("Controller", string.Empty), new { storyId = storyId });
        }
    }
}
