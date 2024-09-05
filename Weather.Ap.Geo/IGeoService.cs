using System.Threading.Tasks;
using Weather.Api.Data.Models.Geo;

namespace Weather.Ap.Geo;

public interface IGeoService
{
    Task<Coordinates> ProcessAsync(string address);
}