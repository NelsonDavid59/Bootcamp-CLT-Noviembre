using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Features.Commands.CreateProduct;
using BootcampCLT.Application.Features.Products.Queries.GetProducts;
using BootcampCLT.Application.Features.Products.DTOs;
using Microsoft.AspNetCore.Mvc;
using BootcampCLT.Application.Features.Products.Commands.UpdateProduct;
using BootcampCLT.Api.Requests.Products;

namespace BootcampCLT.Api.Endpoints.Products;

public static class ProductEndpoints
{
    public static RouteGroupBuilder MapProducts(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("api/products").WithTags("Products");

        group.MapGet("/{productId:int}", async (
            int productId,
            IQueryDispatcher dispatcher,
            CancellationToken cancellationToken) =>
        {
            var query = new GetProductQuery(productId);

            var result = await dispatcher.Dispatch<GetProductQuery, ProductResponse>(query, cancellationToken); 

            return Results.Ok(result);           
        }).WithName("GetProductById");

        group.MapPost("/", async (
            CreateProductCommand command,
            ICommandDispatcher dispatcher,
            CancellationToken cancellationToken) =>
        {
            var result = 
                await dispatcher.Dispatch<CreateProductCommand, ProductResponse>(command, cancellationToken);
            
            return Results.CreatedAtRoute("GetProductById", new {productId = result.Id}, result);
        })
        .WithName("CreateProduct");

        group.MapPut("/{productId:int}", async (
            int productId,
            UpdateProductRequest request, 
            ICommandDispatcher dispatcher,
            CancellationToken cancellationToken) =>
        {
            // Creamos el comando
            var command = new UpdateProductCommand(
                productId, 
                request.Name,
                request.Description,
                request.Price,
                request.MinStock);
            
            var result = 
                await dispatcher.Dispatch<UpdateProductCommand, ProductResponse>(command, cancellationToken);
            
            return Results.Ok(result);
        }).WithName("UpdateProduct");
        
        return group;
    }
}