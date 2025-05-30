using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class DriverController : ControllerBase
{
    private readonly AutoParkContext _context;

    public DriverController(AutoParkContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Drivers.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        return driver == null ? NotFound() : Ok(driver);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = driver.DriverNumber }, driver);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Driver updatedDriver)
    {
        if (id != updatedDriver.DriverNumber) return BadRequest();

        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null) return NotFound();

        driver.PassportSeries = updatedDriver.PassportSeries;
        driver.PassportNumber = updatedDriver.PassportNumber;
        driver.LastName = updatedDriver.LastName;
        driver.FirstName = updatedDriver.FirstName;
        driver.MiddleName = updatedDriver.MiddleName;
        driver.LicenseDate = updatedDriver.LicenseDate;
        driver.LicenseCategory = updatedDriver.LicenseCategory;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null) return NotFound();

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
