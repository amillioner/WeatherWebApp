using System.Threading.Tasks;
using Weather.Api.Data.Models.Geo;
using Weather.Api.Data.Models.Request;

namespace Weather.Api.Graphql.Services;

public interface IGraphqlService
{
    Task<Coordinates> GetAddressAsync(string address);
    Task<Points> GetPointsAsync(Coordinates coordinates);
    Task<Forecast> GetForecastAsync(string officeId, int x, int y);
    Task<Forecast> GetForecastHourlyAsync(string officeId, int x, int y);
}