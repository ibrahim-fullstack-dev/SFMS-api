namespace SFMS.Application.Common.Interfaces.Repositories;

public interface IReadRepository<T>
{
    Task<IReadOnlyList<T>> GetAllAsync(
        CancellationToken cancellationToken);

    Task<T?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken);
}