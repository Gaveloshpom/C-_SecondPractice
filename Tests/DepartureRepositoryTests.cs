using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class DepartureRepositoryTests
{
    private AutoParkContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AutoParkContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new AutoParkContext(options);
        SeedData.Initialize(context);
        return context;
    }

    [Fact]
    public void AddDeparture_ShouldIncreaseCount()
    {
        using var context = GetInMemoryContext();
        var repo = new DepartureRepository(context);
        repo.Add(new Departure
        {
            DepartureDate = DateTime.Today,
            DriverNumber = 1,
            CarNumber = "CC9012DE",
            Distance = 75
        });
        Assert.Equal(3, context.Departures.Count());
    }

    [Fact]
    public void GetByKey_ShouldReturnCorrectDeparture()
    {
        using var context = GetInMemoryContext();
        var repo = new DepartureRepository(context);
        var dep = repo.GetByKey(DateTime.Today, 1, "AA1234BC");
        Assert.NotNull(dep);
        Assert.Equal(120, dep.Distance);
    }

    [Fact]
    public void DeleteDeparture_ShouldRemove()
    {
        using var context = GetInMemoryContext();
        var repo = new DepartureRepository(context);
        repo.Delete(DateTime.Today, 1, "AA1234BC");
        Assert.Null(context.Departures.FirstOrDefault(d => d.DriverNumber == 1 && d.CarNumber == "AA1234BC"));
    }
}
