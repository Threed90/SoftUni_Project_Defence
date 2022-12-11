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

        public SeederMenu()
        {
            this.menuType = "main";
        }
        public string StartMessage()
        {
            string delimeter = new string('*', 31);
            StringBuilder sb = new StringBuilder();

            sb
             .AppendLine()
             .AppendLine()
             .AppendLine($"{delimeter}Hello, there!{delimeter}")
             .AppendLine("             This is a helper for data seeding into database");

            string note = "NOTE: To get \"clean\" database just cancel the seeding process from the menu.";
            sb
             .AppendLine(note)
             .AppendLine(new string('*', note.Length))
             .AppendLine()
             .AppendLine(this.GetMenuContent());

            return sb.ToString();
        }

        public (string msg, bool isClosed, int executionState) ExecuteMenu()
        {

            string msg = "";
            bool isClosed = false;
            int executionState = 0;


            ConsoleKeyInfo key = Console.ReadKey();

            if (menuType == "main" && key.Key == ConsoleKey.Escape)
            {
                msg = "Press any key to close DataSeeder...";
                isClosed = true;
                executionState = 0;
            }
            else if (menuType == "main" && (key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1))
            {
                Console.Clear();
                menuType = "sub";
                msg = this.GetMenuContent();
                isClosed = false;
                executionState = 1;
            }
            else if (menuType == "main" && (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2))
            {
                Console.Clear();
                menuType = "sub";
                msg = this.GetMenuContent();
                isClosed = false;
                executionState = 2;
            }
            else if(menuType == "sub" && key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                menuType = "main";
                msg = this.GetMenuContent();
                isClosed = false;
                executionState = 0;
            }
            else
            {
                previousMenuType = menuType;
                menuType = "invalid";
                msg = this.GetMenuContent();
                executionState = -1;
                isClosed = false;
                menuType = previousMenuType;

                if(menuType == "main")
                {
                    msg += Environment.NewLine;
                    msg += this.GetMenuContent();
                }
                else
                {
                    msg += this.GetMenuContent().Split(Environment.NewLine).Last() ?? ""; ;
                }
                
            }


            return (msg, isClosed, executionState);
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
                        .AppendLine("3. Press 'Esc' to close seeder manager. If there are no seedings already - the database will be empty.");
                    break;
                case "sub":
                    sb
                        .AppendLine("Data was seeded successful!")
                        .AppendLine("Press [Enter] to return to main menu.");
                    break;
                case "invalid":
                    sb
                        .AppendLine()
                        .AppendLine("Invalid key!!!")
                        .AppendLine("Please follow the menu instructions.")
                        .AppendLine();
                    break;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
