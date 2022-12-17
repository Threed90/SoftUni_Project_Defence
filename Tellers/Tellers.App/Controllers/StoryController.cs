using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Story;

namespace Tellers.App.Controllers
{
    public class StoryController : Controller
    {
        private IStoryService storyService;

        public StoryController(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        [Authorize]
        public async Task<IActionResult> Read(string storyId, int page = 1, bool isMarked = false)
        {
            isMarked = await this.storyService.IsReadedStory(storyId, User.FindFirstValue(ClaimTypes.NameIdentifier));

            return this.View(await storyService.GetStoryDetails(storyId, page, isMarked));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MarkAsReaded(string storyId)
        {
            var isMarked = await this.storyService.MarkAsReaded(storyId, User.FindFirstValue(ClaimTypes.NameIdentifier));

            return RedirectToAction(nameof(Read), new { storyId = storyId, page = 1, isMarked});
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string storyId)
        {
            //check story.CreatorId == currentUserId if not redirect
            
            var model = await this.storyService.GetStory(storyId);

            if(await this.storyService.IsStoryCreatorTheCurrentUser(storyId, User.FindFirstValue(ClaimTypes.NameIdentifier)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            return View(await this.storyService.AddAllGenresAndStoryTypes(model));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string storyId, string creatorId, StoryEditFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.StoryCreatorUserId = creatorId;
                return View(await this.storyService.AddAllGenresAndStoryTypes(model));
            }
            await this.storyService.Edit(model);


            return RedirectToAction(nameof(Read), new { storyId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View(await this.storyService.AddAllGenresAndStoryTypes<StoryFormViewModel>());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(StoryFormViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(await this.storyService.AddAllGenresAndStoryTypes(model));
            }

            await this.storyService.CreateStory(model, User.FindFirstValue(ClaimTypes.NameIdentifier));

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(string storyId)
        {
            if(await this.storyService.IsStoryCreatorTheCurrentUser(storyId, User.FindFirstValue(ClaimTypes.NameIdentifier)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            await this.storyService.DeleteStory(storyId);

            return RedirectToAction(nameof(All));
        }
    }
}

