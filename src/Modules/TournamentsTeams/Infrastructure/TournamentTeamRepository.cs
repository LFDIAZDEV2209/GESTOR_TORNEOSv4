using System.Security.Cryptography.X509Certificates;
using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Shared.Context;

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
}

