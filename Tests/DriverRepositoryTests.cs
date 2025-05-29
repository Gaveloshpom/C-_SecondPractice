using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class DriverRepositoryTests
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
    public void AddDriver_ShouldIncreaseCount()
    {
        using var context = GetInMemoryContext();
        var repo = new DriverRepository(context);
        repo.Add(new Driver
        {
            PassportSeries = "КГ",
            PassportNumber = 55555555,
            LastName = "Сидоренко",
            FirstName = "Андрій",
            MiddleName = "Петрович",
            LicenseDate = new DateTime(2018, 5, 1),
            LicenseCategory = "B"
        });
        Assert.Equal(3, context.Drivers.Count());
    }

    [Fact]
    public void GetById_ShouldReturnCorrectDriver()
    {
        using var context = GetInMemoryContext();
        var repo = new DriverRepository(context);
        var driver = repo.GetById(1);
        Assert.NotNull(driver);
        Assert.Equal("Іваненко", driver.LastName);
    }

    [Fact]
    public void DeleteDriver_ShouldRemove()
    {
        using var context = GetInMemoryContext();
        var repo = new DriverRepository(context);
        repo.Delete(1);
        Assert.Null(context.Drivers.FirstOrDefault(d => d.DriverNumber == 1));
    }
}
