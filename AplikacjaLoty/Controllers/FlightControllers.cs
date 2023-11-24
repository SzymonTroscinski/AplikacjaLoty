using AplikacjaLoty.Models;
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
            var apiKey = _configuration["AviationStackApiKey"];
            var apiUrl = $"https://api.aviationstack.com/v1/flights?access_key={apiKey}";

            var response = await client.GetStringAsync(apiUrl); // operacja asynchroniczna
            var flights = JsonSerializer.Deserialize<FlightResponse>(response);

            foreach (var flight in flights.Results)
            {
                if  (!flight.Live.IsGround)
                {
                    System.Console.WriteLine($" {flight.Flight?.Date} {flight.Airline?.Name} flight {flight.Flight?.Iata} " +
                    $"from {flight.Departure?.Airport} ({flight.Departure?.Iata}) " +
                    $"to {flight.Arrival?.Airport} ({flight.Arrival?.Iata}) is in the air.");
                }
            }

            return Ok(flights.Results.Where(flight => !flight.Live.IsGround));
        }
    }
}
