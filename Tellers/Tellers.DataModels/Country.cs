namespace Tellers.DataModels
{
    /// <summary>
    /// Data model for a Country
    /// </summary>
    public class Country
    {
        /// <summary>
        /// The constructor initialize needed collection.
        /// </summary>
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
        public int Id { get; set; }

        /// <summary>
        /// The name of the country
        /// </summary>
        [Required]
        [MaxLength(Models.Country.NameMaxLength)]
        public string Name { get; set; } = null!;

        ///// <summary>
        ///// The code of the country
        ///// </summary>
        //[Required]
        //[MaxLength(Models.Country.CountryCodeMaxLength)]
        //public string CountryCode { get; set; } = null!;

        /// <summary>
        /// The iso code of the country
        /// </summary>
        [Required]
        [MaxLength(Models.Country.IsoCodeMaxLength)]
        public string IsoCode { get; set; } = null!;

        /// <summary>
        /// Collection of Towns - representing the existing towns in a country
        /// </summary>
        public ICollection<Town> Towns { get; set; }
    }
}