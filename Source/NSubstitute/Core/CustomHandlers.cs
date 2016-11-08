using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NSubstitute.Core
{
    public class CustomHandlers : ICustomHandlers
    {
        private readonly ISubstituteState _substituteState;
        private readonly List<ICallHandler> _handlers = new List<ICallHandler>();

        public IEnumerable<ICallHandler> Handlers => _handlers;
        public IDictionary<object, object> HandlerDataStorage { get; } = new ConcurrentDictionary<object, object>();

        public CustomHandlers(ISubstituteState substituteState)
        {
            _substituteState = substituteState;
        }

        public void AddCustomHandlerFactory(CallHandlerFactory factory)
        {
            _handlers.Add(factory.Invoke(_substituteState));
        }
    }
}