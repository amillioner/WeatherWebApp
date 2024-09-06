using Weather.Api.Data.Models.Geo;

namespace Weather.Api.Service.Services;

public interface IValidationService
{
    float Longitude { get; }
    float Latitude { get; }
    bool IsValidICoordinates(Coordinates coordinates);
}