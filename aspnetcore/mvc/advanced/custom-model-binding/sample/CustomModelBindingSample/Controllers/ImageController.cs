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

        #region post1
        // POST: api/image
        [HttpPost]
        public void Post(byte[] file, string filename)
        {
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot/images/upload", filename);
            if (System.IO.File.Exists(filePath)) return;
            System.IO.File.WriteAllBytes(filePath, file);
        }
        #endregion

        #region post2
        [HttpPost("Profile")]
        public void SaveProfile(ProfileViewModel model)
        {
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot/images/upload", model.FileName);
            if (System.IO.File.Exists(model.FileName)) return;
            System.IO.File.WriteAllBytes(filePath, model.File);
        }

        public class ProfileViewModel
        {
            public byte[] File { get; set; }
            public string FileName { get; set; }
        }
        #endregion
    }
}
