using System.Threading.Tasks;
using Weather.Api.Data.Models.Geo;
using Weather.Api.Data.Models.Request;
using Weather.Api.Graphql.Services;

namespace Weather.Api.Graphql.Graph
{
    public class Query
    {
        private readonly IGraphqlService _graphqlService;

        public Query(IGraphqlService graphqlService)
        {
            _graphqlService = graphqlService;
        }

        public async Task<Coordinates> GetAddressAsync(string address)
        {
            return await _graphqlService.GetAddressAsync(address);
        }
        public async Task<Points> GetPoints(Coordinates coordinates)
        {
            return await _graphqlService.GetPointsAsync(coordinates);
        }
        public async Task<Forecast> GetForecast(string forecastOfficeId, int gridX, int gridY)
        {
            return await _graphqlService.GetForecastAsync(forecastOfficeId, gridX, gridY);
        }
        public async Task<Forecast> GetForecastHourly(string forecastOfficeId, int gridX, int gridY)
        {
            return await _graphqlService.GetForecastHourlyAsync(forecastOfficeId, gridX, gridY);
        }
    }
}