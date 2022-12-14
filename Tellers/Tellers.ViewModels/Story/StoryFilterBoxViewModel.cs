using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.ViewModels.Genres;
using Tellers.ViewModels.StoryTypes;

namespace Tellers.ViewModels.Story
{
    public class StoryFilterBoxViewModel
    {
        public List<StoryFilterCardViewModel> Cards { get; set; }


        public List<GenreViewModel> Genres { get; set; }

        public List<StoryTypeViewModel> StoryTypes { get; set; }

        public string? Genre { get; set; }
        public string? Type { get; set; }
        public string? Search { get; set; }
    }
}
