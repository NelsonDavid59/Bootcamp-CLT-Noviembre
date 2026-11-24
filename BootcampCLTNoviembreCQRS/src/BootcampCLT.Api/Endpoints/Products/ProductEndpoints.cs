using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Features.Commands.CreateProduct;
using BootcampCLT.Application.Features.Products.DTOs;

namespace BootcampCLT.Api.Endpoints.Products;

public static class ProductEndpoints
{
    public static RouteGroupBuilder MapProducts(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("api/products").WithTags("Products");

        group.MapPost("/", async (
            CreateProductCommand command,
            ICommandDispatcher dispatcher,
            CancellationToken cancellationToken
            ) =>
        {
            var result = 
                await dispatcher.Dispatch<CreateProductCommand, ProductResponse>(command, cancellationToken);
            
            return Results.Created($"products/{result.Id}",result);
        })
        .WithName("CreateProduct");
        
        return group;
    }
}