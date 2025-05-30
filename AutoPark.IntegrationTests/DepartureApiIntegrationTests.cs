using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

public class DepartureApiIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public DepartureApiIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostDeparture_ShouldReturnCreated()
    {
        var departure = new
        {
            departureDate = DateTime.Today.ToString("yyyy-MM-dd"),
            driverNumber = 1,
            carNumber = "AA1234BC",
            distance = 120
        };

        var response = await _client.PostAsJsonAsync("/api/departure", departure);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var created = await response.Content.ReadFromJsonAsync<Departure>();
        Assert.Equal(120, created.Distance);
    }

    [Fact]
    public async Task GetAllDepartures_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("/api/departure");
        response.EnsureSuccessStatusCode();

        var departures = await response.Content.ReadFromJsonAsync<List<Departure>>();
        Assert.NotNull(departures);
    }
}
