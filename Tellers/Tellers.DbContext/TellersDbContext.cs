using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Tellers.DataModels;

namespace Tellers.DbContext
{
    public class TellersDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public TellersDbContext(DbContextOptions<TellersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bio> Bios { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Revue> Revues { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryType> StoryTypes { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<WorkingExperience> WorkingExperiences { get; set; }
    }
}