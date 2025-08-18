using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
	public void Configure(EntityTypeBuilder<Player> builder)
	{
		builder.ToTable("Players");

		builder.HasKey(p => p.Id);

		builder.Property(p => p.Id)
			.HasColumnName("id")
			.ValueGeneratedOnAdd();

		builder.Property(p => p.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(p => p.DorsalNumber)
			.HasColumnName("dorsal");

		builder.Property(p => p.BirthDate)
			.HasColumnName("birth_date");

		builder.Property(p => p.MarketValue)
			.HasColumnName("market_value");

		builder.Property(p => p.TeamId)
			.HasColumnName("team_id");

		builder.Property(p => p.CountryId)
			.HasColumnName("country_id");

		builder.Property(p => p.PositionId)
			.HasColumnName("position_id");

		// Relaciones (definidas desde Player para evitar duplicidad)
		builder.HasOne(p => p.Team)
			.WithMany(t => t.Players)
			.HasForeignKey(p => p.TeamId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(p => p.Country)
			.WithMany(c => c.Players)
			.HasForeignKey(p => p.CountryId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(p => p.Position)
			.WithMany(pos => pos.Players)
			.HasForeignKey(p => p.PositionId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}


