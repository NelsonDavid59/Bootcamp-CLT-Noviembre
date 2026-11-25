using BootcampCLT.Application.Features.Products.Interfaces;
using BootcampCLT.Domain.Products;
using BootcampCLT.Domain.Shared.Exceptions;
using BootcampCLT.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace BootcampCLT.Infrastructure.Persistence.Repository;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public async Task<ICollection<ProductEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await db.Products.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<ProductEntity> GetById(int productId, CancellationToken cancellationToken)
    {
        return await db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId, cancellationToken) 
            ?? throw new NotFoundException(string.Format(ExceptionMessages.Products.ProductNotFound, productId)); 
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