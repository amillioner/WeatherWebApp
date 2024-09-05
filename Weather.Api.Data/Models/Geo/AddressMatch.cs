namespace Weather.Api.Data.Models.Geo;

public class AddressMatch
{
    public TigerLine tigerLine { get; set; }
    public Coordinates coordinates { get; set; }
    public AddressComponents addressComponents { get; set; }
    public string matchedAddress { get; set; }
}