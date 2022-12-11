using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Tellers.DataSeeder.Interfaces;

namespace Tellers.DataSeeder
{
    public static class DataSeederExtension
    {
        private static bool isExecuted = false;
        public static void SeedData(
            this ModelBuilder builder,
            ISeederMenu? menu = null,
            IDataSeeder? seeder = null)
        {
            ISeederMenu seederMenu = menu ?? new SeederMenu();
            IDataSeeder dataSeeder = seeder ?? new DataSeeder();


            Console.WriteLine(seederMenu.StartMessage());
            Stopwatch watch = new Stopwatch();
            watch.Start();

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

                    dataSeeder.SeedAllRequiredData(builder);
                }
                else if (executionState == 2)
                {
                    dataSeeder.SeedAllNonRequiredData(builder);
                }
                else if (executionState == 99 && watch.Elapsed.TotalSeconds >= 7)
                {
                    if(isExecuted == false)
                    {
                        Console.WriteLine("Time out! You does not press any key for more than 20 second...");
                        Console.WriteLine("Seeder data manager is closing...");
                        isExecuted = true;
                    }
                    
                    return;
                }
            }


        }
    }
}
