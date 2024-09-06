using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Api.Common.Base;
using Weather.Api.Data.Models.Geo;
using Weather.Api.Data.Models.Request;
using Weather.Api.Data.Models.Response;

namespace Weather.Api.Service.Services
{
    public class WeatherService : GenericService, IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;
        private readonly IValidationService _validationService;

        public WeatherService(ILogger<WeatherService> logger
            , HttpClient httpClient
            , IValidationService validationService
            , IConfiguration config)
        : base(logger, httpClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));

            httpClient.BaseAddress = new Uri(config["WeatherOptions:BaseUrl"]);
            httpClient.DefaultRequestHeaders.Add("Accept", config["WeatherOptions:Format"]);
            httpClient.DefaultRequestHeaders.Add("User-Agent", config["WeatherOptions:UserAgent"]);
        }

        public async Task<WeatherResponse> GetAsync(Coordinates coordinates)
        {
            var isValid = _validationService.IsValidICoordinates(coordinates);
            if (!isValid)
                throw new InvalidDataException("Invalid Coordinates!");

            var requestUrl = $"points/{_validationService.Latitude},{_validationService.Longitude}";
            var weatherData = await GetDataAsync<Points>(requestUrl);

            if (weatherData.status is not (200 or 0))
                return SetErrorResponse(weatherData);

            var forecastUrl = weatherData.properties.forecast;
            var forecastData = await GetDataAsync<Forecast>(forecastUrl);

            if (forecastData.status is not (200 or 0))
                return SetErrorResponse(forecastData);

            var res = SetForecastResponse(forecastData);
            return res;
        }

        private static WeatherResponse SetErrorResponse(IResponseStatus resp)
        {
            return new WeatherResponse()
            {
                Status = new ResponseStatus()
                {
                    status = resp.status,
                    correlationId = resp.correlationId,
                    detail = resp.detail,
                    instance = resp.instance,
                    title = resp.title,
                    type = resp.type
                }
            };
        }

        private WeatherResponse SetForecastResponse(Forecast forecastData)
        {
            try
            {
                if (forecastData?.properties.periods == null || !forecastData.properties.periods.Any())
                {
                    _logger.LogWarning("Forecast data is empty or missing.");
                    return new WeatherResponse { ShortForecast = "Forecast data not found.", Characterization = "N/A" };
                }

                var firstPeriod = forecastData.properties.periods.First();
                var shortForecast = firstPeriod.shortForecast;
                var fahrenheit = firstPeriod.temperature;

                var characterization = GetCharacterization(fahrenheit);

                return new WeatherResponse
                {
                    ShortForecast = shortForecast,
                    Temperature = firstPeriod.temperature,
                    Characterization = characterization
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                throw;
            }

        }

        private static string GetCharacterization(double fahrenheit)
        {
            return fahrenheit switch
            {
                >= 86 => "Hot",
                >= 68 => "Moderate",
                >= 50 => "Cold",
                >= 32 => "Freezing Point of Water",
                _ => "Below Freezing"
            };
        }
    }
}
