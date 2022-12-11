namespace Tellers.DataModels
{
    public class StoryType
    {
        public StoryType()
        {
            this.Stories = new HashSet<Story>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.StoryType.NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Story> Stories { get; set; }
    }
}