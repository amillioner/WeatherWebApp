using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using Weather.Ap.Geo;
using Weather.Api.Data.Models.Geo;
using Weather.Api.Data.Models.Request;
using Weather.Api.Service.Services;

namespace Weather.Api.Graphql.Services
{
    public class GraphqlService : IGraphqlService
    {
        private readonly ILogger<GraphqlService> _logger;
        private readonly IValidationService _validationService;
        private readonly IWeatherService _weatherService;
        private readonly IGeoService _geoService;

        public GraphqlService(ILogger<GraphqlService> logger
            , IValidationService validationService
            , IWeatherService weatherService
            , IGeoService geoService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _geoService = geoService ?? throw new ArgumentNullException(nameof(geoService));
        }

        public async Task<Coordinates> GetAddressAsync(string address)
        {
            return await _geoService.ProcessAsync(address);
        }
        public async Task<Points> GetPointsAsync(Coordinates coordinates)
        {
            var isValid = _validationService.IsValidICoordinates(coordinates);
            if (!isValid)
                throw new InvalidDataException("Invalid Coordinates ");

            var longitude = _validationService.Longitude;
            var latitude = _validationService.Latitude;

            var requestUrl = $"points/{latitude},{longitude}";
            var weatherData = await _weatherService.GetDataAsync<Points>(requestUrl);

            return weatherData;
        }
        public async Task<Forecast> GetForecastAsync(string officeId, int x, int y)
        {
            var requestUrl = $"gridpoints/{officeId}/{x},{y}/forecast";
            var data = await _weatherService.GetDataAsync<Forecast>(requestUrl);

            return data;
        }
        public async Task<Forecast> GetForecastHourlyAsync(string officeId, int x, int y)
        {
            var requestUrl = $"gridpoints/{officeId}/{x},{y}/forecast/hourly?units=us";
            var data = await _weatherService.GetDataAsync<Forecast>(requestUrl);

            return data;
        }
    }
}
