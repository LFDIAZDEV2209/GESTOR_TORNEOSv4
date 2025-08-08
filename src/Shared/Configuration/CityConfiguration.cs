using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
        // Aquí no hace falta configurar Teams, EF lo hace automáticamente por la relación en Team
    }
}
