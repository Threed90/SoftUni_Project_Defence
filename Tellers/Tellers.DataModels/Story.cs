namespace Tellers.DataModels
{
    public class Story
    {
        public Story()
        {
            this.Readers = new HashSet<Profile>();
            this.Authors = new HashSet<Profile>();
            this.Revues = new HashSet<Revue>();
            this.Genres = new HashSet<Genre>();
            this.Id= Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(Models.Story.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(Models.Story.PdfFileUrlMaxLength)]
        public string PdfFileUrl { get; set; }

        [Required]
        public string BookCoverPicture { get; set; } = null!;

        [Required]
        [MaxLength(Models.Story.StorySummaryMaxLength)]
        public string StorySummary { get; set; } = null!; 

        //public string? StoryText { get; set; }

        public DateTime CreatedOn { get; set; }

        public int StoryTypeId { get; set; }
        public StoryType StoryType { get; set; } = null!;

        public Guid? CreatorId { get; set; }
        public Profile? Creator { get; set; }

        public string? ExternalAuthorName { get; set; }  

        public ICollection<Revue> Revues { get; set; }
        public ICollection<Profile> Authors { get; set; }
        public ICollection<Profile> Readers { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}