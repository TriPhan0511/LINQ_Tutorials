using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Utilities
{
    internal class Utility
    {
        internal static string Reverse(string value)
        {
            char[] letters = value.ToCharArray();
            Array.Reverse(letters);
            return new string(letters);
        }
    }
}
