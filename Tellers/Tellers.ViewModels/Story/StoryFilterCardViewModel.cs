using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.ViewModels.Genres;
using Tellers.ViewModels.StoryTypes;

namespace Tellers.ViewModels.Story
{
    public class StoryFilterCardViewModel : StoryCardViewModel
    {
        public List<GenreViewModel> Genres { get; set; }

        public StoryTypeViewModel StoryType { get; set; }

        
    }
}
