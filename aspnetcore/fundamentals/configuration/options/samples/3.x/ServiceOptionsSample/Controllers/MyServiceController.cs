using Microsoft.AspNetCore.Mvc;

namespace ServiceOptionsSample.Controllers
{
    [ApiController]
    [Route("api/MyService")]
    public class MyServiceController : ControllerBase
    {
        private readonly IMyService myService;

        public MyServiceController(IMyService myService)
        {
            this.myService = myService;
        }

        [HttpGet]
        public IActionResult GetMyValue() =>
            Ok(new { MyValue = myService.GetMyValue() });
    }
}
