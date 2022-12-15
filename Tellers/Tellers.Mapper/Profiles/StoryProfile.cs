using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.ViewModels.Revues;
using Tellers.ViewModels.Story;

namespace Tellers.Mapper.Profiles
{
    public class StoryProfile : AutoMapper.Profile
    {
        public StoryProfile()
        {
            this.CreateMap<Story, StoryDetailsViewModel>()
                .IncludeAllDerived()
                .ForMember(sd => sd.StoryId, s => s.MapFrom(f => (f.Creator == null ? null : f.Id.ToString())))
                .ForMember(sd => sd.CreatorFirstName, s => s.MapFrom(f => (f.Creator == null ? null : f.Creator.FirstName)))
                .ForMember(sd => sd.CreatorId, s => s.MapFrom(f => (f.Creator == null ? null : f.Creator.Id.ToString())))
                .ForMember(sd => sd.CreatorMiddleName, s => s.MapFrom(m => (m.Creator == null ? null : m.Creator.MiddleName)))
                .ForMember(sd => sd.CreatorLastName, s => s.MapFrom(l => (l.Creator == null ? null : l.Creator.LastName)))
                .ForMember(sd => sd.CreatorPseudonym, s => s.MapFrom(p => (p.Creator == null ? null : p.Creator.Pseudonym)))
                .ForMember(sd => sd.CreatorUsername, s => s.MapFrom(u => (u.Creator == null ? null : u.Creator.User.UserName)))
                .ForMember(sd => sd.Year, s => s.MapFrom(date => date.CreatedOn.Year))
                .ForMember(sd => sd.Month, s => s.MapFrom(date => date.CreatedOn.ToString("MMMM", CultureInfo.GetCultureInfo("us-US"))))
                .ForMember(sd => sd.Day, s => s.MapFrom(date => date.CreatedOn.Day))
                .ForMember(sd => sd.Revues, s => s.MapFrom(r => r.Revues.ToList()));
                
        }
    }
}
