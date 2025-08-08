using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IPlayerRepository
{
    Task<Player?> GetByIdAsync(int id);
    Task<IEnumerable<Player>> GetAllAsync();
    void Add(Player player);
    void Update(Player player);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();

}
