using System.Threading.Tasks;
using Weather.Api.Data.Models.Geo;
using Weather.Api.Data.Models.Response;

namespace Weather.Api.Service.Services;

public interface IWeatherService
{
    Task<WeatherResponse> GetAsync(Coordinates coordinates);
    Task<T> GetDataAsync<T>(string requestUrl) where T : new();
}