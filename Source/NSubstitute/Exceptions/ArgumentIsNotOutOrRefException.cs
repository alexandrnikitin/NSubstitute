using System;
#if !DNXCORE50
using System.Runtime.Serialization;
#endif

namespace NSubstitute.Exceptions
{
    public class ArgumentIsNotOutOrRefException : SubstituteException
    {
        const string WhatProbablyWentWrong = "Could not set argument {0} ({1}) as it is not an out or ref argument.";
        public ArgumentIsNotOutOrRefException(int argumentIndex, Type argumentType) : base(string.Format(WhatProbablyWentWrong, argumentIndex, argumentType.Name)) { }
#if !DNXCORE50
        protected ArgumentIsNotOutOrRefException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
    }
}