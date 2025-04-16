using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public WeatherService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiKey = configuration["WeatherAPIKey"] ?? throw new ArgumentNullException("WeatherAPIKey not found in configuration.");
    }

    public async Task<JObject> GetWeatherAsync(string city)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
        string response = await _httpClient.GetStringAsync(url);
        return JObject.Parse(response);
    }
}
