using System.Net;
using System.Text;
using System.Text.Json;
using IntegrationTests;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tests.TestModels;

namespace Tests;

public class BasicTests : IClassFixture<WeatherApiWebApplicationFactory<Program>>
{
    private readonly WeatherApiWebApplicationFactory<Program> _factory;

    public BasicTests(WeatherApiWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact] // AAA
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        var client = _factory.CreateClient();
        
        
        // Act
        var response = await client.GetAsync("/weatherforecast");

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        var responseString = await response.Content.ReadAsStringAsync();
        
        var data = JsonSerializer.Deserialize<List<WeatherForecastTestModel>>(responseString);
        data[0].TemperatureC.ShouldBeInRange(-20,55);
    }
}