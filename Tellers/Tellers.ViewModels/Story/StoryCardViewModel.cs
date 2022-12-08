using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.ViewModels.Story
{
    public class StoryCardViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string BookCoverPicture { get; set; } = null!;

        public string Summary { get; set; } = null!;
    }
}
