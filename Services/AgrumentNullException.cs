using System;
using System.Runtime.Serialization;

namespace AndersenCoreApp.Services
{
    [Serializable]
    internal class AgrumentNullException : Exception
    {
        public AgrumentNullException()
        {
        }

        public AgrumentNullException(string message) : base(message)
        {
        }

        public AgrumentNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AgrumentNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}