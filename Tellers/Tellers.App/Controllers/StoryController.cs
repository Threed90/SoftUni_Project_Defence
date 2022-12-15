using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tellers.Services.Interfaces;

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
    }
}
