using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
	public void Configure(EntityTypeBuilder<City> builder)
	{
		builder.ToTable("Cities");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Id)
			.HasColumnName("id")
			.ValueGeneratedOnAdd();

		builder.Property(c => c.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(100);

		builder.HasIndex(c => c.Name).IsUnique();
	}
}


