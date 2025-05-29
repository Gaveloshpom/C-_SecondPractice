using System.Collections.Generic;
using System.Linq;

public class CarRepository
{
    private readonly AutoParkContext _context;

    public CarRepository(AutoParkContext context)
    {
        _context = context;
    }

    public List<Car> GetAll()
    {
        return _context.Cars.ToList();
    }

    public Car GetById(string carNumber)
    {
        return _context.Cars.FirstOrDefault(c => c.CarNumber == carNumber);
    }

    public void Add(Car car)
    {
        _context.Cars.Add(car);
        _context.SaveChanges();
    }

    public void Update(Car updatedCar)
    {
        var car = _context.Cars.FirstOrDefault(c => c.CarNumber == updatedCar.CarNumber);
        if (car != null)
        {
            car.Brand = updatedCar.Brand;
            car.CarType = updatedCar.CarType;
            car.ReleaseYearMonth = updatedCar.ReleaseYearMonth;
            car.EnginePower = updatedCar.EnginePower;
            car.FuelConsumption = updatedCar.FuelConsumption;

            _context.SaveChanges();
        }
    }

    public void Delete(string carNumber)
    {
        var car = _context.Cars.FirstOrDefault(c => c.CarNumber == carNumber);
        if (car != null)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}

