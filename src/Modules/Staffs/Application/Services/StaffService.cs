using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class StaffService : IStaffService
{
    private readonly IStaffRepository _staffRepository;

    public StaffService(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task AddAsync(Staff staff)
    {
        try{
            if (staff == null)
            {
                Console.WriteLine("Staff is null");
                return;
            }
            _staffRepository.Add(staff);
            await _staffRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding staff: {ex.InnerException?.Message}");
        }
    }

    public async Task<IEnumerable<Staff>> GetAllAsync()
    {
        try
        {
            var staff = await _staffRepository.GetAll();
            if (staff == null)
            {
                Console.WriteLine("Staff is null");
                return Enumerable.Empty<Staff>();
            }
            return staff;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting staff: {ex.Message}");
            return Enumerable.Empty<Staff>();
        }
    }

    public async Task<Staff?> GetByIdAsync(int id)
    {
        try
        {
            var staff = await _staffRepository.GetById(id);
            if (staff == null)
            {
                Console.WriteLine("Staff is null");
                return null;
            }
            return staff;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting staff by id: {ex.Message}");
            return null;
        }
    }

    public async Task<IEnumerable<StaffRole>> GetStaffRolesByTypeAsync(int typeId)
    {
        try
        {
            var staffRoles = await _staffRepository.GetStaffRolesByType(typeId);
            if (staffRoles == null)
            {
                Console.WriteLine("Staff roles is null");
                return Enumerable.Empty<StaffRole>();
            }
            return staffRoles;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting staff roles by type: {ex.Message}");
            return Enumerable.Empty<StaffRole>();
        }
    }

    public async Task<IEnumerable<Staff>> GetUnassignedStaffByTypeAsync(int typeId)
    {
        try
        {
            var staff = await _staffRepository.GetUnassignedStaffByType(typeId);
            if (staff == null)
            {
                Console.WriteLine("Staff is null");
                return Enumerable.Empty<Staff>();
            }
            return staff;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting unassigned staff by type: {ex.Message}");
            return Enumerable.Empty<Staff>();
        }
    }

    public async Task AssignStaffToTeamAsync(int staffId, int teamId)
    {
        try
        {
            var staff = await _staffRepository.GetById(staffId);
            if (staff == null)
            {
                Console.WriteLine("Staff is null");
                return;
            }
            await _staffRepository.AssignStaffToTeam(staffId, teamId);
            await _staffRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error assigning staff to team: {ex.Message}");
        }
    }
}