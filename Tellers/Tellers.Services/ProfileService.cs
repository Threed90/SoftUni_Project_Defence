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

        public async Task<ProfileInfoViewModel> GetProfileInfo(string profileId, string userId)
        {
            if (string.IsNullOrWhiteSpace(profileId))
            {
                profileId = await this.data.Users.Where(u => u.Id.ToString() == userId).Select(u => u.UserProfile.Id.ToString()).FirstOrDefaultAsync();
            }
            return this.mapper.GetModel<ProfileInfoViewModel, ApplicationUser>(
                    await this.data.Users
                            .Include(u => u.UserProfile)
                            .ThenInclude(p => p.AdditionalInfo)
                            .ThenInclude(b => b.ResidenceCity)
                            .ThenInclude(t => t.Country)
                            .Include(u => u.UserProfile)
                            .ThenInclude(p => p.AdditionalInfo)
                            .ThenInclude(b => b.HomeTown)
                            .ThenInclude(t => t.Country)
                            .Include(u => u.UserProfile)
                            .ThenInclude(p => p.AdditionalInfo)
                            .ThenInclude(b => b.WorkingExpirianceLines)
                            .Include(u => u.UserProfile)
                            .ThenInclude(p => p.AdditionalInfo)
                            .ThenInclude(b => b.EducationLines)
                            .FirstOrDefaultAsync(u => u.UserProfile.Id.ToString() == profileId));

        }

        private IMapWrapper SetMappingConfiguration(IMapWrapper mapper)
        {
            return mapper
                .AddProfile<Education>()
                .AddProfile<WorkingExperience>()    
                .AddProfile<Profile>()
                .ApplyAllMaps();
        }
    }
}
