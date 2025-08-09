using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class StaffRoleConfiguration : IEntityTypeConfiguration<StaffRole>
{
    public void Configure(EntityTypeBuilder<StaffRole> builder)
    {
        builder.ToTable("StaffRoles"); // Nombre de la tabla

        builder.HasKey(sr => sr.Id);

        builder.Property(sr => sr.Id)
            .HasColumnName("id");

        builder.Property(sr => sr.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(sr => sr.TypeId)
            .HasColumnName("type_id");

        // Relación: Un StaffRole tiene un StaffType
        builder
            .HasOne(sr => sr.StaffType)
            .WithMany(st => st.StaffRoles)
            .HasForeignKey(sr => sr.TypeId);

        // Relación: Un StaffRole puede tener muchos Staffs
        builder
            .HasMany(sr => sr.Staffs)
            .WithOne(s => s.Role)
            .HasForeignKey(s => s.RoleId);
    }
}
