using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadSample.Controllers
{
    public class UploadFilesController : Controller
    {
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IEnumerable<IFormFile> files)
        {
            // TODO: Process files
            long size = files.Sum(f => f.Length);

            return Ok(new { count = files.Count(), size});
        }
    }
}
