using Microsoft.EntityFrameworkCore;
using Tellers.DbContext;

namespace Tellers.DataSeeder.Interfaces
{
    public interface IDataSeeder
    {
        /// <summary>
        /// Use this method to getting only the required data, that is important for the application functionality
        /// </summary>
        /// <returns></returns>
        void SeedAllRequiredData(TellersDbContext context);

        /// <summary>
        /// Method for data seeding for test purpose
        /// </summary>
        /// <returns></returns>
        void SeedAllNonRequiredData(TellersDbContext context);

    }
}
