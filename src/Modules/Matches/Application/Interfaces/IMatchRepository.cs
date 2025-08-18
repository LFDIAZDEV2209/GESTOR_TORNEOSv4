using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IMatchRepository
{
    // Operaciones básicas
    Task<Match?> GetByIdAsync(int id);
    Task<IEnumerable<Match>> GetAllAsync();
    Task<Match> CreateAsync(Match match);
    Task<Match> UpdateAsync(Match match);
    
    // Consulta para partidos sin score
    Task<IEnumerable<Match>> GetMatchesWithoutScoreAsync();
    
    // Validaciones básicas
    Task<bool> HasTeamInTournamentAsync(int teamId, int tournamentId);
    Task<bool> HasMatchOnDateAsync(int tournamentId, DateTime date);
    Task<bool> HasMatchBetweenTeamsAsync(int tournamentId, int team1Id, int team2Id, DateTime date);
}