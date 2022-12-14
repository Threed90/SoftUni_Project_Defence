namespace Tellers.DataModels
{
    public class Revue
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.Revue.TextMaxLength)]
        public string Text { get; set; } = null!;
        public double Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid StoryId { get; set; }
        public Story Story { get; set; } = null!;

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
    }
}