namespace Weather.Api.Data.Models;

public class LocationProperties
{
    public string city { get; set; }
    public string state { get; set; }
    public Distance distance { get; set; }
    public Bearing bearing { get; set; }
}