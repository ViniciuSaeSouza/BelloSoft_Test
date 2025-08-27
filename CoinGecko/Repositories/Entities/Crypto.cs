using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Crypto
{
    public required string CryptoId { get; set; }
    public required string Currency { get; set; }
    public decimal Price { get; set; }
    //TODO: Format output to percentage
    public decimal Change24hr { get; set; }
    public DateTime RetrievedAt { get; set; }
}
