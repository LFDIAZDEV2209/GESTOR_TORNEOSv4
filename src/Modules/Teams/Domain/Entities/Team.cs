namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Team(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Team()
    {
    }

    public override string ToString()
    {
        return $"Team(Id: {Id}, Name: {Name})";
    }
}
