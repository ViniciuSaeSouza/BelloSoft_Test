using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        // GET: api/<PricesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PricesController>/5
        [HttpGet("/prices")]
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
