using Microsoft.EntityFrameworkCore;

namespace Tellers.DataSeeder.Interfaces
{
    public interface IDataSeeder
    {
        /// <summary>
        /// Use this method to getting only the required data, that is important for the application functionality
        /// </summary>
        /// <returns></returns>
        void SeedAllRequiredData(ModelBuilder builder);

        /// <summary>
        /// Use this method to getting only the required data, that is important for the application functionality from JSON file
        /// </summary>
        /// <returns></returns>
        void SeedAllRequiredDataFromJSON(ModelBuilder builder, string json);

        /// <summary>
        /// Method for data seeding for test purpose
        /// </summary>
        /// <returns></returns>
        void SeedAllNonRequiredData(ModelBuilder builder);

        /// <summary>
        /// Method for data seeding for test purpose from JSON file
        /// </summary>
        /// <returns></returns>
        void SeedAllNonRequiredDataFromJSON(ModelBuilder builder, string json);
    }
}
