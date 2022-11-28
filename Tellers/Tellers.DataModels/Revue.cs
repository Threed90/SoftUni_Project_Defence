namespace Tellers.DataModels
{
    public class Revue
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.Revue.TextMaxLength)]
        public string Text { get; set; } = null!;
        public double Rating { get; set; }
    }
}