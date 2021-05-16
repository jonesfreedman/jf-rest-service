using System;
using System.Runtime.Serialization;

namespace CrudService.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string message) { }
        public NotFoundException(string message, Exception innerException) { }
        protected NotFoundException(SerializationInfo info, StreamingContext context) { }
    }
}
