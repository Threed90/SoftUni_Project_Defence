using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellers.Utilities.Interfaces;

namespace Tellers.Utilities
{
    public class InfoBox : IInfoBox
    {
        public bool IsSucceeded { get; set; }

        public string Message { get; set; } = null!;
    }
}
