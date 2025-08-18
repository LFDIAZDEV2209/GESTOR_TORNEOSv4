using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
	public void Configure(EntityTypeBuilder<Match> builder)
	{
		builder.ToTable("Matches");

		builder.HasKey(m => m.Id);

		builder.Property(m => m.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(m => m.TournamentId).HasColumnName("tournament_id").IsRequired();
		builder.Property(m => m.HomeTeamId).HasColumnName("home_team_id").IsRequired();
		builder.Property(m => m.AwayTeamId).HasColumnName("away_team_id").IsRequired();
		builder.Property(m => m.MatchDate).HasColumnName("match_date").IsRequired();
		builder.Property(m => m.HomeScore).HasColumnName("home_score").HasDefaultValue(0);
		builder.Property(m => m.AwayScore).HasColumnName("away_score").HasDefaultValue(0);
		builder.Property(m => m.IsFinished).HasColumnName("is_finished").HasDefaultValue(false);

		builder.HasOne(m => m.Tournament)
			.WithMany()
			.HasForeignKey(m => m.TournamentId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(m => m.HomeTeam)
			.WithMany()
			.HasForeignKey(m => m.HomeTeamId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(m => m.AwayTeam)
			.WithMany()
			.HasForeignKey(m => m.AwayTeamId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}


