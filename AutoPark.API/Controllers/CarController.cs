using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly AutoParkContext _context;

    public CarController(AutoParkContext context)
    {
        _context = context;
        _context.Drivers.Include(d => d.Departures);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _context.Cars
    .Include(c => c.Departures)
    .ToListAsync();

        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var car = await _context.Cars
            .Include(c => c.Departures)
            .FirstOrDefaultAsync(c => c.CarNumber == id);

        return car == null ? NotFound() : Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = car.CarNumber }, car);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Car updatedCar)
    {
        if (id != updatedCar.CarNumber) return BadRequest();

        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();

        car.Brand = updatedCar.Brand;
        car.CarType = updatedCar.CarType;
        car.ReleaseYearMonth = updatedCar.ReleaseYearMonth;
        car.EnginePower = updatedCar.EnginePower;
        car.FuelConsumption = updatedCar.FuelConsumption;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
