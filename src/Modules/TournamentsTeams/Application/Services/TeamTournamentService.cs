using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class TeamTournamentService : ITournamentTeamService
{
    private readonly ITournamentTeamRepository _tournamentTeamRepository;

    public TeamTournamentService(ITournamentTeamRepository tournamentTeamRepository)
    {
        _tournamentTeamRepository = tournamentTeamRepository;
    }

    public async Task InscribeTeamToTournamentAsync(int tournamentId, int teamId)
    {
        try
        {
            var tournamentTeam = new TournamentTeam(tournamentId, teamId);
            if (tournamentTeam == null)
            {
                Console.WriteLine("TournamentTeam is null, cannot inscribe team to tournament");
                return;
            }
            _tournamentTeamRepository.InscribeTeamToTournament(tournamentTeam);
            await _tournamentTeamRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error inscribing team to tournament", ex);
        }
    }

    public async Task RemoveTeamFromTournamentAsync(int tournamentId, int teamId)
    {
        try
        {
            var tournamentTeam = new TournamentTeam(tournamentId, teamId);
            if (tournamentTeam == null)
            {
                Console.WriteLine("TournamentTeam is null, cannot remove team from tournament");
                return;
            }
            _tournamentTeamRepository.RemoveTeamFromTournament(tournamentTeam);
            await _tournamentTeamRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error removing team from tournament", ex);
        }
    }
}