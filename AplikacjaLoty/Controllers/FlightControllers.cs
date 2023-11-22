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

        public FlightController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights() // obsługuje żądanie HTTP GET 
        {
            var client = _httpClientFactory.CreateClient();
            var apiKey = "1b512bb2757662df7d3396419f6e1d6c";
            var apiUrl = $"https://api.aviationstack.com/v1/flights?access_key={apiKey}";

            var response = await client.GetStringAsync(apiUrl); // operacja asynchroniczna
            var flights = JsonSerializer.Deserialize<FlightModel>(response); // konwersji z formatu JSON do obiektu C#

            { 
            //Kod którego nie potrafię
            }

            return Ok();
        }
    }
}
