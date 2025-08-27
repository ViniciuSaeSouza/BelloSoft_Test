
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace Infrastructure.Services;

public class CoinGeckoService : ICoinGeckoService
{
    public async Task<Crypto?> GetCryptoInfoAsync(string cryptoId, string currencyParam)
    {
        var baseAddress = "https://api.coingecko.com/api/v3/simple/price";
        using HttpClient client = new HttpClient() { BaseAddress = new Uri(baseAddress) };
        try
        {
            Console.WriteLine("Inicio request");
            string? response = await client.GetStringAsync($"?vs_currencies={currencyParam}&ids={cryptoId}&include_24hr_change=true");
            Console.WriteLine("Pos request");

            if (string.IsNullOrEmpty(response)) return null;

            var data =  JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, decimal>>>(response);

            if ((data != null && data.Count > 0) && data.TryGetValue(cryptoId, out Dictionary<string, decimal> infoDict))
            {
                decimal price = infoDict.TryGetValue(currencyParam, out var p) ? p : 0;
                decimal change24hr = infoDict.TryGetValue($"{currencyParam}_24h_change", out var c) ? c : 0;

                return new Crypto
                {
                    Id = cryptoId,
                    Currency = currencyParam,
                    Price = price,
                    Change24hr = change24hr,
                    RetrievedAt = DateTime.Now
                };
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return null;
        }
    }
}
