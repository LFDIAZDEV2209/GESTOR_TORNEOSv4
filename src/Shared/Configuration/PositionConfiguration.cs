using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
	public void Configure(EntityTypeBuilder<Position> builder)
	{
		builder.ToTable("Positions");

		builder.HasKey(p => p.Id);

		builder.Property(p => p.Id)
			.HasColumnName("id")
			.ValueGeneratedOnAdd();

		builder.Property(p => p.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(100);

		builder.HasIndex(p => p.Name).IsUnique();
	}
}


