using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("day")]
    public ActionResult<DayOfTheWeekAsString> GetDay()
    {
        return DayOfTheWeekAsString.Wednesday;
    }

    [HttpPost("day")]
    public IActionResult PostDay(DayOfTheWeekAsString day)
    {
        return Ok($"Received: {day}");
    }
}
