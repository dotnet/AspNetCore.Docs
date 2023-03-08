using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JSON.Data;
using JSON.Models;

namespace JSON.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherForecastsController : ControllerBase
{
    private readonly AppDbContext _context;

    public WeatherForecastsController(AppDbContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetForecasts() {
        return await _context.Forecasts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(int id) {
        var weatherForecast = await _context.Forecasts.FindAsync(id);

        if (weatherForecast == null) {
            return NotFound();
        }

        return weatherForecast;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWeatherForecast(int id, WeatherForecast weatherForecast) {
        if (id != weatherForecast.Id) {
            return BadRequest();
        }

        _context.Entry(weatherForecast).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
            if (!WeatherForecastExists(id)) {
                return NotFound();
            }
            else {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast) {
        _context.Forecasts.Add(weatherForecast);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWeatherForecast", new { id = weatherForecast.Id }, weatherForecast);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWeatherForecast(int id) {
        var weatherForecast = await _context.Forecasts.FindAsync(id);
        if (weatherForecast == null) {
            return NotFound();
        }

        _context.Forecasts.Remove(weatherForecast);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WeatherForecastExists(int id) {
        return _context.Forecasts.Any(e => e.Id == id);
    }
}
