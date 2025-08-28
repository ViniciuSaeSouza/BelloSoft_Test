
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.IdentityModel.Tokens;
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
        // TODO: Separate validation on new ICoinGeckoServiceValidator class
        ValidateParameters(cryptoId, currency);

        var queryParam = $"simple/price?vs_currencies={currency}&ids={cryptoId}&include_24hr_change=true";

        try
        {
            string? response = await FetchCryptoDataAsync(queryParam);
            if (string.IsNullOrEmpty(response)) return null;

            Dictionary<string, Dictionary<string, decimal>>? data = DeserializeData<Dictionary<string, Dictionary<string, decimal>>>(response);
            if (data == null || data.Count == 0) return null;

            Crypto? crypto = MapToCrypto(cryptoId, currency, data);

            return crypto;
        }
        catch (HttpRequestException ex)
        {
            throw new ExternalApiException($"Failed to connect to CoinGecko API: {ex.Message}", ex);
        }
        catch (JsonException ex)
        {
            throw new ExternalApiException("Failed to parse data CoinGecko response", ex);
        }
        catch (Exception ex)
        {
            throw new Exception("Internal server error", ex);
        }
    }


    public async Task<PaginatedResult<Coin>?> GetCoinsAsync(int page = 1, int pageSize = 50)
    {
        if (page == 0 || pageSize == 0) throw new ArgumentException("Page or Page Size cannot be 0");
        var queryParam = "coins/list";
        try
        {
            string? response = await FetchCryptoDataAsync(queryParam);
            if (string.IsNullOrEmpty(response)) return null;

            IEnumerable<Coin>? coins = DeserializeData<IEnumerable<Coin>>(response);
            if (coins == null) return null;

            var totalCoins = coins.Count();
            var paginatedCoins = coins
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedResult<Coin> 
            {
                Items = paginatedCoins,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCoins
            }; 

        }
        catch (HttpRequestException ex)
        {
            throw new ExternalApiException("Failed to connect to CoinGecko API", ex);
        }
        catch (JsonException ex)
        {
            throw new ExternalApiException("Failed to parse data from CoinGecko", ex);
        }
    }

    private static void ValidateParameters(string cryptoId, string currency)
    {
        if (string.IsNullOrWhiteSpace(cryptoId)) throw new ArgumentException("ERROR: cryptoId cannot be null or empty", nameof(cryptoId));
        if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("ERROR: currency cannot be null or empty", nameof(currency));
    }

    private async Task<string?> FetchCryptoDataAsync(string queryParam)
    {
        return await _httpClient.GetStringAsync(queryParam); ;
    }

    private T? DeserializeData<T>(string response)
    {
        if (string.IsNullOrEmpty(response)) return default;

        var serializer = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var data = JsonSerializer.Deserialize<T>(response, serializer);

        return data;
    }

    private Crypto? MapToCrypto(string cryptoId, string currency, Dictionary<string, Dictionary<string, decimal>> data)
    {
        if (!data.TryGetValue(cryptoId, out var cryptoDict)) return null;

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

