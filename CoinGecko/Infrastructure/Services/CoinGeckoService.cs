
using Domain.Entities;
using Domain.Interfaces;
using System.Text.Json;

namespace Infrastructure.Services;

public class CoinGeckoService : ICoinGeckoService
{
    private readonly HttpClient _httpClient;
    private readonly string baseAddress = "https://api.coingecko.com/api/v3/";

    public CoinGeckoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseAddress);
    }

    //TODO: Refactor to suppot multiple cryptoId's and currency's
    public async Task<Crypto?> GetCryptoAsync(string cryptoId, string currency)
    {
        try
        {
            if (string.IsNullOrEmpty(cryptoId) || string.IsNullOrEmpty(currency)) return null;

            string? result = await FetchCryptoDataAsync(cryptoId, currency);
            if (string.IsNullOrEmpty(result)) return null;

            Dictionary<string, Dictionary<string, decimal>>? data = DeserializeData(result, cryptoId);
            if (data == null || data.Count == 0) return null;

            Crypto? crypto = MapToCrypto(cryptoId, currency, data);
            if (crypto == null) return null;

            return crypto;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error getting crypto information");
        }
        return null;
    }

    private async Task<string?> FetchCryptoDataAsync(string cryptoId, string currencyParam)
    {
        try
        {
            string? response = await _httpClient.GetStringAsync($"simple/price?vs_currencies={currencyParam}&ids={cryptoId}&include_24hr_change=true");

            if (!string.IsNullOrEmpty(response)) return response;
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data from external API: {ex.Message}");
        }
        return null;
    }

    private Dictionary<string, Dictionary<string, decimal>>? DeserializeData(string result, string cryptoId)
    {
        try
        {
            if (string.IsNullOrEmpty(result)) return null;

            var serializer = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, decimal>>>(result, serializer);

            if (data != null) return data;
            return null;

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during deserialization");
        }
        return null;
    }
    private Crypto? MapToCrypto(string cryptoId, string currency, Dictionary<string, Dictionary<string, decimal>> data)
    {
        try
        {
            if (data != null && data.TryGetValue(cryptoId, out var cryptoDict))
            {
                decimal price = cryptoDict.TryGetValue(currency, out var p) ? p : 0;
                decimal change24hr = cryptoDict.TryGetValue($"{currency}_24h_change", out var c) ? c : 0;

                return new Crypto
                {
                    CryptoId = cryptoId,
                    Currency = currency,
                    Price = price,
                    Change24hr = change24hr,
                    RetrievedAt = DateTime.Now
                };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error mapping data to crypto object: {ex.Message}");
        }
        return null;
    }
}

