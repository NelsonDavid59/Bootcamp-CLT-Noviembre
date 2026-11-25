using BootcampCLT.Application.Common.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace BootcampCLT;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Fuente: https://arg.software/blog/cqrs-without-mediatr/
        // https://milanjovanovic.tech/blog/improving-aspnetcore-dependency-injection-with-scrutor
        // Para que la escalabilidad de injecciones de command y query handlers
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(DependencyInjection))
            .AddClasses(c => c
                    .AssignableTo(typeof(IQueryHandler<,>))
                    .Where(type => !type.ContainsGenericParameters),
                publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(c => c
                    .AssignableTo(typeof(ICommandHandler<>))
                    .Where(type => !type.ContainsGenericParameters),
                publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(c => c
                    .AssignableTo(typeof(ICommandHandler<,>))
                    .Where(type => !type.ContainsGenericParameters),
                publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        return services;
    }
}