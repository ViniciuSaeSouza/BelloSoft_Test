using Domain.Entities;
using Domain.Interfaces;
using Domain.Exceptions;
using Infrastructure.Repositories;

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
        catch(Exception ex)
        {
            throw new ServiceException("Failed to get info from API", ex);
        }


    }
}
