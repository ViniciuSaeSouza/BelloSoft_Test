using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class CryptoHistoryStats
    {
        public string CryptoId { get; set; }
        public string Currency { get; set; }
        public int Count { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal LastPrice { get; set; }
        public decimal LastChange24hrPercentage { get; set; }
        public DateTime LastRetrievedAt { get; set; }
    }
}
