using Google.Protobuf.WellKnownTypes;
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

            var forecast = await client.GetWeatherAsync(new Empty());

            Console.WriteLine($"{forecast.Temperature}");

            Console.WriteLine("none");
            Console.ReadLine();
        }
    }
}
