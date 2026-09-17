using SFMS.Application.Common.Interfaces.Repositories;
using SFMS.Domain.Common;

namespace SFMS.Application.Features.Cities;

public interface ICityRepository :
    IReadRepository<City>,
    IWriteRepository<City>
{
}