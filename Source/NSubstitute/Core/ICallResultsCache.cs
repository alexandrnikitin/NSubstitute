namespace NSubstitute.Core
{
    public interface ICallResultsCache
    {
        void SetResultForCall(ICall call, IReturn valueToReturn, MatchArgs matchArgs);
        bool HasResultFor(ICall call);
        object GetResult(ICall call);
    }
}