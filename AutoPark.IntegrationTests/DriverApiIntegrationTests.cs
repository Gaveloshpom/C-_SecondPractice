using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

public class DriverApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public DriverApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostDriver_ShouldReturnCreated()
    {
        var driver = new
        {
            passportSeries = "АА",
            passportNumber = 11112222,
            lastName = "Собко",
            firstName = "Іван",
            middleName = "Олегович",
            licenseDate = "2018-01-15T00:00:00",
            licenseCategory = "B"
        };

        var response = await _client.PostAsJsonAsync("/api/driver", driver);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var created = await response.Content.ReadFromJsonAsync<Driver>();
        Assert.Equal("Собко", created.LastName);
    }

    [Fact]
    public async Task GetAllDrivers_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("/api/driver");
        response.EnsureSuccessStatusCode();

        var drivers = await response.Content.ReadFromJsonAsync<List<Driver>>();
        Assert.NotNull(drivers);
    }
}
