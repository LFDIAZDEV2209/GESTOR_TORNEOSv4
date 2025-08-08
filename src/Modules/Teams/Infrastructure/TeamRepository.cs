using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public void Add(Team team) => _context.Teams.Add(team);

    public async Task DeleteAsync(int id)
    {
        var team = await GetByIdAsync(id);
        if (team != null)
        {
            _context.Teams.Remove(team);
        }
    }

    public async Task<IEnumerable<Team>> GetAllAsync() => await _context.Teams.ToListAsync();

    public async Task<Team?> GetByIdAsync(int id) => await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

    public Task SaveChangesAsync() => _context.SaveChangesAsync();

    public void Update(Team team) => _context.Teams.Update(team);
}
