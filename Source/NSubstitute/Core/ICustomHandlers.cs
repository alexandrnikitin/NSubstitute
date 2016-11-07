using System.Collections.Generic;

namespace NSubstitute.Core
{
    /// <summary>
    ///     Factory method which creates <see cref="ICallHandler" /> from the <see cref="ISubstituteState" />.
    /// </summary>
    public delegate ICallHandler CallHandlerFactory(ISubstituteState substituteState);

    public interface ICustomHandlers
    {
        IEnumerable<ICallHandler> Handlers { get; }
        IDictionary<object, object> HandlerDataStorage { get; }
        void AddCustomHandlerFactory(CallHandlerFactory factory);
    }
}