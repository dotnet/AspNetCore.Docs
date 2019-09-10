using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ResponseFormattingSample.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Route("[controller]/[action]/{id}.{format?}")]
        public Product GetById(int id)
        {
            #endregion

            return new Product();
        }
    }

    public class Product
    {
    }
}
