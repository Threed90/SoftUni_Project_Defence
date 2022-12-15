using Tellers.ViewModels.Revues;

namespace Tellers.ViewModels.Story
{
    public class StoryDetailsViewModel
    {
        public string StoryId { get; set; }
        public string Title { get; set; } = null!;
        public string CreatorUserId { get; set; } = null!;
        public string StorySummary { get; set; } = null!;
        public string Month { get; set; } = null!;
        public int Day { get; set; }
        public int Year { get; set; }

        public string? CreatorId { get; set; }
        public string? CreatorUsername { get; set; }
        public string? CreatorPictureUrl { get; set; }
        public string? CreatorFirstName { get; set; }
        public string? CreatorMiddleName { get; set; }
        public string? CreatorLastName { get; set; }
        public string? CreatorPseudonym { get; set; }
        public string? BookCoverPicture { get; set; }
        public string? ExternalAuthorName { get; set; }
        public string PdfFileUrl { get; set; } = null!;

        public string StoryType { get; set; }

        public int TotalRevues { get; set; }    

        public int Page { get; set; }

        public List<string> Genres { get; set; }
        public List<ReadRevueViewModel> Revues { get; set; }

        public List<string> AuthorNames { get; set; }
    }
}
