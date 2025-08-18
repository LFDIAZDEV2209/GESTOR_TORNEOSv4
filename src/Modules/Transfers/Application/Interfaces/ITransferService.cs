using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;

public interface ITransferService
{
    Task<Transfer> BuyPlayerAsync(int playerId, int destinationTeamId, decimal amount);
    Task<Transfer> LoanPlayerAsync(int playerId, int destinationTeamId);
    Task<IEnumerable<Transfer>> GetAllTransfersAsync();
}
