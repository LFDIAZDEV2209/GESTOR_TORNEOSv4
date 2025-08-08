using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class TournamentTeam
{
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; } = null!;

    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;

    public TournamentTeam() { }

    public TournamentTeam(int tournamentId, int teamId)
    {
        TournamentId = tournamentId;
        TeamId = teamId;
    }

    public override string ToString()
    {
        return $"TournamentTeam(TournamentId: {TournamentId}, TeamId: {TeamId})";
    }
}
