namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Transfer
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int? OriginTeamId { get; set; }
    public int DestinationTeamId { get; set; }
    public DateTime TransferDate { get; set; }
    public string TransferType { get; set; } = string.Empty; // "Buy" o "Loan"
    public decimal? Amount { get; set; }

    // Propiedades de navegación
    public Player? Player { get; set; }
    public Team? OriginTeam { get; set; }
    public Team? DestinationTeam { get; set; }

    public Transfer(int playerId, int destinationTeamId, DateTime transferDate, string transferType, decimal? amount = null)
    {
        PlayerId = playerId;
        DestinationTeamId = destinationTeamId;
        TransferDate = transferDate;
        TransferType = transferType;
        Amount = amount;
    }

    // Constructor vacío para Entity Framework
    public Transfer() { }
}
