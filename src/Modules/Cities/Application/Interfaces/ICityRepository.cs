using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(int id);
    Task<IEnumerable<City>> GetAllAsync();
}
