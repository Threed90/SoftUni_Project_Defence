using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tellers.Services.Interfaces;
using Tellers.Utilities;
using Tellers.ViewModels.Revues;

namespace Tellers.App.Controllers
{
    public class RevueController : Controller
    {
        private const string fragment = "revues";
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await revueService.CreateRevue(model.StoryId, User.FindFirstValue(ClaimTypes.NameIdentifier), model.Text, model.Rating);

            var redirectResult =  RedirectToAction(nameof(StoryController.Read), nameof(StoryController).ReplaceControllerSuffix(), new { storyId = storyId });

            redirectResult.Fragment = fragment;
            return redirectResult;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int revueId, string storyId, string userId)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != userId)
            {
                return RedirectToAction(nameof(StoryController.Read), nameof(StoryController).ReplaceControllerSuffix(), new { storyId = storyId });
            }

            var model = await this.revueService.GetRevueForEditing(revueId);

            if(model == null)
            {
                return NotFound();
            }

            var profile = await this.profileService.GetProfile(userId);

            model.CreatorPictureUrl = profile.PictureUrl;
            model.StoryId= storyId;
            model.UserId= userId;
            model.Id = revueId;

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string storyId, string userId, int revueId, EditRevueViewModel model)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != userId)
            {
                return RedirectToAction(nameof(StoryController.Read), nameof(StoryController).ReplaceControllerSuffix(), new { storyId = storyId });
            }

            if (!ModelState.IsValid)
            {
                var profile = await profileService.GetProfile(userId);
                model.CreatorPictureUrl= profile.PictureUrl;
                model.Id = revueId;
                return View(model);
            }

            await this.revueService.EditRevue(revueId, model.Text, model.Rating);

            var redirectResult = RedirectToAction(nameof(StoryController.Read), nameof(StoryController).ReplaceControllerSuffix(), new { storyId = storyId });
            redirectResult.Fragment = fragment;
            return redirectResult;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(string storyId, int revueId)
        {

            await this.revueService.DeleteRevue(revueId);

            return RedirectToAction(nameof(StoryController.Read), nameof(StoryController).ReplaceControllerSuffix(), new { storyId = storyId });
        }
    }
}
