using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("Staff"); 

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("id");

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(s => s.TeamId)
            .HasColumnName("team_id");

        builder.Property(s => s.CountryId)
            .HasColumnName("country_id");

        builder.Property(s => s.RoleId)
            .IsRequired()
            .HasColumnName("role_id");
    }
}
