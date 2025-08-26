namespace Domain.Entities;

public class CryptoPrice
{
    public string Id { get; private set; }
    public string Symbol { get; set; }
    public decimal PriceUsd { get; set; }
    public DateTime RetrievedAt { get; set; }
}
