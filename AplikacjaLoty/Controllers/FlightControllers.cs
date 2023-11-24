using AplikacjaLoty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace FlightInfoAPI.Controllers
{
    // internetowy interfejs API
    [ApiController]
    [Route("api/flights")]

    public class FlightController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory; // można zarejestrować i użyć do konfigurowania i tworzenia HttpClient
        private readonly IConfiguration _configuration;
        public FlightController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights() // obsługuje żądanie HTTP GET 
        {
            var client = _httpClientFactory.CreateClient();
            var apiKey = _configuration["5f86d1a0ee095944273f4b094e5b6665"];
            var apiUrl = $"https://api.aviationstack.com/v1/flights?access_key={apiKey}";

            var response = await client.GetStringAsync(apiUrl); // operacja asynchroniczna
            var flights = JsonSerializer.Deserialize<FlightResponse>(response); // konwersji z formatu JSON do obiektu C#


            foreach (var flight in flights.Results)
            {
                if  (!flight.Live.IsGround)
                {
                    System.Console.WriteLine($" {flight.Flight?.Date} {flight.Airline?.Name} flight {flight.Flight?.Iata} " +
                    $"from {flight.Departure?.Airport} ({flight.Departure?.Iata}) " +
                    $"to {flight.Arrival?.Airport} ({flight.Arrival?.Iata}) is in the air.");
                }
            }

            return Ok();
        }
    }
}
