using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _transferRepository;

    public TransferService(ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    public async Task<Transfer> BuyPlayerAsync(int playerId, int destinationTeamId, decimal amount)
    {
        var transfer = new Transfer(playerId, destinationTeamId, DateTime.Today, "Buy", amount);
        return await _transferRepository.CreateAsync(transfer);
    }

    public async Task<Transfer> LoanPlayerAsync(int playerId, int destinationTeamId)
    {
        var transfer = new Transfer(playerId, destinationTeamId, DateTime.Today, "Loan");
        return await _transferRepository.CreateAsync(transfer);
    }

    public async Task<IEnumerable<Transfer>> GetAllTransfersAsync()
    {
        return await _transferRepository.GetAllAsync();
    }
}
