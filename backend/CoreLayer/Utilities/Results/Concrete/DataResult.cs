using CoreLayer.Utilities.Results.Abstract;

namespace CoreLayer.Utilities.Results.Concrete;

public class DataResult<P> : Result, IDataResult<P>
{
    public DataResult(P data, bool success, string message) : base(success, message)
    {
        Data = data;
    }

    public DataResult(P data, bool success) : base(success)
    {
        Data = data;
    }

    public P Data { get; }
}