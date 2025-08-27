using Domain.Entities;
using Domain.Interfaces;
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
        public readonly ICoinGeckoService _coinGeckoService;

        public CryptoController(ICoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;
        }

        //TODO: Add get all crypto Id's and currency's endopoints

        //TODO: Add Pagination to GetCoins endpoint
        /// <summary>
        /// Retrieves all coin id's from CoinGecko
        /// </summary>
        /// <returns></returns>
        [HttpGet("coins")]
        public async Task<IActionResult> GetCoins()
        {
            try
            {
                var coins = await _coinGeckoService.GetCoinsAsync();    
                return Ok(coins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error: {ex.Message}");
            }

        }

        // GET api/<PricesController>/5
        [HttpGet("prices")]
        public async Task<IActionResult> Get([FromQuery] string cryptoId, [FromQuery] string currency)
        {
            try
            {
                Crypto crypto = await _coinGeckoService.GetCryptoAsync(cryptoId, currency);
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
