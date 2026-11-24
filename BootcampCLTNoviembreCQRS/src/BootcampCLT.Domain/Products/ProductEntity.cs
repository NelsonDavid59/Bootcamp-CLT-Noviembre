using BootcampCLT.Domain.Common;
using BootcampCLT.Domain.Shared.Exceptions;

namespace BootcampCLT.Domain.Products;

public sealed class ProductEntity : IEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int MinStock { get; private set; } //Stock mínimo para el producto
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }


    public ProductEntity()
    {
    }

    public static ProductEntity Create(string name, string? description, decimal price = 0, int minStock = 0)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ValidationException(ExceptionMessages.Products.NameRequired);
        }

        if(price < 0)
        {
            throw new ValidationException(ExceptionMessages.Products.PriceNonNegative);
        }

        return new ProductEntity
        {
            Name = name,
            Description = description,
            Price = price,
            MinStock = minStock,
            CreatedAt = DateTime.UtcNow
        };
    }
}