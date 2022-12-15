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

        public async Task<IActionResult> Read(string storyId, int page = 1)
         => this.View(await storyService.GetStoryDetails(storyId, page));

        //public IActionResult MarkAsReaded()
    }
}
