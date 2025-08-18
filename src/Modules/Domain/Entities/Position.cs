namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Position
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Relación: una posición puede tener muchos jugadores
    public ICollection<Player> Players { get; set; } = new HashSet<Player>();

    // Constructor
    public Position() { }

    public Position(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
