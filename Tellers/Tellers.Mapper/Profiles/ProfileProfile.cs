using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.ViewModels.Profiles;
using Tellers.ViewModels.WorkingExpirinces;

namespace Tellers.Mapper.Profiles
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            this.CreateMap<DataModels.Profile, ProfileViewModel>()
                .ForMember(pv => pv.UserId, y => y.MapFrom(p => p.User.Id.ToString()))
                .ForMember(pv => pv.AdditionalInfoId, y => y.MapFrom(p => p.AdditionalInfo.Id.ToString()));

            this.CreateMap<ApplicationUser, ProfileInfoViewModel>()
                .ForMember(pi => pi.UserId, y => y.MapFrom(u => u.Id.ToString()))
                .ForMember(pi => pi.UserName, y => y.MapFrom(u => u.UserName))
                .ForMember(pi => pi.Email, y => y.MapFrom(u => u.Email))
                .ForMember(pi => pi.FirstName, y => y.MapFrom(u => (u.UserProfile.FirstName ?? "")))
                .ForMember(pi => pi.MiddleName, y => y.MapFrom(u => (u.UserProfile.MiddleName ?? "")))
                .ForMember(pi => pi.LastName, y => y.MapFrom(u => (u.UserProfile.LastName ?? "")))
                .ForMember(pi => pi.PictureUrl, y => y.MapFrom(u => (u.UserProfile.PictureUrl ?? "")))
                .ForMember(pi => pi.Pseudonym, y => y.MapFrom(u => (u.UserProfile.Pseudonym ?? "")))
                .ForMember(pi => pi.AdditionalInfoId, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? "" : u.UserProfile.AdditionalInfoId.ToString() ?? null))
                .ForMember(pi => pi.ResidenceCityName, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? "" : u.UserProfile.AdditionalInfo.ResidenceCity.Name ?? ""))
                .ForMember(pi => pi.ResidenceCityCountryName, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? "" : u.UserProfile.AdditionalInfo.ResidenceCity.Country.Name ?? ""))
                .ForMember(pi => pi.ResidenceCityCountryIso, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? "" : u.UserProfile.AdditionalInfo.ResidenceCity.Country.IsoCode ?? ""))
                .ForMember(pi => pi.HomeTownName, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? "" : u.UserProfile.AdditionalInfo.HomeTown.Name ?? ""))
                .ForMember(pi => pi.HomeTownCountryName, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? "" : u.UserProfile.AdditionalInfo.HomeTown.Country.Name ?? ""))
                .ForMember(pi => pi.HomeTownCountryIso, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? "" : u.UserProfile.AdditionalInfo.HomeTown.Country.IsoCode ?? ""))
                .ForMember(pi => pi.WorkingExpiriences, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? null : u.UserProfile.AdditionalInfo.WorkingExpirianceLines.OrderByDescending(w => w.From).ThenByDescending(w => w.To).ThenBy(w => w.Position).ToList() ?? null))
                .ForMember(pi => pi.Educations, y => y.MapFrom(u => u.UserProfile.AdditionalInfo == null ? null : u.UserProfile.AdditionalInfo.EducationLines.OrderByDescending(e => e.From).ThenByDescending(e => e.To).ThenBy(e => e.QualificationName).ToList() ?? null));
        }
    }
}
