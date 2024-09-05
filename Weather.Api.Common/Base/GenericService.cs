using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Weather.Api.Common.Base;

public abstract class GenericService(ILogger logger, HttpClient httpClient)
{
    private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    public virtual async Task<T> GetDataAsync<T>(string requestUrl) where T : new()
    {
        if (string.IsNullOrWhiteSpace(requestUrl))
            throw new ArgumentException("Request URL is missing.", nameof(requestUrl));

        var response = await GetResponseAsync(requestUrl);

        return await ReadResponseAsync<T>(response);
    }

    private async Task<HttpResponseMessage> GetResponseAsync(string requestUrl)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

        try
        {
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                _logger.LogError("Error: {StatusCode} - {ReasonPhrase}, URL: {RequestUrl}", response.StatusCode, response.ReasonPhrase, requestUrl);

            return response;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Request error, URL: {RequestUrl}", requestUrl);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error, URL: {RequestUrl}", requestUrl);
            throw;
        }
    }

    private static async Task<T> ReadResponseAsync<T>(HttpResponseMessage message) where T : new()
    {
        if (message.Content == null)
            throw new InvalidOperationException("Response content is null.");

        var responseData = await message.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseData, JsonSerializerOptions);
    }
}