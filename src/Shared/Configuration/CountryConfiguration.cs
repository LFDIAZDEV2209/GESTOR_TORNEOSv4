using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries"); // Nombre exacto en la base

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.HasIndex(c => c.Name)
            .IsUnique(); // En tu SQL el name es UNIQUE

        // Relación con Players (1:N)
        // builder
        //     .HasMany(c => c.Players)
        //     .WithOne(p => p.Country)
        //     .HasForeignKey(p => p.CountryId)
        //     .OnDelete(DeleteBehavior.SetNull);

    }
}
