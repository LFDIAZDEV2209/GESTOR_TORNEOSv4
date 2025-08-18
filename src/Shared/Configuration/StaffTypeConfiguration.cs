using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class StaffTypeConfiguration : IEntityTypeConfiguration<StaffType>
{
	public void Configure(EntityTypeBuilder<StaffType> builder)
	{
		builder.ToTable("StaffTypes");

		builder.HasKey(st => st.Id);

		builder.Property(st => st.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(st => st.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
		builder.HasIndex(st => st.Name).IsUnique();
	}
}


