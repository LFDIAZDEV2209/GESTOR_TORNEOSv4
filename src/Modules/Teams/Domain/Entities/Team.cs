namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int? CityId { get; set; }  
    public City? City { get; set; } 

    public ICollection<TournamentTeam> TournamentTeam { get; set; } = new HashSet<TournamentTeam>();
    public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
    public ICollection<Player> Players { get; set; } = new HashSet<Player>();
  

    public Team(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Team() { }

    public override string ToString()
    {
        return $"Team(Id: {Id}, Name: {Name}, CityId: {CityId})";
    }
}

