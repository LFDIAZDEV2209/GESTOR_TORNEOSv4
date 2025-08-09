using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<Country?> GetByIdAsync(int id);
}