using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.CityId)
            .HasColumnName("city_id");

        builder
            .HasOne(t => t.City)
            .WithMany(c => c.Teams)
            .HasForeignKey(t => t.CityId)
            .OnDelete(DeleteBehavior.Cascade); // o .Cascade según la lógica de negocio

    }
}
