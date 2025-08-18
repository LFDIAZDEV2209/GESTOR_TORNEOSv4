using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
	public void Configure(EntityTypeBuilder<Transfer> builder)
	{
		builder.ToTable("Transfers");

		builder.HasKey(t => t.Id);

		builder.Property(t => t.Id)
			.HasColumnName("id")
			.ValueGeneratedOnAdd();

		builder.Property(t => t.PlayerId)
			.HasColumnName("player_id")
			.IsRequired();

		builder.Property(t => t.OriginTeamId)
			.HasColumnName("origin_team_id");

		builder.Property(t => t.DestinationTeamId)
			.HasColumnName("destination_team_id")
			.IsRequired();

		builder.Property(t => t.TransferDate)
			.HasColumnName("transfer_date")
			.IsRequired();

		builder.Property(t => t.TransferType)
			.HasColumnName("transfer_type")
			.IsRequired();

		builder.Property(t => t.Amount)
			.HasColumnName("amount");

		// Relaciones mínimas
		builder.HasOne(t => t.Player)
			.WithMany()
			.HasForeignKey(t => t.PlayerId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(t => t.OriginTeam)
			.WithMany()
			.HasForeignKey(t => t.OriginTeamId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(t => t.DestinationTeam)
			.WithMany()
			.HasForeignKey(t => t.DestinationTeamId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}


