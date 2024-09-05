using Weather.Api.Data.Models.Response;

namespace Weather.Api.Data.Models.Request;

public class Points : IResponseStatus
{
    //public object[] context { get; set; }
    public string id { get; set; }
    public string correlationId { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public int status { get; set; }
    public string detail { get; set; }
    public string instance { get; set; }
    public Point geometry { get; set; }
    public Properties properties { get; set; }
}
