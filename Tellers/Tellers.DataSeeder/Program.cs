// A console app for test data seeding and master admin user seeding:

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Tellers.DbContext;


IConfigurationBuilder builder = new ConfigurationBuilder()
                                    .AddUserSecrets<Program>();
var configuration = builder.Build();

DbContextOptionsBuilder<TellersDbContext> optionBuilder = new DbContextOptionsBuilder<TellersDbContext>();
optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

TellersDbContext db = new TellersDbContext(optionBuilder.Options);



