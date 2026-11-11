using BootcampCLTNoviembre.DTOs;
using BootcampCLTNoviembre.Entities;
using BootcampCLTNoviembre.Persistence;

namespace BootcampCLTNoviembre.Services;

public class ProductsServiceImpl : IProductService
{
    //Simulación de productos
    private static readonly List<ProductEntity> Products =
        [
            new(){Id = 1, Name = "Notebook", Description = "Notebook para desarrollo", Price = 1200.00m, MinStock = 10},
            new(){Id = 2, Name = "Mouse", Description = "Mouse inalámbrico", Price = 25.50m, MinStock = 30}
        ];

    public void Delete(int productId)
    {
        throw new NotImplementedException();
    }

    public List<ProductDTO> GetAll()
    {
        //Convertimos a lista de dtos
        return Products.Select(p => parseEntityToDto(p)).ToList();
    }

    public ProductDTO? GetById(int id)
    {
        var entity = Products.FirstOrDefault(x => x.Id == id);
        
        if ( entity != null)
        {
            return parseEntityToDto(entity);
        }

        return null;
    }

    public ProductDTO Save(ProductDTO product)
    {
        // Validaciones
        
    }

    public ProductDTO SetMinStockValue(int productId, int newValue)
    {
        throw new NotImplementedException();
    }

    public ProductDTO Update(ProductDTO product)
    {
        throw new NotImplementedException();
    }


    // Mapea un DTO a Entity
    private ProductEntity parseDtoToEntity(ProductDTO dto)
    {
        ProductEntity entity = new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            MinStock = dto.MinStock
        };

        return entity;
    }

    // Mapea un Entity a DTO
    private ProductDTO parseEntityToDto(ProductEntity entity)
    {
        ProductDTO dto = new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            MinStock = entity.MinStock
        }; 

        return  dto;
    }
}