using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class StaffTypeConfiguration : IEntityTypeConfiguration<StaffType>
{
    public void Configure(EntityTypeBuilder<StaffType> builder)
    {
        builder.ToTable("StaffTypes"); 

        builder.HasKey(st => st.Id);

        builder.Property(st => st.Id)
            .HasColumnName("id");

        builder.Property(st => st.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

        builder
            .HasIndex(st => st.Name)
            .IsUnique(); 

        // Relación: Un StaffType tiene muchos StaffRoles
        builder
            .HasMany(st => st.StaffRoles)
            .WithOne(sr => sr.StaffType)
            .HasForeignKey(sr => sr.TypeId);
    }
}
