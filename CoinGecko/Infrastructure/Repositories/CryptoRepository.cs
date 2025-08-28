using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class CryptoRepository : ICryptoRepository
{
    private readonly AppDbContext _dbContext;

    public CryptoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Crypto>> GetHistoryAsync(string cryptoId)
    {
        return await _dbContext.CryptoHistory.Where(c => c.CryptoId == cryptoId).ToListAsync();

    }

    public async void SavePriceAsync(Crypto cryptoInfo)
    {
        await _dbContext.CryptoHistory.AddAsync(cryptoInfo);
        _dbContext.SaveChanges();
    }
}
