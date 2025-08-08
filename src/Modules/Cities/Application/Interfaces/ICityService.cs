using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ICityService
{
    Task<City?> GetCityByIdAsync(int id);
    Task<IEnumerable<City>> GetAllCitiesAsync();
}
