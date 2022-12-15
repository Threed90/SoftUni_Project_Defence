using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataModels;
using Tellers.ViewModels.Profiles;

namespace Tellers.Mapper.Profiles
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            this.CreateMap<DataModels.Profile, ProfileViewModel>()
                .ForMember(pv => pv.UserId, y => y.MapFrom(p => p.User.Id.ToString()))
                .ForMember(pv => pv.AdditionalInfoId, y => y.MapFrom(p => p.AdditionalInfo.Id.ToString()));
        }
    }
}
