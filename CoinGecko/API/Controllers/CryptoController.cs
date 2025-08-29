using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    /// <summary>
    /// API controller for cryptocurrency operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;
        private readonly ICoinGeckoService _coinGeckoService;

        /// <summary>
        /// Constructor for CryptoController
        /// </summary>
        /// <param name="cryptoService">Service for crypto operations</param>
        /// <param name="coinGeckoService">Service for CoinGecko API operations</param>
        public CryptoController(ICryptoService cryptoService, ICoinGeckoService coinGeckoService)
        {
            _cryptoService = cryptoService;
            _coinGeckoService = coinGeckoService;
        }

        /// <summary>
        /// Retrieves a paginated list of available cryptocurrencies from CoinGecko
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 50)</param>
        /// <returns>A paginated list of cryptocurrency coins</returns>
        /// <response code="200">Returns the list of coins</response>
        /// <response code="400">If the request parameters are invalid</response>
        /// <response code="404">If no coins were found</response>
        /// <response code="502">If there was an error communicating with CoinGecko API</response>
        [HttpGet("coins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> GetCoins([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            try
            {
                var coins = await _coinGeckoService.GetCoinsAsync(page, pageSize);
                if (coins == null) return NotFound();
                return Ok(coins);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (ExternalApiException ex)
            {
                return StatusCode(502, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a paginated list of supported currencies from CoinGecko
        /// </summary>
        /// <param name="page">Page number (default: 1)</param>
        /// <param name="pageSize">Number of items per page (default: 20)</param>
        /// <returns>A paginated list of supported currencies</returns>
        /// <response code="200">Returns the list of currencies</response>
        /// <response code="400">If the request parameters are invalid</response>
        /// <response code="404">If no currencies were found</response>
        /// <response code="502">If there was an error communicating with CoinGecko API</response>
        [HttpGet("currencies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> GetCurrencies([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            try
            {
                var currencies = await _coinGeckoService.GetCurrenciesAsync(page, pageSize);
                if (currencies == null) return NotFound();
                return Ok(currencies);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (ExternalApiException ex)
            {
                return StatusCode(502, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Retrieves current price information for a specific cryptocurrency and currency
        /// </summary>
        /// <param name="cryptoId">The ID of the cryptocurrency (default: bitcoin)</param>
        /// <param name="currency">The currency to display the price in (default: usd)</param>
        /// <returns>Current price information for the specified cryptocurrency</returns>
        /// <response code="200">Returns the cryptocurrency information</response>
        /// <response code="400">If the request parameters are invalid</response>
        /// <response code="404">If the cryptocurrency was not found</response>
        [HttpGet("prices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPrice([FromQuery] string cryptoId = "bitcoin", [FromQuery] string currency = "usd")
        {
            try
            {
                Crypto crypto = await _cryptoService.GetCryptoInfo(cryptoId, currency);
                if (crypto != null) return Ok(crypto);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves historical price statistics for a specific cryptocurrency and currency
        /// </summary>
        /// <param name="cryptoId">The ID of the cryptocurrency (default: bitcoin)</param>
        /// <param name="currency">The currency to display the prices in (default: usd)</param>
        /// <returns>Historical price statistics for the specified cryptocurrency</returns>
        /// <response code="200">Returns the historical statistics</response>
        /// <response code="400">If the request parameters are invalid</response>
        /// <response code="404">If no historical data was found</response>
        /// <response code="500">If there was an error processing the request</response>
        [HttpGet("prices/history")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHistoryStats([FromQuery] string cryptoId = "bitcoin", [FromQuery] string currency = "usd")
        {
            try
            {
                var stats = await _cryptoService.GetCryptoHistoryStats(cryptoId, currency);
                if (stats == null) return NotFound();
                return Ok(stats);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (ServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
