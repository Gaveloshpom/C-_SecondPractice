using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class DepartureController : ControllerBase
{
    private readonly AutoParkContext _context;

    public DepartureController(AutoParkContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Departures.ToListAsync());
    }

    [HttpGet("{date}/{driverId}/{carNumber}")]
    public async Task<IActionResult> Get(DateTime date, int driverId, string carNumber)
    {
        var departure = await _context.Departures.FindAsync(date, driverId, carNumber);
        return departure == null ? NotFound() : Ok(departure);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Departure departure)
    {
        _context.Departures.Add(departure);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { date = departure.DepartureDate, driverId = departure.DriverNumber, carNumber = departure.CarNumber }, departure);
    }

    [HttpPut("{date}/{driverId}/{carNumber}")]
    public async Task<IActionResult> Update(DateTime date, int driverId, string carNumber, [FromBody] Departure updatedDeparture)
    {
        if (date != updatedDeparture.DepartureDate || driverId != updatedDeparture.DriverNumber || carNumber != updatedDeparture.CarNumber)
            return BadRequest();

        var departure = await _context.Departures.FindAsync(date, driverId, carNumber);
        if (departure == null) return NotFound();

        departure.Distance = updatedDeparture.Distance;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{date}/{driverId}/{carNumber}")]
    public async Task<IActionResult> Delete(DateTime date, int driverId, string carNumber)
    {
        var departure = await _context.Departures.FindAsync(date, driverId, carNumber);
        if (departure == null) return NotFound();

        _context.Departures.Remove(departure);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
