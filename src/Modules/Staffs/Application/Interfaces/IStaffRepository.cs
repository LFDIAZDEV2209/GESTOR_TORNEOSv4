using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IStaffRepository
{

    Task<Staff?> GetByIdAsync(int id);
    Task<IEnumerable<Staff>> GetAllAsync();
    Task<IEnumerable<StaffRole>> GetStaffRolesByTypeAsync(int typeId);
    void Add(Staff staff);
    void Update(Staff staff);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
}
