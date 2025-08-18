using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IMatchService
{
    // Operaciones básicas
    Task<Match?> GetByIdAsync(int id);
    Task<IEnumerable<Match>> GetAllAsync();
    Task<Match> CreateMatchAsync(int tournamentId, int homeTeamId, int awayTeamId, DateTime matchDate);
    Task<Match> FinishMatchAsync(int matchId, int homeScore, int awayScore);
    
    // Consultas para el menú de partidos
    Task<IEnumerable<Match>> GetMatchesWithoutScoreAsync();
    
    // Validaciones básicas
    Task<bool> CanCreateMatchAsync(int tournamentId, int homeTeamId, int awayTeamId, DateTime matchDate);
}
