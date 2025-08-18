using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class StaffRoleConfiguration : IEntityTypeConfiguration<StaffRole>
{
	public void Configure(EntityTypeBuilder<StaffRole> builder)
	{
		builder.ToTable("StaffRoles");

		builder.HasKey(sr => sr.Id);

		builder.Property(sr => sr.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(sr => sr.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
		builder.Property(sr => sr.TypeId).HasColumnName("type_id").IsRequired();

		builder.HasOne(sr => sr.StaffType)
			.WithMany(st => st.StaffRoles)
			.HasForeignKey(sr => sr.TypeId);
	}
}


