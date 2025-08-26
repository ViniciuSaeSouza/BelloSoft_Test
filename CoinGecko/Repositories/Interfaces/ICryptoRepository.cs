using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface ICryptoRepository
{
    Task SavePriceAsync(CryptoPrice price);
    Task<List<CryptoPrice>> GetHistoryAsync(string symbol);
}
