namespace Tellers.DataModels
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.Genre.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}