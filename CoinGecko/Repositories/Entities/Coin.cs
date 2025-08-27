using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Coin
{
    [JsonPropertyName("id")]
    public required string CoinId { get; set; }
    [JsonPropertyName("symbol")]
    public required string  Symbol { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
