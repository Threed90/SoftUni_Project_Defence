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

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public Guid BioId { get; set; }
        public Bio Bio { get; set; } = null!;

        [MaxLength(Models.Education.AdditionalDescriptionMaxLength)]
        public string? AdditionalDescription { get; set; }
    }
}