using FileManagerSample.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace FileManagerSample.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FileController : ControllerBase
    {
        public const int BufferSize = 16 * 1024 * 1024; // 16 MB buffer size
        public const string UploadFilePath = "file-upload.dat";

        private readonly ILogger<FileController> _logger;
        private readonly FileManagerService _fileManager;

        public FileController(
            ILogger<FileController> logger,
            FileManagerService fileManager)
        {
            _logger = logger;
            _fileManager = fileManager;
        }

        [HttpPost]
        [Route("multipart")]
        public async Task<IActionResult> UploadMultipartReader()
        {
            if (!Request.ContentType?.StartsWith("multipart/form-data") ?? true)
            {
                return BadRequest("The request does not contain valid multipart form data.");
            }

            var boundary = HeaderUtilities.RemoveQuotes(MediaTypeHeaderValue.Parse(Request.ContentType).Boundary).Value;
            if (string.IsNullOrWhiteSpace(boundary))
            {
                return BadRequest("Missing boundary in multipart form data.");
            }

            var cancellationToken = HttpContext.RequestAborted;
            var filePath = await _fileManager.SaveViaMultipartReaderAsync(boundary, Request.Body, cancellationToken);
            return Ok("Saved file at " + filePath);
        }

        [HttpPost]
        [Route("pipe")]
        public async Task<IActionResult> UploadPipeReader()
        {
            if (!Request.HasFormContentType)
            {
                return BadRequest("The request does not contain a valid form.");
            }

            var cancellationToken = HttpContext.RequestAborted;
            var filePath = await _fileManager.SaveViaPipeReaderAsync(Request.BodyReader, cancellationToken);
            return Ok("Saved file at " + filePath);
        }

        [HttpPost]
        [Route("form")]
        public async Task<IActionResult> ReadForms()
        {
            if (!Request.HasFormContentType)
            {
                return BadRequest("The request does not contain a valid form.");
            }

            var cancellationToken = HttpContext.RequestAborted;
            var formFeature = Request.HttpContext.Features.GetRequiredFeature<IFormFeature>();
            await formFeature.ReadFormAsync(cancellationToken);

            var filePath = Request.Form.Files.First().FileName;
            return Ok("Saved file at " + filePath);
        }
    }
}
