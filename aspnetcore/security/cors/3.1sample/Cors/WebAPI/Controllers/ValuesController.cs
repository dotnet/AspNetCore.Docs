using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ContentResult Get()
        {
            return Content("GET api/values");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ContentResult Get(int id)
        {
            return Content($"PutTodoItem: ID = {id}");
        }
    }
    #endregion
}
