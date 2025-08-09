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

    public async Task Delete(int id)
    {
        var staff = await GetById(id);
        if (staff != null)
        {
            _context.Staffs.Remove(staff);
        }
    }

    public async Task<IEnumerable<Staff>> GetAll() => await _context.Staffs.ToListAsync();

    public async Task<IEnumerable<StaffRole>> GetStaffRolesByType(int typeId) => await _context.StaffRoles.Where(s => s.TypeId == typeId).ToListAsync();

    public async Task<Staff?> GetById(int id) => await _context.Staffs.FindAsync(id);

    public async Task<IEnumerable<Staff>> GetUnassignedStaffByType(int typeId) => await _context.Staffs.Where(s => s.Role.TypeId == typeId && s.TeamId == null).ToListAsync();

    public async Task AssignStaffToTeam(int staffId, int teamId)
    {
        var staff = await GetById(staffId);
        if (staff != null)
        {
            staff.TeamId = teamId;
        }
    }

    public void Update(Staff staff) => _context.Staffs.Update(staff);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}