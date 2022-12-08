using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.Mapper.Exceptions
{
    public class NoAppliedMappingsException : Exception
    {
        private const string msg = "There are no applied mappings!";
        public NoAppliedMappingsException()
            : base(msg)
        {
        }
    }
}
