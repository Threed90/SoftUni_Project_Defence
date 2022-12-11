using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Tellers.DataSeeder.Interfaces;

namespace Tellers.DataSeeder
{
    public static class DataSeederExtension
    {
        public static void SeedData(
            this ModelBuilder builder,
            ISeederMenu? menu = null,
            IDataSeeder? seeder = null)
        {
            ISeederMenu seederMenu = menu ?? new SeederMenu();
            IDataSeeder dataSeeder = seeder ?? new DataSeeder();

            Console.WriteLine(seederMenu.StartMessage());

            while (true)
            {
                
                (string msg, bool isClosed, int executionState) = seederMenu.ExecuteMenu();

                Console.WriteLine(msg);

                if (isClosed)
                {
                    break;
                }

                if(executionState == -1 || executionState == 0)
                {
                    continue;
                }
                else if(executionState == 1)
                {
                    dataSeeder.SeedAllRequiredData(builder);
                }
                else if(executionState == 2)
                {
                    dataSeeder.SeedAllNonRequiredData(builder);
                }
            }


        }
    }
}
