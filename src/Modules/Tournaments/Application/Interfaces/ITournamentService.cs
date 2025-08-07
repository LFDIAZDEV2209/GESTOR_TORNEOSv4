using GESTOR_TORNEOSv4.src.Modules.Tournaments.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Tournaments.Application.Interfaces;

public interface ITournamentService
{
    Task<Tournament?> GetTournamentByIdAsync(int id);
    Task<IEnumerable<Tournament>> GetAllTournamentsAsync();
    Task AddTournamentAsync(Tournament tournament);
    Task UpdateTournamentAsync(int id, Tournament tournament);
    Task DeleteTournamentAsync(int id);
}
