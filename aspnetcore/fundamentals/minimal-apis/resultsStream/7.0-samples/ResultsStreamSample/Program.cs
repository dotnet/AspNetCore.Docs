using Azure.Storage.Blobs;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// For local development use Azure Storage Emulator and Azure Storage Explorer 
// https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator
// https://azure.microsoft.com/en-us/features/storage-explorer/
app.MapGet("/stream-image", async () =>
{
    BlobContainerClient blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "pictures");
    BlobClient blobClient = blobContainerClient.GetBlobClient("microsoft.jpeg");
    return Results.Stream(await blobClient.OpenReadAsync(), "image/jpeg");
});

app.MapGet("/stream-video", async (HttpContext http) =>
{
    BlobContainerClient blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "videos");
    BlobClient blobClient = blobContainerClient.GetBlobClient("earth.mp4");
    
    var properties = await blobClient.GetPropertiesAsync();
    
    DateTimeOffset lastModified = properties.Value.LastModified;
    long length = properties.Value.ContentLength;
    
    long etagHash = lastModified.ToFileTime() ^ length;
    var entityTag = new EntityTagHeaderValue('\"' + Convert.ToString(etagHash, 16) + '\"');
    
    http.Response.Headers.CacheControl = "public,max-age=86400";

    // This is an alias for File(Stream, string, string?, DateTimeOffset?, EntityTagHeaderValue?, bool);
    // When fileDownloadName: "rotating-earth.mp4" is added the Content-Disposition header is set to, 'attachment; filename="rotating-earth.mp4"'
    // Else it will show the video inline in the browser
    return Results.Stream(await blobClient.OpenReadAsync(), 
        contentType: "video/mp4",
        lastModified: lastModified,
        entityTag: entityTag,
        enableRangeProcessing: true);
});

app.Run();
