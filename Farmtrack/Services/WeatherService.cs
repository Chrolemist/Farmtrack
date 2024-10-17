using System.Text.Json;
using Farmtrack.Models;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<WeatherData> GetWeatherDataAsync(string latitude, string longitude)
    {
        var url = $"https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/{longitude}/lat/{latitude}/data.json";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
            {
                var root = doc.RootElement;
                var timeSeries = root.GetProperty("timeSeries")[0]; // Hämta första tidseriedatan
                var validTime = timeSeries.GetProperty("validTime").GetDateTime();

                double temperature = 0;
                double cloudCover = 0;
                double rain = 0;

                foreach (var parameter in timeSeries.GetProperty("parameters").EnumerateArray())
                {
                    if (parameter.GetProperty("name").GetString() == "t")
                    {
                        temperature = parameter.GetProperty("values")[0].GetDouble();
                    }
                    if (parameter.GetProperty("name").GetString() == "tcc_mean")
                    {
                        cloudCover = parameter.GetProperty("values")[0].GetDouble();
                    }
                    if (parameter.GetProperty("name").GetString() == "pmean")
                    {
                        rain = parameter.GetProperty("values")[0].GetDouble();
                    }
                }

                return new WeatherData
                {
                    ValidTime = validTime,
                    Temperature = temperature,
                    CloudCover = cloudCover,
                    Rain = rain
                };
            }
        }
        return null;
    }
}