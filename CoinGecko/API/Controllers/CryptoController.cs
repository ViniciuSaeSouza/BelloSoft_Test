using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;
        private readonly ICoinGeckoService _coinGeckoService;

        public CryptoController(ICryptoService cryptoService, ICoinGeckoService coinGeckoService)
        {
            _cryptoService = cryptoService;
            _coinGeckoService = coinGeckoService;
        }

        //TODO: Add get all crypto Id's and currency's endopoints

        //TODO: Add Pagination to GetCoins endpoint
        /// <summary>
        /// Retrieves all coin id's from CoinGecko
        /// </summary>
        /// <returns></returns>
        [HttpGet("coins")]
        public async Task<IActionResult> GetCoins([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            try
            {
                var coins = await _coinGeckoService.GetCoinsAsync(page, pageSize);
                if (coins == null) return NotFound();
                return  Ok(coins);
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

        [HttpGet("currencies")]
        public async Task<IActionResult> GetCurrencies([FromQuery] int page = 1, int pageSize = 20)
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

        // GET api/<PricesController>/5
        [HttpGet("prices")]
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

        [HttpGet("prices/history")]
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
