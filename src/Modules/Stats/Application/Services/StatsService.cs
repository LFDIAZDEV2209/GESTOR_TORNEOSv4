using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class StatsService : IStatsService
{
    private readonly IStatsRepository _statsRepository;
    private readonly ITournamentService _tournamentService;
    private readonly ITeamService _teamService;

    public StatsService(IStatsRepository statsRepository, ITournamentService tournamentService, ITeamService teamService)
    {
        _statsRepository = statsRepository;
        _tournamentService = tournamentService;
        _teamService = teamService;
    }

    public async Task<IEnumerable<PlayerStats>> GetPlayersWithMostAssistsByTournamentAsync(int tournamentId)
    {
        try
        {
            return await _statsRepository.GetPlayersWithMostAssistsByTournamentAsync(tournamentId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo jugadores con más asistencias: {ex.Message}");
            return Enumerable.Empty<PlayerStats>();
        }
    }

    public async Task<IEnumerable<PlayerStats>> GetMostExpensivePlayersByTeamAsync(int teamId)
    {
        try
        {
            return await _statsRepository.GetMostExpensivePlayersByTeamAsync(teamId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo jugadores más caros: {ex.Message}");
            return Enumerable.Empty<PlayerStats>();
        }
    }

    public async Task<IEnumerable<PlayerStats>> GetPlayersBelowAverageAgeByTeamAsync(int teamId)
    {
        try
        {
            return await _statsRepository.GetPlayersBelowAverageAgeByTeamAsync(teamId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo jugadores menores al promedio de edad: {ex.Message}");
            return Enumerable.Empty<PlayerStats>();
        }
    }

    public async Task<IEnumerable<TeamStats>> GetTeamsWithMostGoalsAsync(int tournamentId)
    {
        try
        {
            return await _statsRepository.GetTeamsWithMostGoalsAsync(tournamentId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo equipos con más goles: {ex.Message}");
            return Enumerable.Empty<TeamStats>();
        }
    }

    public async Task<IEnumerable<Tournament>> GetAllTournamentsAsync()
    {
        try
        {
            return await _tournamentService.GetAllTournamentsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo torneos: {ex.Message}");
            return Enumerable.Empty<Tournament>();
        }
    }

    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        try
        {
            return await _teamService.GetAllTeamsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error obteniendo equipos: {ex.Message}");
            return Enumerable.Empty<Team>();
        }
    }

    public async Task<double> GetAverageTeamAgeAsync(int teamId)
    {
        try
        {
            return await _statsRepository.GetAverageTeamAgeAsync(teamId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculando edad promedio del equipo: {ex.Message}");
            return 0;
        }
    }
}
