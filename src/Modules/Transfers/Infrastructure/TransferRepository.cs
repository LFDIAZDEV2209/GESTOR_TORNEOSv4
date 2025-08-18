using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using GESTOR_TORNEOSv4.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Modules.Infrastructure;

public class TransferRepository : ITransferRepository
{
    private readonly AppDbContext _context;

    public TransferRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Transfer> CreateAsync(Transfer transfer)
    {
        try
        {
            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync();
            return transfer;
        }
        catch (DbUpdateException dbEx)
        {
            var detailedMessage = dbEx.InnerException?.Message ?? dbEx.Message;
            throw new InvalidOperationException($"Error al guardar la transferencia: {detailedMessage}", dbEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error inesperado al guardar la transferencia: {ex.Message}", ex);
        }
    }

    public async Task<IEnumerable<Transfer>> GetAllAsync()
    {
        return await _context.Transfers
            .Include(t => t.Player)
            .Include(t => t.OriginTeam)
            .Include(t => t.DestinationTeam)
            .ToListAsync();
    }

    public async Task<Transfer?> GetByIdAsync(int id)
    {
        return await _context.Transfers
            .Include(t => t.Player)
            .Include(t => t.OriginTeam)
            .Include(t => t.DestinationTeam)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
