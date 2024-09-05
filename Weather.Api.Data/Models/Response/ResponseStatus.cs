namespace Weather.Api.Data.Models.Response;

public class ResponseStatus : IResponseStatus
{
    public string correlationId { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public int status { get; set; }
    public string detail { get; set; }
    public string instance { get; set; }
}