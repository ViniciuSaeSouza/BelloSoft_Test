using Domain.Entities;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Crypto> CryptoHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply entity configurations from mapping classes
        modelBuilder.ApplyConfiguration(new CryptoMapping());
    }
}
