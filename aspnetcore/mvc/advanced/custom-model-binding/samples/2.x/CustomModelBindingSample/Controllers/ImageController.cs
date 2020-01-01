using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CustomModelBindingSample.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly string _targetFilePath;

        public ImageController(IConfiguration config)
        {
            _targetFilePath = config["StoredFilesPath"];
        }

        #region post1
        [HttpPost]
        public void Post([FromForm] byte[] file, string filename)
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
        public void SaveProfile([FromForm] ProfileViewModel model)
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
