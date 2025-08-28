using Domain.Entities;
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
                return (coins == null) ? NotFound() : Ok(coins);
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
                return (currencies == null) ? NotFound() : Ok(currencies);
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

        //// POST api/<PricesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PricesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PricesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
