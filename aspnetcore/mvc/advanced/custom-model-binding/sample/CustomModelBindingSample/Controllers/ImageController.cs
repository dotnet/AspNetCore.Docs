using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CustomModelBindingSample.Controllers
{

    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly string _targetFilePath;

        public ImageController(IHostingEnvironment env, IConfiguration config)
        {
            _env = env;
            _targetFilePath = config.GetValue<string>("StoredFilesPath");
        }

        #region post1
        // POST: api/image
        [HttpPost]
        public void Post(byte[] file, string filename)
        {
            // Don't trust the file name sent by the client. Use
            // Path.GetRandomFileName to generate a safe random
            // file name. _targetFilePath receives a value
            // from configuration (the appsettings.json file in
            // the sample app).
            var trustedFileName = Path.GetRandomFileName();
            var filePath = Path.Combine(_targetFilePath, trustedFileName);

            if (System.IO.File.Exists(filePath))
            {
                return;
            }

            System.IO.File.WriteAllBytes(filePath, file);
        }
        #endregion

        #region post2
        [HttpPost("Profile")]
        public void SaveProfile(ProfileViewModel model)
        {
            // Don't trust the file name sent by the client. Use
            // Path.GetRandomFileName to generate a safe random
            // file name. _targetFilePath receives a value
            // from configuration (the appsettings.json file in
            // the sample app).
            var trustedFileName = Path.GetRandomFileName();
            var filePath = Path.Combine(_targetFilePath, trustedFileName);
            
            if (System.IO.File.Exists(filePath))
            {
                return;
            }

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
