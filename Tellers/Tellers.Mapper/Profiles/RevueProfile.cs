using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.ViewModels.Revues;

namespace Tellers.Mapper.Profiles
{
    public class RevueProfile : AutoMapper.Profile
    {
        public RevueProfile()
        {
            this.CreateMap<Revue, ReadRevueViewModel>()
                .ForMember(rd => rd.CreatorFirstName, r => r.MapFrom(rc => (rc.Profile == null ? null : rc.Profile.FirstName)))
                .ForMember(rd => rd.CreatorMiddleName, r => r.MapFrom(rc => (rc.Profile == null ? null : rc.Profile.MiddleName)))
                .ForMember(rd => rd.CreatorLastName, r => r.MapFrom(rc => (rc.Profile == null ? null : rc.Profile.LastName)))
                .ForMember(rd => rd.CreatorUsername, r => r.MapFrom(rc => (rc.Profile == null ? null : rc.Profile.User.UserName)))
                .ForMember(rd => rd.CreatorPseudonym, r => r.MapFrom(rc => (rc.Profile == null ? null : rc.Profile.Pseudonym)))
                .ForMember(rd => rd.CreatorPictureUrl, r => r.MapFrom(rc => (rc.Profile == null ? null : rc.Profile.PictureUrl)))
                .ForMember(rd => rd.StoryId, r => r.MapFrom(rc => rc.StoryId));

        }
    }
}
