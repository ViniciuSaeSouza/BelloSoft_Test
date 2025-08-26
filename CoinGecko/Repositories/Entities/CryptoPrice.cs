using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class CryptoPrice
{
    public string Id { get; private set; }
    public string Symbol { get; set; }
    public decimal PriceUsd { get; set; }
    public DateTime RetrievedAt { get; set; }
}
