using Microsoft.Extensions.DependencyInjection;
using Weather.Api.Common.HttpOptions;

namespace Weather.Api.Common.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterConfigs(this IServiceCollection services)
        {
            services.AddSingleton<IHttpOptions, GeoHttpOptions>();
            services.AddSingleton<IGeoHttpOptions, GeoHttpOptions>();
            services.AddSingleton<IHttpOptions, WeatherHttpOptions>();
            services.AddSingleton<IWeatherHttpOptions, WeatherHttpOptions>();
        }
    }
}