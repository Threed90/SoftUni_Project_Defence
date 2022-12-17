using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.ViewModels.Story
{
    public class StoryEditFormViewModel : StoryFormViewModel
    {
        public string StoryId { get; set; }
        public string? StoryCreatorUserId { get; set; }
    }
}
