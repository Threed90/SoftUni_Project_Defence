using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.DataSeeder.Interfaces
{
    public interface ISeederMenu
    {
        /// <summary>
        /// Create the wellcome messages.
        /// </summary>
        /// <returns></returns>
        string StartMessage();

        /// <summary>
        /// Set the logic behind every pressed key and return tuple. First value of tuple is for message, 
        /// second shows if the menu is closed 
        /// and third shows the state of the pressed key and indicate the logic behind it.
        /// </summary>
        /// <returns></returns>
        (string msg, bool isClosed, int executionState) ExecuteMenu();

    }
}
