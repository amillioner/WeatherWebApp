namespace Weather.Api.Data.Models.Response;

public class WeatherResponse
{
    public string ShortForecast { get; set; }
    public double Temperature { get; set; }
    public string Characterization { get; set; }
    public ResponseStatus Status { get; set; }

}