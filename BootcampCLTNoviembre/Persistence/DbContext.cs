using BootcampCLTNoviembre.Entities;

namespace BootcampCLTNoviembre.Persistence;

public class DbContext
{
    //Simulación de productos
    private static readonly List<ProductEntity> Products =
        [
            new(){Id = 1, Name = "Notebook", Description = "Notebook para desarrollo", Price = 1200.00m, MinStock = 10},
            new(){Id = 2, Name = "Mouse", Description = "Mouse inalámbrico", Price = 25.50m, MinStock = 30}
        ];

}