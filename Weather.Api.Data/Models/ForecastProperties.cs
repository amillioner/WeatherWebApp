using System;

namespace Weather.Api.Data.Models;

public class ForecastProperties
{
    public string units { get; set; }
    public string forecastGenerator { get; set; }
    public DateTime generatedAt { get; set; }
    public DateTime updateTime { get; set; }
    public string validTimes { get; set; }
    public Elevation elevation { get; set; }
    public Period[] periods { get; set; }
}