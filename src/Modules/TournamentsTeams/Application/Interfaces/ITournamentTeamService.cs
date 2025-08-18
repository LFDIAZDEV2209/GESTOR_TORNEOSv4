using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITournamentTeamService
{
    Task InscribeTeamToTournamentAsync(int tournamentId, int teamId);
    Task RemoveTeamFromTournamentAsync(int tournamentId, int teamId);
    Task<IEnumerable<Team>> GetTeamsByTournamentAsync(int tournamentId);
}
