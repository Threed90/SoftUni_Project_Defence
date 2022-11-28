namespace Tellers.DataModels
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.Country.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(Models.Country.CountryCodeMaxLength)]
        public string CountryCode { get; set; } = null!;

        [Required]
        [MaxLength(Models.Country.IsoCodeMaxLength)]
        public string IsoCode { get; set; } = null!;

        public ICollection<Town> Towns { get; set; }
    }
}