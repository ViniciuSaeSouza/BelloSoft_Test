
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICoinGeckoService
{
    Task<Crypto?> GetCryptoInfoAsync(string cryptoId, string currency);
}
