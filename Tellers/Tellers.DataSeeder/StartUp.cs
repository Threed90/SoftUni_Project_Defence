using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Tellers.DataModels;
using Tellers.DbContext;

namespace Tellers.DataSeeder
{
    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<DataSeeder>()
                .Build();

            var connection = config.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<TellersDbContext>()
                .UseSqlServer(connection);

            var db = new TellersDbContext(builder.Options);

            db.Database.Migrate();

            db.SeedData();
        }
    }
}