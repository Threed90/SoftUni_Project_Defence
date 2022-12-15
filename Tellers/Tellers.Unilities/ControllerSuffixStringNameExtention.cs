using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.Utilities
{
    public static class ControllerSuffixStringNameExtention
    {
        public static string ReplaceControllerSuffix(this string controlleFullName)
        {
            return controlleFullName.Replace("Controller", string.Empty);
        }
    }
}
