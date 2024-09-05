using Weather.Api.Data.Models.Response;

namespace Weather.Api.Data.Models.Request;

public class Forecast : IResponseStatus
{
    //public object[] context { get; set; }
    public string correlationId { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public int status { get; set; }
    public string detail { get; set; }
    public string instance { get; set; }
    public Polygon geometry { get; set; }
    public ForecastProperties properties { get; set; }
}