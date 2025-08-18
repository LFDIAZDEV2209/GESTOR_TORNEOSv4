using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITransferRepository
{
    Task<Transfer> CreateAsync(Transfer transfer);
    Task<IEnumerable<Transfer>> GetAllAsync();
    Task<Transfer?> GetByIdAsync(int id);
    Task SaveChangesAsync();
}
