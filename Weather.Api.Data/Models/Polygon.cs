using HotChocolate;

namespace Weather.Api.Data.Models;

public class Polygon
{
    public string type { get; set; }
    [GraphQLIgnore]
    public float[][][] coordinates { get; set; }
}
