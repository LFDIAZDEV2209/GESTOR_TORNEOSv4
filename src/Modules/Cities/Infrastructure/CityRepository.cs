using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class CityRepository : ICityRepository
{
    private readonly AppDbContext _context;

    public CityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<City?> GetByIdAsync(int id) => await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Cities.ToListAsync();
    }
}


