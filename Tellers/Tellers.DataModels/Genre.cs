namespace Tellers.DataModels
{
    public class Genre
    {
        public Genre()
        {
            this.Stories = new HashSet<Story>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.Genre.NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Story> Stories { get; set; }
    }
}