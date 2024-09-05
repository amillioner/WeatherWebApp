using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace Weather.Api.Common.HttpOptions;

public class WeatherHttpOptions(HttpClient httpClient, IConfiguration config) : IWeatherHttpOptions
{
    public void SetOptions()
    {
        httpClient.BaseAddress = new Uri(config["WeatherOptions:BaseUrl"]);
        httpClient.DefaultRequestHeaders.Add("Accept", config["WeatherOptions:Format"]);
        httpClient.DefaultRequestHeaders.Add("User-Agent", config["WeatherOptions:UserAgent"]);
    }
}