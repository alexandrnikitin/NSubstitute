using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute.Core;
using NSubstitute.Routing.AutoValues;

namespace NSubstitute.Routing.Handlers
{
    public enum AutoValueBehaviour
    {
        UseValueForSubsequentCalls,
        ReturnAndForgetValue
    }
    public class ReturnAutoValue : ICallHandler
    {
        private readonly IEnumerable<IAutoValueProvider> _autoValueProviders;
        private readonly ICallResultsCache _resultsCache;
        private readonly AutoValueBehaviour _autoValueBehaviour;

        public ReturnAutoValue(AutoValueBehaviour autoValueBehaviour, IEnumerable<IAutoValueProvider> autoValueProviders, ICallResultsCache resultsCache)
        {
            _autoValueProviders = autoValueProviders;
            _resultsCache = resultsCache;
            _autoValueBehaviour = autoValueBehaviour;
        }

        public RouteAction Handle(ICall call)
        {
            if (_resultsCache.HasResultFor(call))
            {
                return RouteAction.Return(_resultsCache.GetResult(call));
            }

            var type = call.GetReturnType();
            var compatibleProviders = _autoValueProviders.Where(x => x.CanProvideValueFor(type)).FirstOrNothing();
            return compatibleProviders.Fold(
                RouteAction.Continue,
                ReturnValueUsingProvider(call, type));
        }

        private Func<IAutoValueProvider, RouteAction> ReturnValueUsingProvider(ICall call, Type type)
        {
            return provider =>
            {
                var valueToReturn = provider.GetValue(type);
                if (_autoValueBehaviour == AutoValueBehaviour.UseValueForSubsequentCalls)
                {
                    _resultsCache.SetResultForCall(call, new ReturnValue(valueToReturn), MatchArgs.AsSpecifiedInCall);
                }
                return RouteAction.Return(valueToReturn);
            };
        }
    }
}