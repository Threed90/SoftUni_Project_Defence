namespace Tellers.DataModels
{
    public class Bio
    {
        public Bio()
        {
            this.Id = Guid.NewGuid();
            this.WorkingExpirianceLines = new HashSet<WorkingExperience>();
            this.EducationLines= new HashSet<Education>();
        }

        public Guid Id { get; set; }

        public int? ResidenceCityId { get; set; }
        public Town? ResidenceCity { get; set; }

        public int? HomeTownId { get; set; }
        public Town? HomeTown { get; set; }

        public ICollection<WorkingExperience> WorkingExpirianceLines { get; set; }
        public ICollection<Education> EducationLines { get; set; }
    }
}