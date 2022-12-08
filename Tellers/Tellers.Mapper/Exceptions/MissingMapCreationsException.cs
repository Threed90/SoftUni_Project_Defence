using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.Mapper.Exceptions
{
    public class MissingMapCreationsException : Exception
    {
        private const string msg = "You must create at least one map using the CreateMap() method.";
        public MissingMapCreationsException()
            : base(msg)
        {
        }

        public MissingMapCreationsException(string? message) 
            : base(message)
        {
        }
    }
}
