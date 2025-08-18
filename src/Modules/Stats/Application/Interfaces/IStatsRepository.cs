using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IStatsRepository
{
    // Estadísticas de jugadores
    Task<IEnumerable<PlayerStats>> GetPlayersWithMostAssistsByTournamentAsync(int tournamentId);
    Task<IEnumerable<PlayerStats>> GetMostExpensivePlayersByTeamAsync(int teamId);
    Task<IEnumerable<PlayerStats>> GetPlayersBelowAverageAgeByTeamAsync(int teamId);
    
    // Estadísticas de equipos
    Task<IEnumerable<TeamStats>> GetTeamsWithMostGoalsAsync(int tournamentId);
    
    // Métodos auxiliares
    Task<double> GetAverageTeamAgeAsync(int teamId);
}
