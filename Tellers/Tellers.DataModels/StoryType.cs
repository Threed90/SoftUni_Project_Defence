namespace Tellers.DataModels
{
    public class StoryType
    {
        public StoryType()
        {
            this.Genres = new HashSet<Genre>();
            this.Stories = new HashSet<Story>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.StoryType.NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}