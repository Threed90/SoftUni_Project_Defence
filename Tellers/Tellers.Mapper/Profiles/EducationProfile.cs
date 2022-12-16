using Tellers.DataModels;
using Tellers.ViewModels.Educations;

namespace Tellers.Mapper.Profiles
{
    public class EducationProfile : AutoMapper.Profile
    {
        public EducationProfile()
        {
            this.CreateMap<Education, EducationViewModel>()
                .ForMember(ev => ev.QualificationName, y => y.MapFrom(e => e.QualificationName))
                .ForMember(ev => ev.EducationInstitutionName, y => y.MapFrom(e => e.EducationInstitutionName ?? ""))
                .ForMember(ev => ev.AdditionalDescription, y => y.MapFrom(e => e.AdditionalDescription ?? ""))
                .ForMember(ev => ev.From, y => y.MapFrom(e => e.From ?? null))
                .ForMember(ev => ev.To, y => y.MapFrom(e => e.To ?? null))
                .ForMember(ev => ev.TownName, y => y.MapFrom(e => e.Town == null ? "" : e.Town.Name))
                .ForMember(ev => ev.CountryName, y => y.MapFrom(e => e.Town == null ? "" : e.Town.Country.Name))
                .ForMember(ev => ev.CountryISO, y => y.MapFrom(e => e.Town == null ? "" : e.Town.Country.IsoCode));

        }
    }
}
