﻿using System;

namespace Weather.Api.Data.Models;

public class Period
{
    public int number { get; set; }
    public string name { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public bool isDaytime { get; set; }
    public int temperature { get; set; }
    public string temperatureTrend { get; set; }
    public ProbabilityOfPrecipitation probabilityOfPrecipitation { get; set; }
    public DewPoint dewpoint { get; set; }
    public RelativeHumidity relativeHumidity { get; set; }
    public string windSpeed { get; set; }
    public string windDirection { get; set; }
    public string icon { get; set; }
    public string shortForecast { get; set; }
    public string detailedForecast { get; set; }
}