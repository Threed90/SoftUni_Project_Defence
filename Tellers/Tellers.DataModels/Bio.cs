namespace Tellers.DataModels
{
    /// <summary>
    /// The class idea is to give option to users to represent their biographies.
    /// Class information is very private in the personal matter, so identification is chosen as a GUID.
    /// </summary>
    public class Bio
    {
        /// <summary>
        /// Class constructor. Initialize needed collection and guid id.
        /// </summary>
        public Bio()
        {
            this.Id = Guid.NewGuid();
            this.WorkingExpirianceLines = new HashSet<WorkingExperience>();
            this.EducationLines= new HashSet<Education>();
        }

        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; }


        public Guid ProfileId { get; set; }

        public Profile Profile { get; set; }

        /// <summary>
        /// Reference to the residence town data model
        /// </summary>
        public int? ResidenceCityId { get; set; }
        public Town? ResidenceCity { get; set; }

        /// <summary>
        /// Reference to the home town data model
        /// </summary>
        public int? HomeTownId { get; set; }
        public Town? HomeTown { get; set; }

        /// <summary>
        /// Collection of WorkingExperiance - representing the working expiriance of a person.
        /// </summary>
        public ICollection<WorkingExperience> WorkingExpirianceLines { get; set; }

        /// <summary>
        /// Collection of Education - representing the education level (profesional qualifications) of a person.
        /// </summary>
        public ICollection<Education> EducationLines { get; set; }
    }
}