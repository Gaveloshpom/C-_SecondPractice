using System;
using System.Collections.Generic;

public static class SeedData
{
    public static void Initialize(AutoParkContext context)
    {
        if (context.Cars.Any() || context.Drivers.Any() || context.Departures.Any())
            return; 

        var cars = new List<Car>
        {
            new Car { CarNumber = "AA1234BC", Brand = "Toyota", CarType = "легковий", ReleaseYearMonth = new DateTime(2018, 5, 1), EnginePower = 120, FuelConsumption = 6.5M },
            new Car { CarNumber = "BB5678CK", Brand = "MAN", CarType = "вантажний", ReleaseYearMonth = new DateTime(2016, 7, 1), EnginePower = 280, FuelConsumption = 22.0M },
            new Car { CarNumber = "CC9012DE", Brand = "Ikarus", CarType = "автобус", ReleaseYearMonth = new DateTime(2015, 10, 1), EnginePower = 190, FuelConsumption = 30.5M }
        };
        context.Cars.AddRange(cars);

        var drivers = new List<Driver>
        {
            new Driver { PassportSeries = "КВ", PassportNumber = 12345678, LastName = "Іваненко", FirstName = "Олег", MiddleName = "Васильович", LicenseDate = new DateTime(2012, 4, 1), LicenseCategory = "B" },
            new Driver { PassportSeries = "КС", PassportNumber = 87654321, LastName = "Петренко", FirstName = "Ірина", MiddleName = "Миколаївна", LicenseDate = new DateTime(2015, 9, 1), LicenseCategory = "C" }
        };
        context.Drivers.AddRange(drivers);

        var departures = new List<Departure>
        {
            new Departure { DepartureDate = DateTime.Today, DriverNumber = 1, CarNumber = "AA1234BC", Distance = 120 },
            new Departure { DepartureDate = DateTime.Today, DriverNumber = 2, CarNumber = "BB5678CK", Distance = 300 }
        };
        context.Departures.AddRange(departures);

        context.SaveChanges();
    }
}
