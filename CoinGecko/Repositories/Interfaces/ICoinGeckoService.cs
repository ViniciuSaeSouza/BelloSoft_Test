
namespace Domain.Interfaces;

public interface ICoinGeckoService
{
    Task<decimal?> GetPriceAsync(string cryptId, string currency);
}
