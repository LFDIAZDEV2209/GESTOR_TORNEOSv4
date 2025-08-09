namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class StaffType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Relación: Un tipo de staff tiene muchos roles
    public ICollection<StaffRole> StaffRoles { get; set; } = new HashSet<StaffRole>();

    // Constructor
    public StaffType() { }

    public StaffType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => $"StaffType(Id: {Id}, Name: {Name})";
}
