
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(int id);
    Task<IEnumerable<Team>> GetAllAsync();
    void Add(Team team);
    void Update(Team team);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
    Task<IEnumerable<Team>> GetTeamsWithAtLeastOneTournamentAsync();

}
