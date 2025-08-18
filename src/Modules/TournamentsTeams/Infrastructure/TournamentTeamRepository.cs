using System.Security.Cryptography.X509Certificates;
using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class TournamentTeamRepository : ITournamentTeamRepository
{
    private readonly AppDbContext _context;

    public TournamentTeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public void InscribeTeamToTournament(TournamentTeam tournamentTeam) => _context.TournamentTeams.Add(tournamentTeam);
    public void RemoveTeamFromTournament(TournamentTeam tournamentTeam) => _context.TournamentTeams.Remove(tournamentTeam);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task<IEnumerable<Team>> GetTeamsByTournamentAsync(int tournamentId)
    {
        return await _context.TournamentTeams
            .Where(tt => tt.TournamentId == tournamentId)
            .Select(tt => tt.Team)
            .ToListAsync();
    }
}

