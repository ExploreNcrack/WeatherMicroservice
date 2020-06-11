using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using static Weather.Weather;

namespace WeatherConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001/");

            var client = new WeatherClient(channel);


            var response = client.GetWeatherStream(new Empty());
            var forecasts = response.ResponseStream.ReadAllAsync();  // support in C# 8.0
            await foreach(var forecast2 in forecasts) // use await foreach when you have IAsyncEnumerable
            {
                Console.WriteLine($"{forecast2.Temperature}");
            }

            var forecast = await client.GetWeatherAsync(new Empty());
            Console.WriteLine($"{forecast.Temperature}");

            Console.WriteLine("none");
            Console.ReadLine();
        }
    }
}
