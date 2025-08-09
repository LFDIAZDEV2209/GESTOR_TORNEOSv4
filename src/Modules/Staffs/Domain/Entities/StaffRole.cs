namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class StaffRole
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int TypeId { get; set; }
    public StaffType StaffType { get; set; } = null!;
    public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();

    public StaffRole() { }

    public StaffRole(int id, string name, int typeId)
    {
        Id = id;
        Name = name;
        TypeId = typeId;
    }

    public override string ToString() => $"StaffRole(Id: {Id}, Name: {Name}, TypeId: {TypeId})";
}
