using Microsoft.Extensions.Logging;
using System;

namespace Weather.Api.Service.Services;

public class ValidationService(ILogger<ValidationService> logger) : IValidationService
{
    private readonly ILogger<ValidationService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    public double Longitude { get; private set; }
    public double Latitude { get; private set; }

    public bool IsValidCoordinates(string coordinates)
    {
        if (string.IsNullOrWhiteSpace(coordinates))
        {
            _logger.LogError("Coordinates parameter is empty.");
            return false;
        }

        var parts = coordinates.Split(',');

        if (parts.Length != 2 ||
            !double.TryParse(parts[0], out double longitude) ||
            !double.TryParse(parts[1], out double latitude))
        {
            _logger.LogError("Invalid coordinates format. Use 'longitude,latitude'.");
            return false;
        }

        if (longitude < -180 || longitude > 180 || latitude < -90 || latitude > 90)
            _logger.LogError("Coordinates out of range.");

        Longitude = longitude;
        Latitude = latitude;

        return longitude is > -180 and < 180 && latitude is > -90 and < 90;
    }

}