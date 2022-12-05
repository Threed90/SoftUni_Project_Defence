﻿using Microsoft.AspNetCore.Identity;
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
    }
}