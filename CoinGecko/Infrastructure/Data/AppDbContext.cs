using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    public DbSet<Crypto> CryptoHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TODO: Migrate this mapping logic to a Mapping class
        modelBuilder.Entity<Crypto>()
            .Property(c => c.Price)
            .HasColumnType("decimal(18,4)");
        
        modelBuilder.Entity<Crypto>()
            .Property(c => c.Change24hrPercentage)
            .HasColumnType("decimal(6,4)");
        
        // Use Id as the primary key instead of CryptoId
        modelBuilder.Entity<Crypto>()
            .HasKey(c => c.Id);
        
        
        modelBuilder.Entity<Crypto>()
            .HasIndex(c => new { c.CryptoId, c.Currency, c.RetrievedAt })
            .IsUnique();
    }

}
