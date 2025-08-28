using Domain.Entities;

namespace Domain.Interfaces;

public interface ICryptoRepository
{
    void SavePriceAsync(Crypto price);
    Task<List<Crypto>> GetHistoryAsync(string symbol);
}
