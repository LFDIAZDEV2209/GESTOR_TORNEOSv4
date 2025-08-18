namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class TeamStats
{
    public int TeamId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string CityName { get; set; } = string.Empty;
    public int TotalGoals { get; set; }
    public int TotalAssists { get; set; }
    public int MatchesPlayed { get; set; }
    public double AverageGoalsPerMatch { get; set; }
    
    // Propiedades de navegación
    public Team? Team { get; set; }
}
