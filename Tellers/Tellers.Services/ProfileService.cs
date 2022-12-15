using Microsoft.EntityFrameworkCore;
using Tellers.DataModels;
using Tellers.DbContext;
using Tellers.Mapper.Interfaces;
using Tellers.Services.Interfaces;
using Tellers.ViewModels.Profiles;

namespace Tellers.Services
{
    public class ProfileService : IProfileService
    {
        private readonly TellersDbContext data;
        private readonly IMapWrapper mapper;
        public ProfileService(
            TellersDbContext data,
            IMapWrapper mapper)
        {
            this.data = data;
            this.mapper = this.SetMappingConfiguration(mapper);
        }
        public async Task<ProfileViewModel> GetProfile(string userId)
        {
            return this.mapper.GetModel<ProfileViewModel, Profile>
                (await data.Profiles.FirstOrDefaultAsync(p => p.User.Id.ToString() == userId));
        }

        private IMapWrapper SetMappingConfiguration(IMapWrapper mapper)
        {
            return mapper
                .AddProfile<Profile>()
                .ApplyAllMaps();
        }
    }
}
