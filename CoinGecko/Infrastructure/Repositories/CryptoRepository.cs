using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class CryptoRepository : ICryptoRepository
{
    public Task<List<Crypto>> GetHistoryAsync(string symbol)
    {
        throw new NotImplementedException();
    }

    public Task SavePriceAsync(Crypto price)
    {
        throw new NotImplementedException();
    }
}
