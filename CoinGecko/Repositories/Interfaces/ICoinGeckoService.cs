
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICoinGeckoService
{
    Task<Crypto?> GetCryptoAsync(string cryptoId, string currency);
}
