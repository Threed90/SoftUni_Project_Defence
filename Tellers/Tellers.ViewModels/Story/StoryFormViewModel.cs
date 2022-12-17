using Tellers.ViewModels.Genres;
using Tellers.ViewModels.StoryTypes;

namespace Tellers.ViewModels.Story
{
    public class StoryFormViewModel
    {
        [Required]
        [MinLength(Models.Story.TitleMinLength)]
        [MaxLength(Models.Story.TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(Models.Story.ExternalAuthorMaxLength)]
        public string? ExternalAuthor { get; set; }

        //[Url]
        public string? BookCover { get; set; }

        [Required]
        [MinLength(Models.Story.StorySummaryMinLength)]
        [MaxLength(Models.Story.StorySummaryMaxLength)]
        public string StorySummery { get; set; }

        //[Url]
        [Required]
        public string BookPdf { get; set;}

        [Required]
        public string StoryType { get; set; }

        public string? GenresNames { get; set; }

        //map ignore
        public List<StoryTypeViewModel>? StoryTypes { get; set; }

        //map ignore
        public List<GenreViewModel>? Genres { get; set; }
    }
}
