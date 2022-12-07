using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.Utilities.Interfaces
{
    public interface IInfoBox
    {
        bool IsSucceeded { get; }

        string Message { get; }
    }
}
