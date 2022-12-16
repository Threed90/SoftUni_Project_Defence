using Tellers.ViewModels.Educations;
using Tellers.ViewModels.WorkingExpirinces;

namespace Tellers.ViewModels.Profiles
{
    public class ProfileInfoViewModel : ProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string? ResidenceCityName { get; set; }
        public string? ResidenceCityCountryName { get; set; }
        public string? ResidenceCityCountryIso { get; set; }

        public string? HomeTownName { get; set; }
        public string? HomeTownCountryName { get; set; }
        public string? HomeTownCountryIso { get; set; }

        public List<WorkingExpViewModel> WorkingExpiriences { get; set; }
        public List<EducationViewModel> Educations { get; set; }
    }
}
