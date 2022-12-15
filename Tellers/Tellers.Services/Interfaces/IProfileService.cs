using Tellers.ViewModels.Profiles;

namespace Tellers.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetProfile(string userId);
    }
}
