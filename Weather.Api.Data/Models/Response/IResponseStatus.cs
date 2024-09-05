namespace Weather.Api.Data.Models.Response;

public interface IResponseStatus
{
    string correlationId { get; set; }
    string title { get; set; }
    string type { get; set; }
    int status { get; set; }
    string detail { get; set; }
    string instance { get; set; }
}