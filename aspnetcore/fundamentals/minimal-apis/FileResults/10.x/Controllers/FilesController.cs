using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Cryptography;

namespace FileResults.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
    // <snippet_file_types>
    [HttpGet("report")]
    public FileContentResult Report()
    {
        // File() with a byte[] returns a FileContentResult
        byte[] pdf = GenerateReport();
        return File(pdf, "application/pdf", "report.pdf");
    }

    [HttpGet("download")]
    public FileStreamResult Download()
    {
        // File() with a Stream returns a FileStreamResult
        Stream stream = new MemoryStream("Hello, World!"u8.ToArray());
        return File(stream, "application/octet-stream");
    }
    // </snippet_file_types>

    // <snippet_openapi>
    [HttpGet("image")]
    // Use Stream to produce the correct schema in OpenAPI (format: binary)
    [ProducesResponseType<Stream>(StatusCodes.Status200OK, MediaTypeNames.Image.Bmp)]
    public FileContentResult Image()
    {
        // A 1x1 red pixel BMP (bitmap header + single pixel)
        byte[] data = [0x42, 0x4D, 0x1E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                       0x1A, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x00,
                       0x01, 0x00, 0x01, 0x00, 0x18, 0x00, 0x00, 0x00, 0xFF, 0x00];
        return File(data, "image/bmp", "pixel.bmp");
    }
    // </snippet_openapi>

    [HttpGet("text")]
    [ProducesResponseType<string>(StatusCodes.Status200OK, MediaTypeNames.Text.Plain)]
    public FileContentResult Text()
    {
        byte[] data = "Hello, World!"u8.ToArray();
        return File(data, "text/plain");
    }

    // <snippet_conditional>
    [HttpGet("config")]
    [ProducesResponseType<object>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status304NotModified)]
    public FileContentResult Config(
        [FromHeader(Name = "If-None-Match")] string? ifNoneMatch,
        [FromHeader(Name = "If-Modified-Since")] string? ifModifiedSince)
    {
        byte[] data = System.IO.File.ReadAllBytes("Data/config.json");
        var lastModified = System.IO.File.GetLastWriteTimeUtc("Data/config.json");
        var etag = new EntityTagHeaderValue($"\"{Convert.ToHexString(SHA256.HashData(data))}\"");

        return File(
            data,
            MediaTypeNames.Application.Json,
            lastModified: lastModified,
            entityTag: etag);
    }
    // </snippet_conditional>

    // <snippet_range>
    [HttpGet("video/{id}")]
    [ProducesResponseType<Stream>(StatusCodes.Status200OK, "video/mp4")]
    [ProducesResponseType<Stream>(StatusCodes.Status206PartialContent, "video/mp4")]
    [ProducesResponseType(StatusCodes.Status416RangeNotSatisfiable)]
    public FileContentResult Video(string id,
        [FromHeader(Name = "Range")] string? range)
    {
        var bytes = GetVideo(id);

        return File(
            bytes,
            contentType: "video/mp4",
            fileDownloadName: "video.mp4",
            enableRangeProcessing: true);
    }
    // </snippet_range>

    private static byte[] GenerateReport()
    {
        // Simulated PDF content for demonstration
        return System.Text.Encoding.UTF8.GetBytes("%PDF-1.4 simulated report content");
    }

    private static byte[] GetVideo(string id)
    {
        // Simulated video content for demonstration
        var content = $"Simulated video content for id={id}";
        return System.Text.Encoding.UTF8.GetBytes(content);
    }
}
