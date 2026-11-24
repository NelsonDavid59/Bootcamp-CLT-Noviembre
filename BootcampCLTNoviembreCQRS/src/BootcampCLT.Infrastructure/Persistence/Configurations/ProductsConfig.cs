using BootcampCLT.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampCLT.Infrastructure.Persistence.Configurations;

public class ProductsConfig : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products", t =>
        {
            t.HasComment("Catalogo de productos (agregado Product)");

            t.HasCheckConstraint("ck_products_price", "price >= 0::numeric");
            t.HasCheckConstraint("ck_products_stock", "stock >= 0");
            t.HasCheckConstraint("ck_products_name", "length(btrim(name::text)) > 0");
        });

        builder.HasKey(p => p.Id)
            .HasName("pk_products");

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .UseIdentityByDefaultColumn();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired(false);
        
        builder.Property(p => p.Price)
            .HasColumnName("price")
            .HasPrecision(18, 2)
            .HasComment("Precio unitario en USD.")
            .IsRequired();

        builder.Property(p => p.MinStock)
            .HasColumnName("stock")
            .HasDefaultValue(0)
            .HasComment("Unidades disponibles en inventario.")
            .IsRequired();
        
        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired(false);
        
        builder.Property(p => p.UpdatedAt)
            .HasComment("Ultima modificacion; NULL si nunca se modifico.");
    }
}