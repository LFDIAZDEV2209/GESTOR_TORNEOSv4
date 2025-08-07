using GESTOR_TORNEOSv4.src.Modules.Tournaments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GESTOR_TORNEOSv4.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Tournament> Tournaments => Set<Tournament>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}