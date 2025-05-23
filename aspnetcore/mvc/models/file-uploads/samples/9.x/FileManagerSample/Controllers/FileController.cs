using Microsoft.AspNetCore.Mvc;

namespace FileManagerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Upload))]
        public async Task<IActionResult> Upload()
        {
            try
            {
                if (!Request.HasFormContentType)
                {
                    return BadRequest("The request does not contain a valid form.");
                }
                _ = Request.Headers.TryGetValue("Content-Type", out var contentType);
                _logger.LogInformation("Content-Type: {ContentType}", contentType!);

                var bodyReader = Request.BodyReader;

                long totalBytesRead = 0;
                const int bufferSize = 16 * 1024 * 1024; // 16 MB buffer size

                string targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "file-upload.dat");
                if (System.IO.File.Exists(targetFilePath))
                {
                    System.IO.File.Delete(targetFilePath);
                    _logger.LogDebug("Removed existing output file: {path}", targetFilePath);
                }

                using FileStream outputFileStream = new FileStream(
                    path: targetFilePath,
                    mode: FileMode.OpenOrCreate,
                    access: FileAccess.Write,
                    share: FileShare.ReadWrite,
                    bufferSize: bufferSize,
                    useAsync: true);

                while (true)
                {
                    var readResult = await bodyReader.ReadAsync();

                    // Get the buffer containing the data
                    var buffer = readResult.Buffer;

                    // Process the buffer data (streaming logic here)
                    foreach (var memory in buffer)
                    {
                        // Add your custom logic here for processing the streamed data
                        totalBytesRead += memory.Length;
                    }

                    // Mark the buffer as processed
                    bodyReader.AdvanceTo(buffer.End);

                    // Break the loop if there's no more data to read
                    if (readResult.IsCompleted)
                    {
                        break;
                    }
                }

                _logger.LogInformation("File upload completed. Total bytes read: {TotalBytesRead} bytes.", totalBytesRead);
                return Ok(new { Message = "File uploaded successfully.", BytesProcessed = totalBytesRead });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during file upload");
                return StatusCode(500, "An error occurred while uploading the file.");
            }
        }
    }
}
