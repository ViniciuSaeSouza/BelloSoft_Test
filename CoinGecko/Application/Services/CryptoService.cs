using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.DTOS;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class CryptoService : ICryptoService
{
    private readonly ICoinGeckoService _coinGeckoService;
    private readonly AppDbContext _dbContext;

    public CryptoService(ICoinGeckoService coinGeckoService, AppDbContext dbContext)
    {
        _coinGeckoService = coinGeckoService;
        _dbContext = dbContext;
    }

    public async Task<Crypto?> GetCryptoInfo(string cryptoId, string currency)
    {
        try
        {
            var crypto = await _coinGeckoService.GetCryptoAsync(cryptoId, currency);
            if (crypto == null) return null;

            await _dbContext.CryptoHistory.AddAsync(crypto);
            await _dbContext.SaveChangesAsync();
            Console.WriteLine($"Crypto info for {cryptoId} saved in DataBase");
            return crypto;
        }
        catch (Exception ex)
        {
            throw new ServiceException("Failed to get info from API", ex);
        }


    }

    public async Task<CryptoHistoryStats?> GetCryptoHistoryStats(string cryptoId, string currency)
    {
        var history = await _dbContext.CryptoHistory
            .Where(c => c.CryptoId == cryptoId && c.Currency == currency)
            .OrderBy(c => c.RetrievedAt)
            .ToListAsync();

        if (history == null || history.Count == 0) return null;

        return new CryptoHistoryStats
        {
            CryptoId = cryptoId,
            Currency = currency,
            Count = history.Count,
            MinPrice = history.Min(c => c.Price),
            MaxPrice = history.Max(c => c.Price),
            AvgPrice = history.Average(c => c.Price),
            LastPrice = history.Last().Price,
            LastChange24hrPercentage = history.Last().Change24hrPercentage,
            LastRetrievedAt = history.Last().RetrievedAt
        };
    }
}
