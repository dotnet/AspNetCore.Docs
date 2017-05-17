using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace CorsMVC.Controllers
{
    #region EnableOnController
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
#endregion
    {
        // GET api/values
        #region EnableOnAction
        [EnableCors("AllowSpecificOrigin")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        #endregion

        // GET api/values/5
        #region DisableOnAction
        [DisableCors]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
#endregion

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
