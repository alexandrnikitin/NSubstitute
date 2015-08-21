using System;
#if NET4 || NET45
using System.Runtime.Serialization;
#endif


namespace NSubstitute.Exceptions
{
    public class CannotCreateEventArgsException : SubstituteException
    {
        public CannotCreateEventArgsException() { }
        public CannotCreateEventArgsException(string message) : base(message) { }
        public CannotCreateEventArgsException(string message, Exception innerException) : base(message, innerException) { }
#if NET4 || NET45
        protected CannotCreateEventArgsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
    }
}