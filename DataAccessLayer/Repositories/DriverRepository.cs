using System.Collections.Generic;
using System.Linq;

public class DriverRepository
{
    private readonly AutoParkContext _context;

    public DriverRepository(AutoParkContext context)
    {
        _context = context;
    }

    public List<Driver> GetAll()
    {
        return _context.Drivers.ToList();
    }

    public Driver GetById(int driverNumber)
    {
        return _context.Drivers.FirstOrDefault(d => d.DriverNumber == driverNumber);
    }

    public void Add(Driver driver)
    {
        _context.Drivers.Add(driver);
        _context.SaveChanges();
    }

    public void Update(Driver updatedDriver)
    {
        var driver = _context.Drivers.FirstOrDefault(d => d.DriverNumber == updatedDriver.DriverNumber);
        if (driver != null)
        {
            driver.PassportSeries = updatedDriver.PassportSeries;
            driver.PassportNumber = updatedDriver.PassportNumber;
            driver.LastName = updatedDriver.LastName;
            driver.FirstName = updatedDriver.FirstName;
            driver.MiddleName = updatedDriver.MiddleName;
            driver.LicenseDate = updatedDriver.LicenseDate;
            driver.LicenseCategory = updatedDriver.LicenseCategory;

            _context.SaveChanges();
        }
    }

    public void Delete(int driverNumber)
    {
        var driver = _context.Drivers.FirstOrDefault(d => d.DriverNumber == driverNumber);
        if (driver != null)
        {
            _context.Drivers.Remove(driver);
            _context.SaveChanges();
        }
    }
}
