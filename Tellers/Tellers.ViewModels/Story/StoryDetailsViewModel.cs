using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.ViewModels.Story
{
    public class StoryDetailsViewModel
    {
        public string Title { get; set; } = null!;
        public string StorySummary { get; set; } = null!;
        public string Month { get; set; } = null!;
        public int Day { get; set; }
        public int Year { get; set; }
        public string? CreatorFirstName { get; set; }
        public string? CreatorMiddleName { get; set; }
        public string? CreatorLastName { get; set; }
        public string? CreatorPseudonym { get; set; }
        public string? BookCoverPicture { get; set; }
        public string PdfFileUrl { get; set; } = null!;
    }
}
