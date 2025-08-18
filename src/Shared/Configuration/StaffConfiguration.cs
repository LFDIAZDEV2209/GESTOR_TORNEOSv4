using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GESTOR_TORNEOSv4.src.Shared.Configuration;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
	public void Configure(EntityTypeBuilder<Staff> builder)
	{
		builder.ToTable("Staff");

		builder.HasKey(s => s.Id);

		builder.Property(s => s.Id).HasColumnName("id").ValueGeneratedOnAdd();
		builder.Property(s => s.TeamId).HasColumnName("team_id");
		builder.Property(s => s.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
		builder.Property(s => s.CountryId).HasColumnName("country_id");
		builder.Property(s => s.RoleId).HasColumnName("role_id").IsRequired();

		builder.HasOne(s => s.Team)
			.WithMany(t => t.Staffs)
			.HasForeignKey(s => s.TeamId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(s => s.Role)
			.WithMany(sr => sr.Staffs)
			.HasForeignKey(s => s.RoleId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(s => s.Country)
			.WithMany(c => c.Staffs)
			.HasForeignKey(s => s.CountryId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}


