namespace Tellers.DataModels
{
    public class WorkingExperience
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(Models.WorkingExperience.PositionMaxLength)]
        public string Position { get; set; } = null!;

        [MaxLength(Models.WorkingExperience.EmployerNameMaxLength)]
        public string? EmployerName { get; set; } = null!;

        public int? TownId { get; set; }
        public Town? Town { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public Guid BioId { get; set; }
        public Bio Bio { get; set; } = null!;

        [MaxLength(Models.WorkingExperience.ActivitiesAndResponcesMaxLength)]
        public string? ActivitiesAndResponces { get; set; }
    }
}