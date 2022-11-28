namespace Tellers.DataModels
{
    public class Education
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.Education.QualificationNameMaxLength)]
        public string QualificationName { get; set; } = null!;

        [Required]
        [MaxLength(Models.Education.EducationInstitutionNameMaxLength)]
        public string EducationInstitutionName { get; set; } = null!;

        public int? TownId { get; set; }
        public Town? Town { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; } 

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        [MaxLength(Models.Education.AdditionalDescriptionMaxLength)]
        public string? AdditionalDescription { get; set; }
    }
}