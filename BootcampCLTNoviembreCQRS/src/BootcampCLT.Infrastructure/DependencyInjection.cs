using BootcampCLT.Application.Common.Interfaces;
using BootcampCLT.Application.Features.Products.Interfaces;
using BootcampCLT.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace BootcampCLT.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        // DbContext
        var connectionString = configuration
            .GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Agregamos repository y UoW
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());

        // Repositories utilizando Scrutor
        // Fuente: https://milanjovanovic.tech/blog/improving-aspnetcore-dependency-injection-with-scrutor
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(DependencyInjection))
            .AddClasses(
                filter => filter.Where(x => x.Name.EndsWith("Repository")),
                publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Throw)
            .AsMatchingInterface()
            .WithScopedLifetime());
        
        return services;
    }
}