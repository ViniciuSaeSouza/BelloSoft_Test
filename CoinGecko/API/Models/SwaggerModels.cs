using System.ComponentModel.DataAnnotations;

namespace API.Models;

/// <summary>
/// Response models for Swagger documentation
/// </summary>
public class SwaggerModels
{
    /// <summary>
    /// Error response model
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; } = string.Empty;
        
        /// <summary>
        /// Timestamp when the error occurred
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// Crypto price information model
    /// </summary>
    public class CryptoPriceResponse
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Cryptocurrency ID (e.g. bitcoin, ethereum)
        /// </summary>
        public string CryptoId { get; set; } = string.Empty;
        
        /// <summary>
        /// Currency code (e.g. usd, eur)
        /// </summary>
        public string Currency { get; set; } = string.Empty;
        
        /// <summary>
        /// Current price in the specified currency
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// 24-hour price change percentage
        /// </summary>
        public decimal Change24hrPercentage { get; set; }
        
        /// <summary>
        /// Timestamp when the data was retrieved
        /// </summary>
        public DateTime RetrievedAt { get; set; }
    }
    
    /// <summary>
    /// Cryptocurrency model
    /// </summary>
    public class CoinResponse
    {
        /// <summary>
        /// Cryptocurrency ID
        /// </summary>
        public string Id { get; set; } = string.Empty;
        
        /// <summary>
        /// Cryptocurrency symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        
        /// <summary>
        /// Cryptocurrency name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// Currency model
    /// </summary>
    public class CurrencyResponse
    {
        /// <summary>
        /// Currency symbol/code
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// Paginated result wrapper
    /// </summary>
    /// <typeparam name="T">Type of items in the result</typeparam>
    public class PaginatedResponse<T>
    {
        /// <summary>
        /// List of items
        /// </summary>
        public IEnumerable<T> Items { get; set; } = new List<T>();
        
        /// <summary>
        /// Current page number
        /// </summary>
        public int Page { get; set; }
        
        /// <summary>
        /// Number of items per page
        /// </summary>
        public int PageSize { get; set; }
        
        /// <summary>
        /// Total number of items across all pages
        /// </summary>
        public int TotalCount { get; set; }
        
        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        
        /// <summary>
        /// Whether there is a next page
        /// </summary>
        public bool HasNext => Page < TotalPages;
        
        /// <summary>
        /// Whether there is a previous page
        /// </summary>
        public bool HasPrevious => Page > 1;
    }
    
    /// <summary>
    /// Cryptocurrency historical statistics
    /// </summary>
    public class CryptoHistoryStatsResponse
    {
        /// <summary>
        /// Cryptocurrency ID
        /// </summary>
        public string CryptoId { get; set; } = string.Empty;
        
        /// <summary>
        /// Currency code
        /// </summary>
        public string Currency { get; set; } = string.Empty;
        
        /// <summary>
        /// Average price
        /// </summary>
        public decimal AveragePrice { get; set; }
        
        /// <summary>
        /// Highest price
        /// </summary>
        public decimal HighestPrice { get; set; }
        
        /// <summary>
        /// Lowest price
        /// </summary>
        public decimal LowestPrice { get; set; }
        
        /// <summary>
        /// Standard deviation of prices
        /// </summary>
        public decimal StandardDeviation { get; set; }
    }
}