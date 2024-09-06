using Microsoft.Extensions.Logging;
using System;
using Weather.Api.Data.Models.Geo;

namespace Weather.Api.Service.Services;

public class ValidationService(ILogger<ValidationService> logger) : IValidationService
{
    private readonly ILogger<ValidationService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    public float Longitude { get; private set; }
    public float Latitude { get; private set; }

    public bool IsValidICoordinates(Coordinates coordinates)
    {
        if (coordinates == null)
        {
            _logger.LogError("Coordinates parameter is empty.");
            return false;
        }

        Longitude = coordinates.x;
        Latitude = coordinates.y;

        if (Longitude < -180 || Longitude > 180 || Latitude < -90 || Latitude > 90)
            _logger.LogError("Coordinates out of range.");


        return Longitude is > -180 and < 180 && Latitude is > -90 and < 90;
    }

}