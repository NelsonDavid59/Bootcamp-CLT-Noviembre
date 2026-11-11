namespace BootcampCLTNoviembre.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int MinStock { get; set; } //Stock mínimo para el producto
}