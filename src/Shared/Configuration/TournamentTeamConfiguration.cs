using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TournamentTeamConfiguration : IEntityTypeConfiguration<TournamentTeam>
{
    public void Configure(EntityTypeBuilder<TournamentTeam> builder)
    {
        builder.ToTable("TournamentTeams");

        builder.HasKey(tt => new { tt.TournamentId, tt.TeamId });

        builder.Property(tt => tt.TournamentId)
            .HasColumnName("tournament_id")
            .IsRequired(); 

        builder.Property(tt => tt.TeamId)
            .HasColumnName("team_id")
            .IsRequired();

        builder
            .HasOne(tt => tt.Tournament)
            .WithMany(t => t.TournamentTeam)
            .HasForeignKey(tt => tt.TournamentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(tt => tt.Team)
            .WithMany(t => t.TournamentTeam)
            .HasForeignKey(tt => tt.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
