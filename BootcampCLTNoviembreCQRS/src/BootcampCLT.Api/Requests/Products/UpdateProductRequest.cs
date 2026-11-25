namespace BootcampCLT.Api.Requests.Products;

public sealed record UpdateProductRequest(
    string Name,
    string? Description,
    decimal Price,
    int MinStock
);