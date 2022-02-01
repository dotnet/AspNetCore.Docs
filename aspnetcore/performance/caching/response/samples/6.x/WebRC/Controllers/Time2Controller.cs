using Microsoft.AspNetCore.Mvc;

namespace WebRC.Controllers
{
    #region snippet
    [ApiController]
    [ResponseCache(CacheProfileName = "Default30")]
    public class Time2Controller : ControllerBase
    {
        [Route("api/[controller]")]
        [HttpGet]
        public ContentResult GetTime() => Content(
                          DateTime.Now.Millisecond.ToString());

        [Route("api/[controller]/ticks")]
        [HttpGet]
        public ContentResult GetTimeTicks() => Content(
                          DateTime.Now.Ticks.ToString());
    }
    #endregion
}
