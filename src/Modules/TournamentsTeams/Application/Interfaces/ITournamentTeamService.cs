using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITournamentTeamService
{
    Task InscribeTeamToTournamentAsync(int tournamentId, int teamId);
    Task RemoveTeamFromTournamentAsync(int tournamentId, int teamId);
}
