using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class CarRepositoryTests
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
    public void AddCar_ShouldIncreaseCount()
    {
        using var context = GetInMemoryContext();
        var repo = new CarRepository(context);
        repo.Add(new Car
        {
            CarNumber = "DD0000DD",
            Brand = "Honda",
            CarType = "легковий",
            ReleaseYearMonth = new DateTime(2020, 3, 1),
            EnginePower = 110,
            FuelConsumption = 5.9M
        });
        Assert.Equal(4, context.Cars.Count());
    }

    [Fact]
    public void GetById_ShouldReturnCorrectCar()
    {
        using var context = GetInMemoryContext();
        var repo = new CarRepository(context);
        var car = repo.GetById("AA1234BC");
        Assert.NotNull(car);
        Assert.Equal("Toyota", car.Brand);
    }

    [Fact]
    public void DeleteCar_ShouldRemove()
    {
        using var context = GetInMemoryContext();
        var repo = new CarRepository(context);
        repo.Delete("AA1234BC");
        Assert.Null(context.Cars.FirstOrDefault(c => c.CarNumber == "AA1234BC"));
    }
}
