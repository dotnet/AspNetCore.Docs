using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using System;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger _logger;

        public TestController(  ILogger<TodoItemsController> logger)
        {
            _logger = logger;
        }

        #region snippet_Exp
        [HttpGet("{id}")]
        public IActionResult TestExp(int id)
        {
            var routeInfo = ControllerContext.ToCtxString(id);
            _logger.LogInformation(MyLogEvents.TestItem, routeInfo);

            try
            {
                if (id == 3)
                {
                    throw new Exception("Test expception");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(MyLogEvents.GetItemNotFound, ex, "TestExp({Id})", id);
                return NotFound();
            }

            return ControllerContext.MyDisplayRouteInfo();
        }
        #endregion
    }
}
