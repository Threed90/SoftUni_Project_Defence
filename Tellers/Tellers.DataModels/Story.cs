namespace Tellers.DataModels
{
    public class Story
    {
        public Story()
        {
            this.Readers = new HashSet<Profile>();
            this.Authors = new HashSet<Profile>();
            this.Revues = new HashSet<Revue>();
            this.Id= Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(Models.Story.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(Models.Story.PdfFileMaxLength)]
        public string? PdfFile { get; set; }

        public string? StoryText { get; set; }

        public int StoryTypeId { get; set; }
        public StoryType StoryType { get; set; } = null!;

        public Guid? CreatorId { get; set; }
        public Profile? Creator { get; set; }

        public ICollection<Revue> Revues { get; set; }
        public ICollection<Profile> Authors { get; set; }
        public ICollection<Profile> Readers { get; set; }
    }
}