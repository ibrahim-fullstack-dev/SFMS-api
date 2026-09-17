using Microsoft.EntityFrameworkCore;
using SFMS.Application.Features.Cities;
using SFMS.Domain.Common;

namespace SFMS.Infrastructure.Persistence.Repositories;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;

    public CityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<City>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _context.Cities
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<City?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await _context.Cities
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task AddAsync(
        City city,
        CancellationToken cancellationToken)
    {
        await _context.Cities.AddAsync(city, cancellationToken);
    }

    public Task UpdateAsync(
        City city,
        CancellationToken cancellationToken)
    {
        _context.Cities.Update(city);

        return Task.CompletedTask;
    }

    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var city = await _context.Cities
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (city is not null)
        {
            city.IsDeleted = true;
            city.IsActive = false;
        }
    }
}