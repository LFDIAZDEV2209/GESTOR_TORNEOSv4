using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class PlayerStatsConfiguration : IEntityTypeConfiguration<PlayerStats>
{
	public void Configure(EntityTypeBuilder<PlayerStats> builder)
	{
		builder.ToTable("PlayerStats");

		builder.HasKey(ps => ps.Id);

		builder.Property(ps => ps.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(ps => ps.PlayerId).HasColumnName("player_id").IsRequired();
		builder.Property(ps => ps.MatchId).HasColumnName("match_id").IsRequired();
		builder.Property(ps => ps.Goals).HasColumnName("goals").HasDefaultValue(0);
		builder.Property(ps => ps.Assists).HasColumnName("assists").HasDefaultValue(0);
		builder.Property(ps => ps.MinutesPlayed).HasColumnName("minutes_played").HasDefaultValue(0);

		builder.HasOne(ps => ps.Player)
			.WithMany()
			.HasForeignKey(ps => ps.PlayerId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(ps => ps.Match)
			.WithMany()
			.HasForeignKey(ps => ps.MatchId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}


