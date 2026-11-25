using Microsoft.Extensions.DependencyInjection;

namespace BootcampCLT.Application.Common.CQRS;

// Fuente: https://arg.software/blog/cqrs-without-mediatr/
public class QueryDispatcher(IServiceProvider sp) : IQueryDispatcher
{
    public Task<TResponse> Dispatch<TQuery, TResponse>(
        TQuery query, CancellationToken ct)
        where TQuery : IQuery<TResponse>
    {
        var handler = sp.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
        return handler.Handle(query, ct);
    }
}