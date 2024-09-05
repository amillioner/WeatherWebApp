using Microsoft.Extensions.DependencyInjection;
using Weather.Api.Graphql.Services;

namespace Weather.Api.Graphql.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterGraphServices(this IServiceCollection services)
        {
            services.AddSingleton<IGraphqlService, GraphqlService>();
        }
    }
}