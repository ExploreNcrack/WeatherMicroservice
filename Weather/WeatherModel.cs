using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather
{
    // can just copy paste the payload(json), visual studio will auto convert it to C# types
    public class Forecast
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int weatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public object PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public Realfeeltemperature Realfeeltemperature { get; set; }
        public int RelativeHumidity { get; set; }
        public Dewpoint Dewpoint { get; set; }
        public Wind Wind { get; set; }
        public Windgust Windgust { get; set; }
        public int UVIndex { get; set; }
        public string UVIndexText { get; set; }
        public Visibility Visibility { get; set; }
        public string ObstructionsToVisibility { get; set; }
        public int CloudCover { get; set; }
        public Pressure Pressure { get; set; }
    }

    public class Pressure
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Windgust
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Visibility
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Wind
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Realfeeltemperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Imperial
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial2
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial3
    {
        public float MyProperty { get; set; }
    }

    public class Dewpoint
    {
        public Metric3 Metric { get; set; }
        public Imperial3 Imperial { get; set; }
    }

    public class Metric
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Metric3
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

}
