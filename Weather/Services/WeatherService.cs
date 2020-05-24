using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using static Weather.Weather;

namespace Weather
{
    public class WeatherService : WeatherBase
    {
        private IMemoryCache _cache; // we have memory cache, becasue we want to get data out form the memory
        private readonly ILogger<WeatherService> _logger;
        public WeatherService(ILogger<WeatherService> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public override Task<WeatherResponse> GetWeather(Empty request, ServerCallContext context)
        {
            return Task.FromResult(GetCurrentWeatherResponse(_cache.Get<Forecast>("WeatherCache")));
        }

        public override async Task GetWeatherStream(Empty request, IServerStreamWriter<WeatherResponse> responseStream, ServerCallContext context)
        {
            // it just loops as long as the person is connected
            // it grabs the data out whatever is in the cache currently
            // and then loops
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var cachedForecast = _cache.Get<Forecast>("WeatherCache");
                await responseStream.WriteAsync(GetCurrentWeatherResponse(cachedForecast));
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }

        public static WeatherResponse GetCurrentWeatherResponse(Forecast forecast)
        {
            return new WeatherResponse()
            {
                // convert the data from api to the data that we want to share to client
                WeatherText = forecast.WeatherText,
                IsDayTime = forecast.IsDayTime,
                Pressure = forecast.Pressure.Imperial.Value,
                RelativeHumidity = forecast.RelativeHumidity,
                RetrievedTime = Timestamp.FromDateTime(DateTime.UtcNow),
                Temperature = forecast.Temperature.Imperial.Value,
                UVIndex = forecast.UVIndex,
                WeatherIcon = forecast.weatherIcon,
                WeatherUri = $"https://developer.accuweather.com/sites/default/fi"
            };
        }
    }
}
