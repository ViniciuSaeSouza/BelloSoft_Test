using Domain.Entities;

namespace Domain.Interfaces;

public interface ICryptoRepository
{
    Task SavePriceAsync(Crypto price);
    Task<List<Crypto>> GetHistoryAsync(string symbol);
}
