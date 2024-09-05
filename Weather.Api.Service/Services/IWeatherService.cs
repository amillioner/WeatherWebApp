using System.Threading.Tasks;
using Weather.Api.Data.Models.Response;

namespace Weather.Api.Service.Services;

public interface IWeatherService
{
    Task<WeatherResponse> GetAsync(string coordinates);
    Task<T> GetDataAsync<T>(string requestUrl) where T : new();
}