using BootcampCLTNoviembre.DTOs;
using BootcampCLTNoviembre.Entities;

namespace BootcampCLTNoviembre.Services;

public class ProductsServiceImpl : IProductService
{
    
    
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