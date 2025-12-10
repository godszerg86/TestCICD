using IntegrationTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace Tests;

public class WeatherApiWebApplicationFactory<T>
    : WebApplicationFactory<T> 
    where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<ICacheService>();
            
            var moqCache = new Mock<ICacheService>();
            moqCache.Setup(x => x.SetCache(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(500);
            
            services.TryAddSingleton(moqCache.Object);
        });

        builder.UseEnvironment("Test");
        
        builder.ConfigureAppConfiguration((context, config) =>
        {
            // Clear existing configuration sources if you want to completely replace them
            // config.Sources.Clear();

            // Add your custom appsettings.json file
            // config.AddJsonFile("appsettings.test.json", optional: true, reloadOnChange: true);

            // Alternatively, add in-memory configuration for specific settings
            var inMemorySettings = new Dictionary<string, string>
            {
                { "ConnectionStrings:DefaultConnection", "Server=test_server;Database=test_db;" },
            };
            config.AddInMemoryCollection(inMemorySettings);
        });
    }
}