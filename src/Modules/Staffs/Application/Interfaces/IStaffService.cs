using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IStaffService
{
    Task<IEnumerable<Staff>> GetAllAsync();
    Task<IEnumerable<StaffRole>> GetStaffRolesByTypeAsync(int typeId);
    Task<Staff?> GetByIdAsync(int id);
    Task AddAsync(Staff staff);
}