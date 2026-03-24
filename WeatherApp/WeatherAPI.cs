using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
public class WeatherAPI
{
    private readonly HttpClient _httpClient;

    private readonly string _apiKey;

    private const string BaseUrl = "https://weather.googleapis.com/v1";

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public WeatherAPI(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
    }

    public async Task<float?> GetCurrentTemperature(double latitude, double longitude)
    {
        var url = $"{BaseUrl}/currentConditions:lookup?key={_apiKey}&location.latitude={latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}&location.longitude={longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
        
  
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var doc = JsonDocument.Parse(json);

        Console.WriteLine(json);

        return doc.RootElement
            .GetProperty("temperature")
            .GetProperty("degrees")
            .GetSingle();
    }

}