using Microsoft.Extensions.DependencyInjection;
using Weather.Api.Service.Services;

namespace Weather.Api.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddSingleton<IValidationService, ValidationService>();
        }
    }
}