using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITournamentRepository
{
    Task<Tournament?> GetByIdAsync(int id);
    Task<IEnumerable<Tournament>> GetAllAsync();
    void Add(Tournament tournament);
    void Update(Tournament tournament);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
    Task<IEnumerable<Tournament>> GetTournamentsWhereTeamIsNotEnrolledAsync(int teamId);
    Task<IEnumerable<Tournament>> GetTournamentsByTeamIdAsync(int teamId);
}
