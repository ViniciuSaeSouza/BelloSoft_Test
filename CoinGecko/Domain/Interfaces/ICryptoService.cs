using Domain.Entities;
using Domain.DTOS;

namespace Domain.Interfaces;

public interface ICryptoService
{
    public Task<Crypto?> GetCryptoInfo(string cryptoId, string currency);
    Task<CryptoHistoryStats?> GetCryptoHistoryStats(string cryptoId, string currency);
    
}
