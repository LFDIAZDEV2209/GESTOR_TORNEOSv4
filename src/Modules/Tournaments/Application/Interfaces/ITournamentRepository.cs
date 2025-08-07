using GESTOR_TORNEOSv4.src.Modules.Tournaments.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Tournaments.Application.Interfaces;

public interface ITournamentRepository
{
    Task<Tournament?> GetByIdAsync(int id);
    Task<IEnumerable<Tournament>> GetAllAsync();
    void Add(Tournament tournament);
    void Update(Tournament tournament);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();

}
