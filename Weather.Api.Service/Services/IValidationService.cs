namespace Weather.Api.Service.Services;

public interface IValidationService
{
    double Longitude { get; }
    double Latitude { get; }
    bool IsValidCoordinates(string coordinates);
}