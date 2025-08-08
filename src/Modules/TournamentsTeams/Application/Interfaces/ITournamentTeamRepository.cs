using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITournamentTeamRepository
{
    void InscribeTeamToTournament(TournamentTeam tournamentTeam);
    void RemoveTeamFromTournament(TournamentTeam tournamentTeam);
    Task SaveChangesAsync(); // Added for async operations if needed
}
