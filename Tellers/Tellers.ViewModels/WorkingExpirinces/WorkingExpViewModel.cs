using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.ViewModels.WorkingExpirinces
{
    public class WorkingExpViewModel
    {
        public string? Position { get; set; }
        public string? EmployerName { get; set; }

        public string? TownName { get; set; }

        public string? CountryName { get; set; }
        public string? CountryISO { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? ActivitiesAndResponces { get; set; }
    }
}
