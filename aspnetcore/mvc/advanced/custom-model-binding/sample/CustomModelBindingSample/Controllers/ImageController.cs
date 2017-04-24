using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CustomModelBindingSample.Controllers
{

    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment _env;
        public ImageController(IHostingEnvironment env)
        {
            _env = env;
        }

        // POST: api/image
        [HttpPost]
        public void Post([ModelBinder(BinderType = typeof(ByteArrayModelBinder))]byte[] file, string filename)
        {
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot/images/upload", filename);
            if (System.IO.File.Exists(filePath)) return;
            System.IO.File.WriteAllBytes(filePath, file);
        }
    }
}
