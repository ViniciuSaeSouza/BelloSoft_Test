
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICoinGeckoService
{
    Task<Crypto?> GetCryptoAsync(string cryptoId, string currency);
    Task<PaginatedResult<Coin>?> GetCoinsAsync(int page = 1, int pageSize = 50);
}
