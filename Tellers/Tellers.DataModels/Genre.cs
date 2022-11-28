namespace Tellers.DataModels
{
    public class Genre
    {
        public Genre()
        {
            this.StoryTypes= new HashSet<StoryType>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.Genre.NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<StoryType> StoryTypes { get; set; }
    }
}