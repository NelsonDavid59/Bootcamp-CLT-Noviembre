using BootcampCLT.Domain.Products;

namespace BootcampCLT.Infrastructure.Persistence.Repository;

public class ProductRepository : IProductRepository
{
    public Task<ICollection<ProductEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity> GetById(int producId)
    {
        throw new NotImplementedException();
    }

    public void Save(ProductEntity product)
    {
        throw new NotImplementedException();
    }

    public void Update(ProductEntity product)
    {
        throw new NotImplementedException();
    }
}