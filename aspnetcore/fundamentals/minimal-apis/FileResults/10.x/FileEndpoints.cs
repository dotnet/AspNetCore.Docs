using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Cryptography;

namespace FileResults;

public static class FileEndpoints
{
    public static void MapFileResults(this WebApplication app)
    {
        // <snippet_file_types>
        app.MapGet("/report", () =>
        {
            // TypedResults.File with a byte[] returns a FileContentHttpResult
            byte[] pdf = GenerateReport();
            return TypedResults.File(pdf, "application/pdf", "report.pdf");
        });

        app.MapGet("/download", () =>
        {
            // TypedResults.File with a Stream returns a FileStreamHttpResult
            Stream stream = new MemoryStream("Hello, World!"u8.ToArray());
            return TypedResults.File(stream, "application/octet-stream");
        });
        // </snippet_file_types>

        // <snippet_openapi>
        app.MapGet("/image", () =>
        {
            // A 1x1 red pixel BMP (bitmap header + single pixel)
            byte[] data = [0x42, 0x4D, 0x1E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x1A, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x01, 0x00,
                            0x01, 0x00, 0x01, 0x00, 0x18, 0x00, 0x00, 0x00, 0xFF, 0x00];
            return TypedResults.File(data, MediaTypeNames.Image.Bmp, "pixel.bmp");
        })
        // Use Stream to produce the correct schema in OpenAPI (format: binary)
        .Produces<Stream>(contentType: MediaTypeNames.Image.Bmp);
        // </snippet_openapi>

        app.MapGet("/text", () =>
        {
            byte[] data = "Hello, World!"u8.ToArray();
            return TypedResults.File(data, MediaTypeNames.Text.Plain);
        })
        // Use string as the TResponse to get a simple type: string schema in OpenAPI (no format)
        .Produces<string>(contentType: MediaTypeNames.Text.Plain);

        // <snippet_conditional>
        app.MapGet("/config", (
            [FromHeader(Name = "If-None-Match")] string? ifNoneMatch,
            [FromHeader(Name = "If-Modified-Since")] string? ifModifiedSince) =>
        {
            byte[] data = File.ReadAllBytes("Data/config.json");
            var lastModified = File.GetLastWriteTimeUtc("Data/config.json");
            var etag = new EntityTagHeaderValue($"\"{Convert.ToHexString(SHA256.HashData(data))}\"");

            return TypedResults.File(
                data,
                contentType: MediaTypeNames.Application.Json,
                lastModified: lastModified,
                entityTag: etag);
        })
        .Produces<object>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status304NotModified);
        // </snippet_conditional>

        // <snippet_range>
        app.MapGet("/video/{id}", (string id,
            [FromHeader(Name = "Range")] string? range) =>
        {
            var bytes = GetVideo(id);

            return TypedResults.File(
                bytes,
                contentType: "video/mp4",
                fileDownloadName: "video.mp4",
                enableRangeProcessing: true);
        })
        .Produces<Stream>(StatusCodes.Status200OK, "video/mp4")
        .Produces<Stream>(StatusCodes.Status206PartialContent, "video/mp4")
        .Produces(StatusCodes.Status416RangeNotSatisfiable);
        // </snippet_range>
    }

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
