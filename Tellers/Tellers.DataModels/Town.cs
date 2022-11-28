namespace Tellers.DataModels
{
    public class Town
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.Town.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(Models.Town.PostCodeMaxLength)]
        public string PostCode { get; set; } = null!;

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
    }
}