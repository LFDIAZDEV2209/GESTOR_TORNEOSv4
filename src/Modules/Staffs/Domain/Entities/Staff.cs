namespace GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class Staff
{
    public int Id { get; set; }
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? CountryId { get; set; }
    public Country? Country { get; set; }
    public int RoleId { get; set; }
    public StaffRole Role { get; set; } = null!;
}
