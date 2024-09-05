namespace Weather.Api.Data.Models.Geo;

public class Result
{
    public Input input { get; set; }
    public AddressMatch[] addressMatches { get; set; }
}