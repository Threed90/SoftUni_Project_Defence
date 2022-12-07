namespace Tellers.Services.Interfaces
{
    using Utilities.Interfaces;
    public interface IUserService
    {
        Task<IInfoBox> Login(string username, string password, bool rememberMe);
        Task<IInfoBox> Logout();
        Task<IInfoBox> Register(
            string firstName,
            string? middleName,
            string lastName,
            string email,
            string username, 
            string password, 
            bool acceptAgreement);
    }
}
