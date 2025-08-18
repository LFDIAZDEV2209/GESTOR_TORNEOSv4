namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class PlayerStats
{
	public int Id { get; set; }
	public int PlayerId { get; set; }
	public int MatchId { get; set; }
	public int Goals { get; set; } = 0;
	public int Assists { get; set; } = 0;
	public int MinutesPlayed { get; set; } = 0;

	// Propiedades de navegación
	public Player? Player { get; set; }
	public Match? Match { get; set; }
}
