using Microsoft.AspNetCore.Mvc;

namespace FileManagerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private const string UploadFilePath = "file-upload.dat";
        // private const string OriginalFilePath = "/* replace with your file path */";
        private const string OriginalFilePath = @"D:\.other\big-files\bigfile.dat";

        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(Compare))]
        public IActionResult Compare()
        {
            try
            {
                string targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), UploadFilePath);
                if (!System.IO.File.Exists(targetFilePath))
                {
                    return NotFound($"File not found: {targetFilePath}");
                }
                if (!System.IO.File.Exists(OriginalFilePath))
                {
                    return NotFound($"File not found: {OriginalFilePath}");
                }

                bool areFilesEqual = CompareFiles(targetFilePath, OriginalFilePath);
                if (areFilesEqual)
                {
                    return Ok(new { Message = "The files are identical." });
                }
                else
                {
                    return Ok(new { Message = "The files are different." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during file comparison");
                return StatusCode(500, "An error occurred while comparing the files.");
            }
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

                string targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), UploadFilePath);
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
                    var buffer = readResult.Buffer;

                    foreach (var memory in buffer)
                    {
                        await outputFileStream.WriteAsync(memory, default);
                        totalBytesRead += memory.Length;
                    }

                    bodyReader.AdvanceTo(buffer.End);
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

        private bool CompareFiles(string filePath1, string filePath2)
        {
            var fileInfo1 = new FileInfo(filePath1);
            var fileInfo2 = new FileInfo(filePath2);

            if (fileInfo1.Length != fileInfo2.Length)
            {
                return false;
            }

            using (FileStream fs1 = System.IO.File.OpenRead(filePath1))
            using (FileStream fs2 = System.IO.File.OpenRead(filePath2))
            {
                byte[] buffer1 = new byte[8192]; // 8 KB buffer
                byte[] buffer2 = new byte[8192];
                int bytesRead1, bytesRead2;

                do
                {
                    bytesRead1 = fs1.Read(buffer1, 0, buffer1.Length);
                    bytesRead2 = fs2.Read(buffer2, 0, buffer2.Length);

                    if (bytesRead1 != bytesRead2 || !buffer1.SequenceEqual(buffer2))
                    {
                        return false;
                    }
                } while (bytesRead1 > 0 && bytesRead2 > 0);
            }

            return true;
        }
    }
}
