using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.ViewModels.Educations
{
    public class EducationViewModel
    {
        public string? QualificationName { get; set; }
        public string? EducationInstitutionName { get; set; }

        public string? TownName { get; set; }

        public string? CountryName { get; set; }
        public string? CountryISO { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public string? AdditionalDescription { get; set; }

    }
}
