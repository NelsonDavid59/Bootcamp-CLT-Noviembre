namespace BootcampCLT.Application.Common.CQRS;

// FUente: https://arg.software/blog/cqrs-without-mediatr/
public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}