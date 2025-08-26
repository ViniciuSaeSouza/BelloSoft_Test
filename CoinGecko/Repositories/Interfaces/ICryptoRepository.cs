using Domain.Entities;

namespace Domain.Interfaces;

public interface ICryptoRepository
{
    Task SavePriceAsync(CryptoPrice price);
    Task<List<CryptoPrice>> GetHistoryAsync(string symbol);
}
