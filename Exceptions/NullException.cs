using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndersenCoreApp.Exceptions
{
    public class NullException : Exception
    {
        public NullException(string message) : base(message) { }
    }
}
