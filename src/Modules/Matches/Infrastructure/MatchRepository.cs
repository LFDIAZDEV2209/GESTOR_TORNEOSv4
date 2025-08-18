using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GESTOR_TORNEOSv4.src.Shared.Context;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class MatchRepository : IMatchRepository
{
    private readonly AppDbContext _context;

    public MatchRepository(AppDbContext context)
    {
        _context = context;
    }

    // Operaciones básicas
    public async Task<Match?> GetByIdAsync(int id)
    {
        return await _context.Matches
            .Include(m => m.Tournament)
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Match>> GetAllAsync()
    {
        return await _context.Matches
            .Include(m => m.Tournament)
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .OrderByDescending(m => m.MatchDate)
            .ToListAsync();
    }

    public async Task<Match> CreateAsync(Match match)
    {
        _context.Matches.Add(match);
        await _context.SaveChangesAsync();
        return match;
    }

    public async Task<Match> UpdateAsync(Match match)
    {
        _context.Matches.Update(match);
        await _context.SaveChangesAsync();
        return match;
    }

    // Consulta para partidos sin score
    public async Task<IEnumerable<Match>> GetMatchesWithoutScoreAsync()
    {
        return await _context.Matches
            .Include(m => m.Tournament)
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Where(m => !m.IsFinished && m.HomeScore == 0 && m.AwayScore == 0)
            .OrderBy(m => m.MatchDate)
            .ToListAsync();
    }

    // Validaciones básicas
    public async Task<bool> HasTeamInTournamentAsync(int teamId, int tournamentId)
    {
        return await _context.TournamentTeams
            .AnyAsync(tt => tt.TeamId == teamId && tt.TournamentId == tournamentId);
    }

    public async Task<bool> HasMatchOnDateAsync(int tournamentId, DateTime date)
    {
        return await _context.Matches
            .AnyAsync(m => m.TournamentId == tournamentId && m.MatchDate.Date == date.Date);
    }

    public async Task<bool> HasMatchBetweenTeamsAsync(int tournamentId, int team1Id, int team2Id, DateTime date)
    {
        return await _context.Matches
            .AnyAsync(m => m.TournamentId == tournamentId && 
                          m.MatchDate.Date == date.Date &&
                          ((m.HomeTeamId == team1Id && m.AwayTeamId == team2Id) ||
                           (m.HomeTeamId == team2Id && m.AwayTeamId == team1Id)));
    }
}
