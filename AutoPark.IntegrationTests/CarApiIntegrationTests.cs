using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

public class CarApiIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CarApiIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostCar_ShouldReturnCreated()
    {
        var car = new
        {
            carNumber = "ZX9876YU",
            brand = "Ford",
            carType = "легковий",
            releaseYearMonth = "2022-04-01T00:00:00",
            enginePower = 150,
            fuelConsumption = 7.2
        };

        var response = await _client.PostAsJsonAsync("/api/car", car);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var created = await response.Content.ReadFromJsonAsync<Car>();
        Assert.Equal("ZX9876YU", created.CarNumber);
    }

    [Fact]
    public async Task GetAllCars_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("/api/car");
        response.EnsureSuccessStatusCode();

        var cars = await response.Content.ReadFromJsonAsync<List<Car>>();
        Assert.NotNull(cars);
    }
}
