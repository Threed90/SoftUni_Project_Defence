using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Read(string storyId)
         => this.View(await storyService.GetStoryDetails(storyId));
    }
}
