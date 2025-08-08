using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class PlayerRepository : IPlayerRepository
{
    private readonly AppDbContext _context;

    public PlayerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Player?> GetByIdAsync(int id) => await _context.Players.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Player>> GetAllAsync() => await _context.Players.ToListAsync();

    public void Add(Player player) => _context.Players.Add(player);

    public void Update(Player player) => _context.Players.Update(player);

    public async Task DeleteAsync(int id)
    {
        var player = await GetByIdAsync(id);
        if (player != null)
        {
            _context.Players.Remove(player);
        }
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}

