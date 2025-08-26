using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface ICoinGeckoService
{
    Task<decimal?> GetPriceAsync(string cryptId, string currency);
}
