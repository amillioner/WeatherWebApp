using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Api.Common.Base;
using Weather.Api.Data.Models.Geo;

namespace Weather.Ap.Geo;

public class GeoService : GenericService, IGeoService
{
    private readonly ILogger<GeoService> _logger;

    public GeoService(ILogger<GeoService> logger, HttpClient httpClient, IConfiguration config)
    : base(logger, httpClient)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        httpClient.BaseAddress = new Uri(config["WeatherOptions:BaseGeoUrl"]);
    }
    public async Task<Coordinates> ProcessAsync(string address)
    {
        var requestUrl = $"geocoder/locations/onelineaddress?address={address}&benchmark=4&format=json";
        var geoData = await GetDataAsync<GeoLocation>(requestUrl);
        return geoData.result.addressMatches.FirstOrDefault()?.coordinates;
    }

}