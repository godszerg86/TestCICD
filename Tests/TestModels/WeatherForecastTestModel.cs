using System.Text.Json.Serialization;

namespace Tests.TestModels;

public class WeatherForecastTestModel
{
    [JsonPropertyName("date")]
    public DateOnly Date { get; set; }
    [JsonPropertyName("temperatureC")]
    public int TemperatureC { get; set; }
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }
    [JsonPropertyName("temperatureF")]
    public int TemperatureF { get; set; }
}