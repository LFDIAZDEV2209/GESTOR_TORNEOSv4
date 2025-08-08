
namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<TournamentTeam> TournamentTeam { get; set; } = new HashSet<TournamentTeam>();

    public Tournament(int id, string name, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Tournament()
    {
    }

    public override string ToString()
    {
        return $"Tournament: {Name}, Start: {StartDate}, End: {EndDate}";
    }
}
