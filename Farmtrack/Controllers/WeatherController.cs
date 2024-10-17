using Microsoft.AspNetCore.Mvc;

public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IActionResult> Index()
    {
        var latitude = "59.3293"; // Exempel: latitud för Stockholm
        var longitude = "18.0686"; // Exempel: longitud för Stockholm
        var weatherData = await _weatherService.GetWeatherDataAsync(latitude, longitude);

        return View(weatherData);
    }
}