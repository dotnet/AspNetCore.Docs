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
                // Validate if the request has a body
                if (!Request.HasFormContentType)
                {
                    return BadRequest("The request does not contain a valid form.");
                }

                var bodyReader = Request.BodyReader;

                // Initialize streaming variables
                long totalBytesRead = 0;
                const int bufferSize = 16 * 1024; // 16 KB buffer size

                while (true)
                {
                    // Read from the body in chunks
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
