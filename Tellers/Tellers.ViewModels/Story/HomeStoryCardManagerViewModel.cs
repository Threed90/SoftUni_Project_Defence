using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.Utilities.Interfaces;

namespace Tellers.ViewModels.Story
{
    public class HomeStoryCardManagerViewModel
    {
        public IViewModelInfoBox<List<StoryCardViewModel>> newestStories { get; set; } = null!;
        public IViewModelInfoBox<List<StoryCardViewModel>> topStories { get; set; } = null!;

        public StoryFilterBoxViewModel Box { get; set; } = null!;
    }
}
