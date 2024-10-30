using Farmtrack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;
    private readonly NotificationService _notificationService;

    public WeatherController(WeatherService weatherService, NotificationService notificationService)
    {
        _weatherService = weatherService;
        _notificationService = notificationService;
    }

    public async Task<IActionResult> Index()
    {
        var latitude = "59.3293";
        var longitude = "18.0686";

        try
        {
            var weatherData = await _weatherService.GetWeatherDataAsync(latitude, longitude);

            if (weatherData == null)
            {
                
                _notificationService.SetNotification("Could not retrieve weather data. Please try again later.", "error");
            }

            
            ViewData["NotificationService"] = _notificationService;
            return View(weatherData);
        }
        catch (Exception ex)
        {
            
            _notificationService.SetNotification($"An error occurred: {ex.Message}", "error");
            ViewData["NotificationService"] = _notificationService;
            return View(null);
        }
    }
}