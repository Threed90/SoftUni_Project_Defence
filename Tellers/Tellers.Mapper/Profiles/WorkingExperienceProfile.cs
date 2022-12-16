using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.ViewModels.WorkingExpirinces;

namespace Tellers.Mapper.Profiles
{
    public class WorkingExperienceProfile : AutoMapper.Profile
    {
        public WorkingExperienceProfile()
        {
            this.CreateMap<WorkingExperience, WorkingExpViewModel>()
                .ForMember(wv => wv.ActivitiesAndResponces, y => y.MapFrom(w => w.ActivitiesAndResponces ?? ""))
                .ForMember(wv => wv.Position, y => y.MapFrom(w => w.Position))
                .ForMember(wv => wv.EmployerName, y => y.MapFrom(w => w.EmployerName ?? ""))
                .ForMember(wv => wv.TownName, y => y.MapFrom(w => w.Town == null ? "" : w.Town.Name))
                .ForMember(wv => wv.CountryName, y => y.MapFrom(w => w.Town == null ? "" : w.Town.Country.Name))
                .ForMember(wv => wv.CountryISO, y => y.MapFrom(w => w.Town == null ? "" : w.Town.Country.IsoCode))
                .ForMember(wv => wv.From, y => y.MapFrom(w => w.From))
                .ForMember(wv => wv.To, y => y.MapFrom(w => w.To));
        }
    }
}
