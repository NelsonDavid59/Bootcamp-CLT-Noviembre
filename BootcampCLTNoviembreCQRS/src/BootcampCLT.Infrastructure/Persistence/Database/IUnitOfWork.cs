namespace BootcampCLT.Infrastructure.Persistence.Database;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}