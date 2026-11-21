using BootcampCLT.Application.Common.Interfaces;
using BootcampCLT.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace BootcampCLT.Infrastructure.Persistence.Database;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}