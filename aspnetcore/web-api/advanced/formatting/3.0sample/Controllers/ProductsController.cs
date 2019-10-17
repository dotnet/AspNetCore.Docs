using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ResponseFormattingSample.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    [FormatFilter]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}.{format?}")]
        public Product Get(int id)
        {
            #endregion

            return new Product();
        }
    }

    public class Product
    {
    }
}
