using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class CountryRepository : ICountryRepository
{
    private readonly AppDbContext _context;

    public CountryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Country>> GetAllAsync() => await _context.Countries.ToListAsync();


    public async Task<Country?> GetByIdAsync(int id) => await _context.Countries.FindAsync(id);
    
}