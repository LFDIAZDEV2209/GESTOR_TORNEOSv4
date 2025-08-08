namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Relación: una ciudad puede tener muchos equipos
    public List<Team> Teams { get; set; } = new List<Team>();

    public City() { }

    public City(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"City(Id: {Id}, Name: {Name})";
    }
}
