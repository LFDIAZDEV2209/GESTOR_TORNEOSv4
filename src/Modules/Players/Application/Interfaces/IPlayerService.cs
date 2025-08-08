using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IPlayerService
{
    Task<Player?> GetPlayerByIdAsync(int id);
    Task<IEnumerable<Player>> GetAllPlayersAsync();
    Task AddPlayerAsync(Player player);
    Task UpdatePlayerAsync(int id, Player player);
    Task DeletePlayerAsync(int id);
}
