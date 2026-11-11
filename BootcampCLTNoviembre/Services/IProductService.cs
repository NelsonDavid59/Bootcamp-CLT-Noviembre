using BootcampCLTNoviembre.DTOs;

namespace BootcampCLTNoviembre.Services;

public interface IProductService
{
    public List<ProductDTO> GetAll();
    public ProductDTO? GetById(int id);
    public ProductDTO Save();
    public ProductDTO Update();
    public ProductDTO SetMinStockValue();
    public void Delete();
}