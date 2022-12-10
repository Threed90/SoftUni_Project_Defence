using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tellers.DataModels;

namespace Tellers.DbContext
{
    public class TellersDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public TellersDbContext(DbContextOptions<TellersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bio> Bios { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Education> Educations { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Profile> Profiles { get; set; } = null!;
        public DbSet<Revue> Revues { get; set; } = null!;
        public DbSet<Story> Stories { get; set; } = null!;
        public DbSet<StoryType> StoryTypes { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<WorkingExperience> WorkingExperiences { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<ApplicationUser>(u => u.UserProfileId);

            builder.Entity<ApplicationUser>()
                .HasOne(a => a.UserProfile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);

            builder.Entity<Profile>()
                .HasOne(p => p.AdditionalInfo)
                .WithOne(b => b.Profile)
                .HasForeignKey<Bio>(b => b.ProfileId);

            builder.Entity<Bio>()
                .HasOne(b => b.Profile)
                .WithOne(p => p.AdditionalInfo)
                .HasForeignKey<Profile>(p => p.AdditionalInfoId);

            builder.Entity<Profile>()
                .HasMany(p => p.OtherSideFriends)
                .WithMany(p => p.MySideFriends);

            builder.Entity<Profile>()
                .HasMany(p => p.Followers)
                .WithMany(p => p.Followings);

            

            //builder.Entity<WorkingExperience>()
            //    .HasNoKey();
            base.OnModelCreating(builder);
        }
    }
}