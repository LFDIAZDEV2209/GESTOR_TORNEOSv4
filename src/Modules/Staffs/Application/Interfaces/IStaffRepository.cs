using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface IStaffRepository
{

    Task<Staff?> GetById(int id);
    Task<IEnumerable<Staff>> GetAll();
    Task<IEnumerable<StaffRole>> GetStaffRolesByType(int typeId);
    Task<IEnumerable<Staff>> GetUnassignedStaffByType(int typeId);
    Task AssignStaffToTeam(int staffId, int teamId);
    void Add(Staff staff);
    void Update(Staff staff);
    Task Delete(int id);
    Task SaveChangesAsync();
}
