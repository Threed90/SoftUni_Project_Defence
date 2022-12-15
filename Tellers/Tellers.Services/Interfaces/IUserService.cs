namespace Tellers.Services.Interfaces
{
    using Utilities.Interfaces;
    public interface IUserService
    {
        Task<IInfoBox> Login(string username, string password, bool rememberMe);
        Task<IInfoBox> Logout();
        Task<IInfoBox> Register(
            string email,
            string username, 
            string password, 
            bool acceptAgreement);

        Task<bool> HasRole(string userId, string role);
    }
}
