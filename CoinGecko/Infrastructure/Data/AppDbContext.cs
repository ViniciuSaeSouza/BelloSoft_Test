using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    public DbSet<CryptoPrice> CryptoPrices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CryptoPrice>()
            .Property(p => p.PriceUsd)
            .HasColumnType("decimal(18,4)");
    }

}
