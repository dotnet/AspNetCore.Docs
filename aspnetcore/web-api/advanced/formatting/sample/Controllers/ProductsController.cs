using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ResponseFormattingSample.Controllers
{
    #region snippet
    [Route("api/[controller]/[action]")]
    [ApiController]
    [FormatFilter]
    public class ProductsController : ControllerBase
    {
        [Route("{id}.{format?}")]
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
