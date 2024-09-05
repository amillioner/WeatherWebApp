using Microsoft.Extensions.DependencyInjection;

namespace Weather.Ap.Geo.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterGeoServices(this IServiceCollection services)
        {
            services.AddSingleton<IGeoService, GeoService>();
        }
    }
}