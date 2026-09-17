namespace SFMS.Application.Common.Interfaces.Repositories;

public interface IWriteRepository<T>
{
    Task AddAsync(
        T entity,
        CancellationToken cancellationToken);

    Task UpdateAsync(
        T entity,
        CancellationToken cancellationToken);

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken);
}