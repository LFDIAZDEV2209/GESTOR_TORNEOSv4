using GESTOR_TORNEOSv4.src.Modules.Tournaments.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Tournaments.Domain.Entities;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Modules.Tournaments.Infrastructure;

public class TournamentRepository : ITournamentRepository
{
    private readonly AppDbContext _context;

    public TournamentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Tournament?> GetByIdAsync(int id) => await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);

    public async Task<IEnumerable<Tournament>> GetAllAsync() => await _context.Tournaments.ToListAsync();

    public void Add(Tournament tournament) => _context.Tournaments.Add(tournament);

    public void Update(Tournament tournament) => _context.Tournaments.Update(tournament);
    public async Task DeleteAsync(int id)
    {
        var tournament = await GetByIdAsync(id);
        if (tournament != null)
        {
            _context.Tournaments.Remove(tournament);
        }
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}

