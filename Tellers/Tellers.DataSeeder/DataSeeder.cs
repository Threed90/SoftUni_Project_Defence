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
        private string masterAdminProfileId = "";

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

            var profiles = this.GetModels<Profile>("Profiles.json");

            if (context.Profiles.Where(p => p.Id.ToString() != this.masterAdminProfileId).Any() == false)
            {
                context.Profiles.AddRange(profiles);
            }

            if (context.Users.Where(u => u.UserName != "masterAdmin").Any() == false)
            {
                this.CreateTestUsers(context, profiles.ToList());
                this.SetRolesForTestUsers(context);
            }

            var bios = this.GetModels<Bio>("Bios.json");

            if(context.Bios.Any() == false) 
            { 
                this.AddBioToProfiles(context, bios);
            }

            var workingExps = this.GetModels<WorkingExperience>("WorkingExp.json");

            if(context.WorkingExperiences.Any() == false)
            {
                context.WorkingExperiences.AddRange(workingExps);
            }

            var educations = this.GetModels<Education>("Educations.json");
            if(context.Educations.Any() == false)
            {
                context.Educations.AddRange(educations);
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

            if (context.Roles.Any() == false)
            {
                context.Roles.AddRange(roles);
            }

            if (context.Users.FirstOrDefault(u => u.UserName == "masterAdmin") == null)
            {
                this.CreateMasterAdminUserAndProfile(context);
                this.AddMasterAdminToHisRole(context);
            }
        }


        private void AddBioToProfiles(TellersDbContext context, IEnumerable<Bio> bios)
        {
            context.Bios.AddRange(bios);
            context.SaveChanges();

            foreach (var bio in bios)
            {
                var profile = context.Profiles.FirstOrDefault(p => p.Id == bio.ProfileId);

                if(profile != null)
                {
                    profile.AdditionalInfoId = bio.Id;
                }
            }
            
            context.SaveChanges();
        }

        private void SetRolesForTestUsers(TellersDbContext context)
        {
            var testUsers = context.Users.Where(u => u.UserName != "masterAdmin");

            var userRoles = new List<IdentityUserRole<Guid>>();

            foreach (var user in testUsers)
            {
                userRoles.Add(new IdentityUserRole<Guid>()
                {
                    UserId = user.Id,
                    RoleId = new Guid("99e4a88f-e972-41ae-909f-256545b0dd4b")
                });
            }

            context.UserRoles.AddRange(userRoles);

            context.SaveChanges();
        }

        private void CreateTestUsers(TellersDbContext context, List<Profile> profiles)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> users = new()
            {
                new ApplicationUser()
                {
                    Email = "testUserOne@mail.com",
                    UserName = "testUserOne",
                    NormalizedEmail = "TESTUSERONE@MAIL.COM",
                    NormalizedUserName = "TESTUSERONE",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    CreatedOn= DateTime.Now,
                    SecurityStamp= Guid.NewGuid().ToString(),
                    UserProfileId = profiles[0].Id,
                    
                },
                new ApplicationUser()
                {
                    Email = "testUserTwo@mail.com",
                    UserName = "testUserTwo",
                    NormalizedEmail = "TESTUSERTWO@MAIL.COM",
                    NormalizedUserName = "TESTUSERTWO",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    CreatedOn= DateTime.Now,
                    SecurityStamp= Guid.NewGuid().ToString(),
                    UserProfileId = profiles[1].Id
                },
                new ApplicationUser()
                {
                    Email = "testUserThree@mail.com",
                    UserName = "testUserThree",
                    NormalizedEmail = "TESTUSERTHREE@MAIL.COM",
                    NormalizedUserName = "TESTUSERTHREE",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    CreatedOn= DateTime.Now,
                    SecurityStamp= Guid.NewGuid().ToString(),
                    UserProfileId = profiles[2].Id,
                    
                }
            };

            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, user.UserName);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            var dbUsers = context.Users.Where(u => u.UserName != "masterAdmin");

            var dbProfiles = context.Profiles.Where(p => p.Id.ToString() != this.masterAdminProfileId);

            foreach (var user in dbUsers)
            {
                var profile = dbProfiles.FirstOrDefault(p => p.Id == user.UserProfileId);

                if(profile != null)
                {
                    profile.UserId= user.Id;
                }
            }
            context.SaveChanges();

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
                CreatedOn = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var passwordHash = hasher.HashPassword(user, "masterAdmin");

            user.PasswordHash = passwordHash;
            context.Users.Add(user);
            context.SaveChanges();

            var adminUser = context.Users.FirstOrDefault(u => u.UserName == "masterAdmin");

            var profile = new Profile()
            {
                UserId = adminUser.Id,
            };
            context.Profiles.Add(profile);
            context.SaveChanges();

            var adminProfile = context.Profiles.FirstOrDefault(p => p.UserId == adminUser.Id);

            this.masterAdminProfileId = adminProfile.Id.ToString();
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

