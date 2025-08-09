using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class StaffRepository : IStaffRepository
{
    private readonly AppDbContext _context;

    public StaffRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Staff staff) => _context.Staffs.Add(staff);

    public async Task DeleteAsync(int id)
    {
        var staff = await GetByIdAsync(id);
        if (staff != null)
        {
            _context.Staffs.Remove(staff);
        }
    }

    public async Task<IEnumerable<Staff>> GetAllAsync() => await _context.Staffs.ToListAsync();

    public async Task<IEnumerable<StaffRole>> GetStaffRolesByTypeAsync(int typeId) => await _context.StaffRoles.Where(s => s.TypeId == typeId).ToListAsync();

    public async Task<Staff?> GetByIdAsync(int id) => await _context.Staffs.FindAsync(id);

    public void Update(Staff staff) => _context.Staffs.Update(staff);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}