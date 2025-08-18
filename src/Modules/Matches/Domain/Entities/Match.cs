namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Match
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public DateTime MatchDate { get; set; }
    public int HomeScore { get; set; } = 0;
    public int AwayScore { get; set; } = 0;
    public bool IsFinished { get; set; } = false;

    // Propiedades de navegación
    public Tournament? Tournament { get; set; }
    public Team? HomeTeam { get; set; }
    public Team? AwayTeam { get; set; }

    // Constructor principal
    public Match(int tournamentId, int homeTeamId, int awayTeamId, DateTime matchDate)
    {
        TournamentId = tournamentId;
        HomeTeamId = homeTeamId;
        AwayTeamId = awayTeamId;
        MatchDate = matchDate;
        HomeScore = 0;
        AwayScore = 0;
        IsFinished = false;
    }

    // Constructor vacío para Entity Framework
    public Match() { }

    // Método para finalizar partido
    public void FinishMatch(int homeScore, int awayScore)
    {
        if (homeScore < 0 || awayScore < 0)
            throw new ArgumentException("Los goles no pueden ser negativos");

        HomeScore = homeScore;
        AwayScore = awayScore;
        IsFinished = true;
    }
}