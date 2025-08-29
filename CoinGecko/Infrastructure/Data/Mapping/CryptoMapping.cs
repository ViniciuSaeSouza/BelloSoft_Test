using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping;

public class CryptoMapping : IEntityTypeConfiguration<Crypto>
{
    public void Configure(EntityTypeBuilder<Crypto> builder)
    {
        // Set the primary key
        builder.HasKey(c => c.Id);
        
        // Configure properties
        builder.Property(c => c.Price)
            .HasColumnType("decimal(18,4)");
        
        builder.Property(c => c.Change24hrPercentage)
            .HasColumnType("decimal(18,6)");
        
        // Configure unique index
        builder.HasIndex(c => new { c.CryptoId, c.Currency, c.RetrievedAt })
            .IsUnique();
    }
}