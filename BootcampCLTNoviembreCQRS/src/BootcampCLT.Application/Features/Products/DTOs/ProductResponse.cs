namespace BootcampCLT.Application.Features.Products.DTOs;

public sealed record ProductResponse(
    int Id,
    string Name, 
    string? Description,
    decimal Price,
    int MinStock,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);