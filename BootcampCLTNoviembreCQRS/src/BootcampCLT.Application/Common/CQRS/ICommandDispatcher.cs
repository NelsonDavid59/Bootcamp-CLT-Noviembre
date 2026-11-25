namespace BootcampCLT.Application.Common.CQRS;

// Fuente: https://arg.software/blog/cqrs-without-mediatr/
public interface ICommandDispatcher
{
    Task Dispatch<TCommand>(TCommand command, CancellationToken ct)
        where TCommand : ICommand;

    Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command, CancellationToken ct)
        where TCommand : ICommand<TResponse>;
}