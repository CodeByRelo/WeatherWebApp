using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    // GET: Weather
    public IActionResult Index()
    {
        return View();
    }

    // POST: Weather/GetWeather
    [HttpPost]
    public async Task<IActionResult> GetWeather(string city)
    {
        var weatherData = await _weatherService.GetWeatherAsync(city);
        return View("Index", weatherData);
    }
}
