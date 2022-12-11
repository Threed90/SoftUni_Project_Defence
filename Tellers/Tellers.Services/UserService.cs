namespace Tellers.Services
{
    using Microsoft.AspNetCore.Identity;

    using DataModels;
    using DbContext;
    using Services.Interfaces;
    using Utilities;
    using Utilities.Interfaces;
    using Tellers.Constants;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly TellersDbContext data;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public UserService(
            TellersDbContext data, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.data = data;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IInfoBox> Login(string username, string password, bool rememberMe)
        {

            var result = await signInManager.PasswordSignInAsync(username, password, rememberMe, false);

            if(result.Succeeded == false)
            {
                return GetInfoBox(false, OutputMessages.AppUser.LoginFailed);
            }

            return GetInfoBox(true, string.Empty);
        }

        public async Task<IInfoBox> Register(
            string email,
            string username, 
            string password, 
            bool acceptAgreement)
        {
            var user = new ApplicationUser()
            {
                Email = email,
                UserName = username
            };

            var result = await userManager.CreateAsync(user, password);

            if(result.Succeeded == false)
            {
                StringBuilder sb = new();
                sb.AppendLine(OutputMessages.AppUser.RegisterFailed);

                foreach (var err in result.Errors)
                {
                    sb.AppendLine(err.Description);
                }

                return GetInfoBox(false, sb.ToString().TrimEnd()); 
            }

            var roleName = await roleManager.FindByNameAsync(RoleNames.CommonUserRoleName);

            if (roleName == null)
            {
                //maybe need id and cuncurrencyStamp
                await roleManager.CreateAsync(new IdentityRole<Guid>()
                {
                    Name = RoleNames.CommonUserRoleName,
                    NormalizedName = RoleNames.NormalizedCommonUserRoleName
                });
            }

            await userManager.AddToRoleAsync(user, RoleNames.CommonUserRoleName);

            var registredUser = await userManager.FindByNameAsync(username);

            var profile = new Profile()
            {
                //FirstName = firstName,
                //MiddleName = middleName,
                //LastName = lastName,
                User = registredUser
            };

            await this.data.Profiles.AddAsync(profile);

            await this.data.SaveChangesAsync();

            var createdProfile = await this.data.Profiles.FirstOrDefaultAsync(p => p.UserId == user.Id);

            if (createdProfile != null)
            {
                registredUser.UserProfileId = createdProfile.Id;
            }

            await this.data.SaveChangesAsync();

            return GetInfoBox(true, string.Empty);
        }


        public async Task<IInfoBox> Logout()
        {
            await signInManager.SignOutAsync();

            return GetInfoBox(true, string.Empty);
        }

        //private methods:

        private IInfoBox GetInfoBox(bool isSucceeded, string message)
         => new InfoBox()
         {
             IsSucceeded = isSucceeded,
             Message = message
         };
    }
}
