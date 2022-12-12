using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.DataSeeder.Interfaces;

namespace Tellers.DataSeeder
{
    public class SeederMenu : ISeederMenu
    {
        private string menuType;
        private string previousMenuType;
        private bool isRequiredDataSeeded = false;
        public SeederMenu()
        {
            this.menuType = "main";
        }
        public string StartMessage()
        {
            string delimeter = new string('*', 25);
            StringBuilder sb = new StringBuilder();

            sb
             .AppendLine($"{delimeter}Hello, there!{delimeter}")
             .AppendLine("     This is a helper for data seeding into database");

            string note = "NOTE: You need to reset database to perform data seeding again.";
            string warning = "   WARNING: First seed required data, then non required.";
            string warningTwo = "WARNING: Seeder is using auto migration - data losing possible";

            sb
             .AppendLine(note)
             .AppendLine(warning)
             .AppendLine(warningTwo)
             .AppendLine(new string('*', note.Length))
             .AppendLine()
             .AppendLine(this.GetMenuContent());

            return sb.ToString();
        }

        public (string msg, bool isClosed, int executionState) ExecuteMenu()
        {

            string message = "";
            bool isClosed = false;
            int executionState = 0;


            ConsoleKeyInfo key = Console.ReadKey();

            if (menuType == "main" && key.Key == ConsoleKey.F2)
            {
                message = "";
                isClosed = true;
                executionState = 0;
            }
            else if (menuType == "main" && (key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1))
            {
                Console.Clear();
                menuType = "sub";
                message = this.GetMenuContent();
                isClosed = false;
                isRequiredDataSeeded = true;
                executionState = 1;
            }
            else if (menuType == "main" && (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2) && isRequiredDataSeeded)
            {
                Console.Clear();
                menuType = "sub";
                message = this.GetMenuContent();
                isClosed = false;
                executionState = 2;
            }
            else if (menuType == "sub" && key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                menuType = "main";
                message = this.GetMenuContent();
                isClosed = false;
                executionState = 0;
            }
            else
            {
                Console.Clear();
                previousMenuType = menuType;
                menuType = "invalid";
                message = this.GetMenuContent();
                executionState = -1;
                isClosed = false;
                menuType = previousMenuType;

                if (menuType == "main")
                {
                    message += Environment.NewLine;
                    message += this.GetMenuContent();
                }
                else
                {
                    message += this.GetMenuContent().Split(Environment.NewLine).Last() ?? ""; ;
                }

            }




            return (message, isClosed, executionState);
        }

        private string GetMenuContent()
        {
            StringBuilder sb = new StringBuilder();
            switch (this.menuType)
            {
                case "main":
                    sb
                        .AppendLine("1. Press '1' to seed required data into database.")
                        .AppendLine("2. Press '2' to seed non required data into database.")
                        .AppendLine("3. Press 'F2' to close seeder manager. If there are no seedings already - the database will be empty.");
                    break;
                case "sub":
                    sb
                        .AppendLine("Data was seeded successful!")
                        .AppendLine("Press [Enter] to return to main menu.");
                    break;
                case "invalid":
                    sb
                        .AppendLine()
                        .AppendLine("Invalid key or trying to seed non required data before required data...")
                        .AppendLine("Please follow the menu instructions.")
                        .AppendLine();
                    break;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
