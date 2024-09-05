using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace Weather.Api.Common.HttpOptions;

public class GeoHttpOptions(HttpClient httpClient, IConfiguration config) : IGeoHttpOptions
{
    public void SetOptions()
    {
        httpClient.BaseAddress = new Uri(config["WeatherOptions:BaseGeoUrl"]);
    }
}