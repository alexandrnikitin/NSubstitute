namespace NSubstitute.Core
{
    public class CallResultsCache : ICallResultsCache
    {
        private readonly ICallResults _callResults;
        private readonly ICallSpecificationFactory _callSpecificationFactory;

        public CallResultsCache(ICallResults callResults, ICallSpecificationFactory callSpecificationFactory)
        {
            _callResults = callResults;
            _callSpecificationFactory = callSpecificationFactory;
        }

        public void SetResultForCall(ICall call, IReturn valueToReturn, MatchArgs matchArgs)
        {
            var spec = _callSpecificationFactory.CreateFrom(call, matchArgs);
            _callResults.SetResult(spec, valueToReturn);
        }

        public bool HasResultFor(ICall call)
        {
            return _callResults.HasResultFor(call);
        }

        public object GetResult(ICall call)
        {
            return _callResults.GetResult(call);
        }
    }
}