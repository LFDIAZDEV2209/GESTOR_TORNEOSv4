using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITeamService
{
    Task<Team?> GetTeamByIdAsync(int id);
    Task<IEnumerable<Team>> GetAllTeamsAsync();
    Task AddTeamAsync(Team team);
    Task UpdateTeamAsync(int id, Team team);
    Task DeleteTeamAsync(int id);
}
