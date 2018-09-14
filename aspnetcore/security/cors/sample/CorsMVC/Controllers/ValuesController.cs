using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace CorsMVC.Controllers
{
    #region EnableOnController
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class ValuesController : Controller
#endregion
    {
        // GET api/values
        #region EnableOnAction
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        #endregion

        // GET api/values/5
        #region DisableOnAction
        [HttpGet("{id}")]
        [DisableCors]
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
