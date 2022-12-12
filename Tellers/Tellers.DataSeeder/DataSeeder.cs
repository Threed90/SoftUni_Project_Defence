using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Tellers.DataModels;
using Tellers.DataSeeder.Interfaces;
using Tellers.DbContext;

namespace Tellers.DataSeeder
{
    public class DataSeeder : IDataSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;

        public void SeedAllNonRequiredData(TellersDbContext context)
        {
            var countries = this.GetModels<Country>("Countries.json");

            if (context.Countries.Any() == false)
            {
                context.Countries.AddRange(countries);
            }

            var towns = this.GetModels<Town>("Towns.json");

            if (context.Towns.Any() == false)
            {
                context.Towns.AddRange(towns);
            }

            context.SaveChanges();
        }

        public void SeedAllRequiredData(TellersDbContext context)
        {
            var genres = this.GetModels<Genre>("Genres.json");

            if (context.Genres.Any() == false)
            {
                context.Genres.AddRange(genres);
            }

            var storyTypes = this.GetModels<StoryType>("StoryTypes.json");

            if (context.StoryTypes.Any() == false)
            {
                context.StoryTypes.AddRange(storyTypes);
            }

            var roles = this.GetModels<IdentityRole<Guid>>("Roles.json");

            if(context.Roles.Any() == false)
            {
                context.Roles.AddRange(roles);
            }

            if(context.Users.FirstOrDefault(u => u.UserName == "masterAdmin") == null)
            {
                this.CreateMasterAdminUserAndProfile(context);
                this.AddMasterAdminToHisRole(context);
            }
        }

        

        private IEnumerable<TEntity> GetModels<TEntity>(string fileName)
        {
            var json = File.ReadAllText($@"./JSON/{fileName}");
            var models = JsonSerializer.Deserialize<IEnumerable<TEntity>>(json);

            return models;
        }

        private void CreateMasterAdminUserAndProfile(TellersDbContext context)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser()
            {
                Email = "masterAdmin@tellers.com",
                UserName = "masterAdmin",
                NormalizedEmail = "MASTERADMIN@TELLERS.COM",
                NormalizedUserName = "MASTERADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedOn= DateTime.Now,
                SecurityStamp= Guid.NewGuid().ToString(),
            };

            var passwordHash = hasher.HashPassword(user, "masterAdmin");

            user.PasswordHash= passwordHash;
            context.Users.Add(user);
            context.SaveChanges();

            var adminUser = context.Users.FirstOrDefault(u => u.UserName == "masterAdmin");

            var profile = new Profile()
            {
                UserId = adminUser.Id,
            };
            context.Profiles.Add(profile);
            context.SaveChanges();

            var adminProfile = context.Profiles.FirstOrDefault(p => p.UserId== adminUser.Id);

            adminUser.UserProfileId = adminProfile.Id;
            context.SaveChanges();
        }

        private void AddMasterAdminToHisRole(TellersDbContext context)
        {
            var masterAdmin = context.Users.FirstOrDefault(u => u.UserName == "masterAdmin");
            var role = context.Roles.FirstOrDefault(r => r.Name == "TellerMasterAdmin");

            context.UserRoles.Add(new IdentityUserRole<Guid>()
            {
                RoleId = role.Id,
                UserId = masterAdmin.Id
            });

            context.SaveChanges();
        }
    }
}
