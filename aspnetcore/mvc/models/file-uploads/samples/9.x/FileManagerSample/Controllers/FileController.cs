using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace FileManagerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        public const int BufferSize = 16 * 1024 * 1024; // 16 MB buffer size
        public const string UploadFilePath = "file-upload.dat";

        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route(nameof(UploadMultipartReader))]
        public async Task<IActionResult> UploadMultipartReader()
        {
            try
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

                var reader = new MultipartReader(boundary, Request.Body);

                // Process each section in the multipart body
                MultipartSection? section;
                long totalBytesRead = 0;
                string targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), UploadFilePath);

                if (System.IO.File.Exists(targetFilePath))
                {
                    System.IO.File.Delete(targetFilePath);
                    _logger.LogDebug($"Removed existing output file: {targetFilePath}");
                }

                using FileStream outputFileStream = new FileStream(
                    path: targetFilePath,
                    mode: FileMode.Create,
                    access: FileAccess.Write,
                    share: FileShare.None,
                    bufferSize: 16 * 1024 * 1024, // 16 MB buffer
                    useAsync: true);

                while ((section = await reader.ReadNextSectionAsync()) != null)
                {
                    // Check if the section is a file
                    var contentDisposition = section.GetContentDispositionHeader();
                    if (contentDisposition != null && contentDisposition.IsFileDisposition())
                    {
                        _logger.LogInformation($"Processing file: {contentDisposition.FileName.Value}");

                        // Write the file content to the target file
                        await section.Body.CopyToAsync(outputFileStream);
                        totalBytesRead += section.Body.Length;
                    }
                    else if (contentDisposition != null && contentDisposition.IsFormDisposition())
                    {
                        // Handle metadata (form fields)
                        string key = contentDisposition.Name.Value!;
                        using var streamReader = new StreamReader(section.Body);
                        string value = await streamReader.ReadToEndAsync();
                        _logger.LogInformation($"Received metadata: {key} = {value}");
                    }
                }

                _logger.LogInformation($"File upload completed. Total bytes read: {totalBytesRead} bytes.");
                return Ok(new { Message = "File uploaded successfully.", BytesProcessed = totalBytesRead });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during file upload");
                return StatusCode(500, "An error occurred while uploading the file.");
            }
        }

        [HttpPost]
        [Route(nameof(UploadPipeReader))]
        public async Task<IActionResult> UploadPipeReader()
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
                    share: FileShare.None,
                    bufferSize: BufferSize,
                    useAsync: true);

                while (true)
                {
                    var readResult = await bodyReader.ReadAsync();
                    var buffer = readResult.Buffer;

                    foreach (var memory in buffer)
                    {
                        await outputFileStream.WriteAsync(memory);
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
    }
}
