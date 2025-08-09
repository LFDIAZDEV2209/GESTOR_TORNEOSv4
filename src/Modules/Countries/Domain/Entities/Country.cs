namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // Relación: un país puede tener muchos jugadores
    public ICollection<Player> Players { get; set; } = new HashSet<Player>();

    // Relación: un país puede tener muchos miembros del staff
    public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
    
    // Constructor
    public Country() { }

    public Country(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
