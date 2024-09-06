using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Weather.Ap.Geo;
using Weather.Api.Data.Models.Geo;
using Weather.Api.Service.Services;

namespace Weather.Api.Web.Controllers
{
    [ApiController]
    [Route("/api")]
    public class WeatherController : ControllerBase
    {

        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;
        private readonly IGeoService _geoService;

        public WeatherController(
            ILogger<WeatherController> logger
            , IWeatherService weatherService
            , IGeoService geoService)
        {
            _weatherService = weatherService;
            _geoService = geoService;
            _logger = logger;
        }


        [HttpGet("getAddress/{address}")]
        public async Task<IActionResult> GetAddress(string address)
        {
            var res = await _geoService.ProcessAsync(address);
            return Ok(res);
        }

        /// <summary>
        /// Retrieves weather data based on the provided Coordinates.
        /// </summary>
        /// <remarks>
        /// Coordinates in the format "longitude,latitude". 
        /// Latitude should be between -90 and 90, and longitude should be between -180 and 180.
        /// For example: "-122.4194,37.7749".
        /// </remarks>
        /// <param name="coordinates">
        /// Coordinates in the format "longitude,latitude". 
        /// Latitude should be between -90 and 90, and longitude should be between -180 and 180.
        /// For example: "-122.4194,37.7749".
        /// </param>
        /// <returns>A JSON object containing weather data.</returns>
        /// <response code="200">Returns the weather data for the specified Coordinates.</response>
        /// <response code="400">If the Coordinates are invalid or the format is incorrect.</response>
        /// <response code="404">If the weather data is not found.</response>
        [HttpPost("coordinates/")]
        //[Consumes("application/json")]
        public async Task<IActionResult> GetCoordinates([FromBody] Coordinates coordinates)
        {

            var res = await _weatherService.GetAsync(coordinates);
            return Ok(res);
        }
    }
}