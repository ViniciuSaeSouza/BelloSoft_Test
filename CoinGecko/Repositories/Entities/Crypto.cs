using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Crypto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string CryptoId { get; set; }
    public required string Currency { get; set; }
    public decimal Price { get; set; }
    //TODO: Format output to percentage
    public decimal Change24hrPercentage { get; set; }
    public DateTime RetrievedAt { get; set; }
}
