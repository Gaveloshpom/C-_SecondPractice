using System;
using System.Collections.Generic;
using System.Linq;

public class DepartureRepository
{
    private readonly AutoParkContext _context;

    public DepartureRepository(AutoParkContext context)
    {
        _context = context;
    }

    public List<Departure> GetAll()
    {
        return _context.Departures.ToList();
    }

    public Departure GetByKey(DateTime date, int driverNumber, string carNumber)
    {
        return _context.Departures.FirstOrDefault(d =>
            d.DepartureDate == date &&
            d.DriverNumber == driverNumber &&
            d.CarNumber == carNumber);
    }

    public void Add(Departure departure)
    {
        _context.Departures.Add(departure);
        _context.SaveChanges();
    }

    public void Update(Departure updatedDeparture)
    {
        var departure = GetByKey(updatedDeparture.DepartureDate, updatedDeparture.DriverNumber, updatedDeparture.CarNumber);
        if (departure != null)
        {
            departure.Distance = updatedDeparture.Distance;
            _context.SaveChanges();
        }
    }

    public void Delete(DateTime date, int driverNumber, string carNumber)
    {
        var departure = GetByKey(date, driverNumber, carNumber);
        if (departure != null)
        {
            _context.Departures.Remove(departure);
            _context.SaveChanges();
        }
    }
}
