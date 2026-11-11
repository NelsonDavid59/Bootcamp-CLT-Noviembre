using BootcampCLTNoviembre.DTOs;

namespace BootcampCLTNoviembre.Services;

public interface IProductService
{
    public List<ProductDTO> GetAll();
    public ProductDTO? GetById(int id);
    public ProductDTO Save(ProductDTO product);
    public ProductDTO Update(ProductDTO product);
    public ProductDTO SetMinStockValue(int productId, int newValue);
    public void Delete(int productId);
}