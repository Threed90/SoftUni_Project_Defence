using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.ViewModels.Profiles
{
    public class ProfileViewModel
    {
        public string? FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; } = null!;
        public string? PictureUrl { get; set; }
        public string? Pseudonym { get; set; }
        public string? AdditionalInfoId { get; set; }
        public string? UserId { get; set; }

    }
}
