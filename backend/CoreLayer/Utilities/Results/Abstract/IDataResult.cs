namespace CoreLayer.Utilities.Results.Abstract;

public interface IDataResult<P> : IResult
{
    P Data { get; }
}