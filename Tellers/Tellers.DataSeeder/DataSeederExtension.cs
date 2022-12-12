using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Tellers.DataSeeder.Interfaces;
using Tellers.DbContext;

namespace Tellers.DataSeeder
{
    public static class DataSeederExtension
    {
        public static void SeedData(
            this TellersDbContext context,
            ISeederMenu? menu = null,
            IDataSeeder? seeder = null)
        {
            ISeederMenu seederMenu = menu ?? new SeederMenu();
            IDataSeeder dataSeeder = seeder ?? new DataSeeder();

                Console.WriteLine(seederMenu.StartMessage());
            

            while (true)
            {

                (string msg, bool isClosed, int executionState) = seederMenu.ExecuteMenu();

                if (msg != string.Empty)
                    Console.WriteLine(msg);

                if (isClosed)
                {
                    break;
                }

                if (executionState == -1 || executionState == 0)
                {
                    continue;
                }
                else if (executionState == 1)
                {

                    dataSeeder.SeedAllRequiredData(context);
                }
                else
                {
                    dataSeeder.SeedAllNonRequiredData(context);
                }
            }


        }
    }
}
