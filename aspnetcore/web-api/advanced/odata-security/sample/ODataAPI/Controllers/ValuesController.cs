using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ODataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        #region snippet_PageSize
        // Enable server-driven paging. Requires using Microsoft.AspNet.OData;
        [EnableQuery(PageSize = 10)]
        #endregion
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /api/values/NewRoute
        #region snippet_large
        // Disable string functions.
        [EnableQuery(AllowedFunctions = AllowedFunctions.AllFunctions &
            ~AllowedFunctions.AllStringFunctions)]
        #endregion
        [HttpGet]
        [Route("NewRoute")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "value3", "value4" };
        }

        // GET api/values/5
        #region snippet_AllowedQueryOptions
        // Allow client paging but no other query options.
        // Requires using Microsoft.AspNet.OData.Query;
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Skip |
                                       AllowedQueryOptions.Top)]
        #endregion
        // Set the allowed $orderby properties.
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        #region snippet_AllowedOrderByProperties
        [EnableQuery(AllowedOrderByProperties = "Id,Name")] // Comma separated list
        #endregion
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        // Set the maximum node count.
        #region snippet_MaxNodeCount
        [EnableQuery(MaxNodeCount = 20)]
        #endregion
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        #region snippet_any
        // Disable any() and all() functions.
        [EnableQuery(AllowedFunctions = AllowedFunctions.AllFunctions &
            ~AllowedFunctions.All & ~AllowedFunctions.Any)]
        #endregion
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
