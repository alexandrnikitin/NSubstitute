using System;
#if NET45
using System.Runtime.Serialization;
#endif


namespace NSubstitute.Exceptions
{
#if NET45
    [Serializable]
#endif
    public class CannotCreateEventArgsException : SubstituteException
    {
        public CannotCreateEventArgsException() { }
        public CannotCreateEventArgsException(string message) : base(message) { }
        public CannotCreateEventArgsException(string message, Exception innerException) : base(message, innerException) { }
#if NET45
        protected CannotCreateEventArgsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
    }
}
