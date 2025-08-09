using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Tournament> Tournaments => Set<Tournament>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<TournamentTeam> TournamentTeams => Set<TournamentTeam>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Staff> Staffs => Set<Staff>();
    public DbSet<StaffRole> StaffRoles => Set<StaffRole>();
    public DbSet<StaffType> StaffTypes => Set<StaffType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}