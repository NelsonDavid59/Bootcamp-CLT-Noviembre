namespace BootcampCLT.Application.Common.CQRS;

// Fuente: https://arg.software/blog/cqrs-without-mediatr
public interface IQueryDispatcher
{
    Task<TResponse> Dispatch<TQuery, TResponse>(TQuery query, CancellationToken ct)
        where TQuery : IQuery<TResponse>;
}