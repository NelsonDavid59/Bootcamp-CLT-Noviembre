using Microsoft.Extensions.DependencyInjection;

namespace BootcampCLT.Application.Common.CQRS;

// Fuente: https://arg.software/blog/cqrs-without-mediatr/
public class CommandDispatcher(IServiceProvider sp) : ICommandDispatcher
{
    public Task Dispatch<TCommand>(TCommand command, CancellationToken ct)
        where TCommand : ICommand
    {
        var handler = sp.GetRequiredService<ICommandHandler<TCommand>>();
        return handler.Handle(command, ct);
    }

    public Task<TResponse> Dispatch<TCommand, TResponse>(
        TCommand command, CancellationToken ct)
        where TCommand : ICommand<TResponse>
    {
        var handler = sp.GetRequiredService<ICommandHandler<TCommand, TResponse>>();
        return handler.Handle(command, ct);
    }
}