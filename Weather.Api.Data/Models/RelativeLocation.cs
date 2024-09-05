namespace Weather.Api.Data.Models;

public class RelativeLocation
{
    public string type { get; set; }
    public Point geometry { get; set; }
    public LocationProperties properties { get; set; }
}