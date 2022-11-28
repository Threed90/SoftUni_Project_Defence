namespace Tellers.DataModels
{
    public class WorkingExperience
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Models.WorkingExperience.PositionMaxLength)]
        public string Position { get; set; } = null!;

        [Required]
        [MaxLength(Models.WorkingExperience.EmployerNameMaxLength)]
        public string EmployerName { get; set; } = null!;

        public int? TownId { get; set; }
        public Town? Town { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        [MaxLength(Models.WorkingExperience.ActivitiesAndResponcesMaxLength)]
        public string? ActivitiesAndResponces { get; set; }
    }
}