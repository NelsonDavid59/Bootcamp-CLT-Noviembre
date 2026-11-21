using BootcampCLT.Application.Features.Products.Interfaces;
using BootcampCLT.Domain.Products;
using BootcampCLT.Domain.Shared.Exceptions;
using BootcampCLT.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace BootcampCLT.Infrastructure.Persistence.Repository;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public async Task<IReadOnlyList<ProductEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await db.Products.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<ProductEntity> GetById(int producId, CancellationToken cancellationToken)
    {
        return await db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == producId, cancellationToken) 
            ?? throw new NotFoundException(string.Format(ExceptionMessages.Products.ProductNotFound, producId)); 
    }

    public void Save(ProductEntity product)
    {
        db.Products.Add(product);
    }

    public void Update(ProductEntity product)
    {
        db.Products.Update(product);
    }
}