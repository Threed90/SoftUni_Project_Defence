using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Tellers.ViewModels.Revues
{
    public class CreateRevueViewModel
    {
        public string CreatorPictureUrl { get; set; }
        public string Text { get; set; }
        public string StoryId { get; set; }
        public double Rating { get; set; }
    }
}
