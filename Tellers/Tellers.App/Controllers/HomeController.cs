using Microsoft.AspNetCore.Mvc;
using Tellers.Services.Interfaces;
using Tellers.Utilities;
using Tellers.ViewModels.Story;

namespace Tellers.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IStoryService storyServer;
        public HomeController(
            ILogger<HomeController> logger,
            IStoryService storyServer)
        {
            this.logger = logger;
            this.storyServer = storyServer;
        }

        public async Task<IActionResult> Index()
            => View(new HomeStoryCardManagerViewModel()
            {
                newestStories = new ViewModelInfoBox<List<StoryCardViewModel>>()
                {
                    ModelIndicator = "newest",
                    ViewModel = (await storyServer.GetNewestStories()).ToList()
                },
                topStories = new ViewModelInfoBox<List<StoryCardViewModel>>()
                {
                    ModelIndicator = "top",
                    ViewModel = (await storyServer.GetTopStories()).ToList()
                }
            });

        public IActionResult Terms()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                // do redirect logic here

                // maybe add logger info
            }

            return View();
        }
    }
}