using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Net.Http.Headers;            // for app.MapGet("/stream-video/{containerName}/{blobName}"
// <snippet>
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/process-image/{strImage}", (string strImage, HttpContext http, CancellationToken token) =>
{
    http.Response.Headers.CacheControl = $"public,max-age={TimeSpan.FromHours(24).TotalSeconds}";
    return Results.Stream(stream => ResizeImageAsync(strImage, stream, token), "image/jpeg");
});

async Task ResizeImageAsync(string strImage, Stream stream, CancellationToken token)
{
    var strPath = $"wwwroot/img/{strImage}";
    using var image = await Image.LoadAsync(strPath, token);
    int width = image.Width / 2;
    int height = image.Height / 2;
    image.Mutate(x =>x.Resize(width, height));
    await image.SaveAsync(stream, JpegFormat.Instance, cancellationToken: token);
}
// </snippet>

// GET /rotate-image/microsoft.jpg
app.MapGet("/rotate-image/{strImage}", (string strImage, HttpContext http, CancellationToken token) =>
{
    http.Response.Headers.CacheControl = $"public,max-age={TimeSpan.FromHours(24).TotalSeconds}";
    return Results.Stream(stream => RotateImageAsync(strImage, stream, token), "image/jpeg");
});

async Task RotateImageAsync(string strImage, Stream stream, CancellationToken token)
{
    var strPath = $"wwwroot/img/{strImage}";
    using var image = await Image.LoadAsync(strPath, token);
    image.Mutate(x => x.Rotate(RotateMode.Rotate90));
    await image.SaveAsync(stream, JpegFormat.Instance, cancellationToken: token);
}

// GET /stream-image/pictures/microsoft.jpg
// <snippet_abs>
app.MapGet("/stream-image/{containerName}/{blobName}", 
    async (string blobName, string containerName, CancellationToken token) =>
{
    var conStr = builder.Configuration["blogConStr"];
    BlobContainerClient blobContainerClient = new BlobContainerClient(conStr, containerName);
    BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
    return Results.Stream(await blobClient.OpenReadAsync(cancellationToken: token), "image/jpeg");
});
// </snippet_abs>

// <snippet_video>
// GET /stream-video/videos/earth.mp4
app.MapGet("/stream-video/{containerName}/{blobName}",
     async (HttpContext http, CancellationToken token, string blobName, string containerName) =>
{
    var conStr = builder.Configuration["blogConStr"];
    BlobContainerClient blobContainerClient = new BlobContainerClient(conStr, containerName);
    BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
    
    var properties = await blobClient.GetPropertiesAsync(cancellationToken: token);
    
    DateTimeOffset lastModified = properties.Value.LastModified;
    long length = properties.Value.ContentLength;
    
    long etagHash = lastModified.ToFileTime() ^ length;
    var entityTag = new EntityTagHeaderValue('\"' + Convert.ToString(etagHash, 16) + '\"');
    
    http.Response.Headers.CacheControl = $"public,max-age={TimeSpan.FromHours(24).TotalSeconds}";

    return Results.Stream(await blobClient.OpenReadAsync(cancellationToken: token), 
        contentType: "video/mp4",
        lastModified: lastModified,
        entityTag: entityTag,
        enableRangeProcessing: true);
});
// </snippet_video>

app.MapGet("/", () => "Blob test");

// quick test get wwwroot/img/{strImage} and return it
app.MapGet("/process-image/{strImage}", (string strImage, HttpContext http, CancellationToken token) =>
{
    http.Response.Headers.CacheControl = $"public,max-age={TimeSpan.FromHours(24).TotalSeconds}";
    return Results.Stream(stream => ResizeImageAsync(strImage, stream, token), "image/jpeg");
});

// Upload an image to blob storage from local wwwroot/img folder
// The following code requires an Azure storage account with the access key connection
// string stored in configuration.
// POST stream-video/videos/earth.mp4
app.MapPost("/up/{containerName}/{blobName}", async (string blobName, string containerName) =>
{
    var conStr = builder.Configuration["blogConStr"];
    BlobContainerClient blobContainerClient = new BlobContainerClient(conStr, containerName);

    if (!blobContainerClient.Exists())
    {
        blobContainerClient.Create();
    }

    BlobClient blob = blobContainerClient.GetBlobClient(blobName);

    await blob.UploadAsync($"wwwroot/img/{blobName}");
});

app.MapGet("/list/{containerName}", async ( string containerName) =>
{
    var conStr = builder.Configuration["blogConStr"];
    BlobContainerClient blobContainerClient = new BlobContainerClient(conStr, containerName);

    await foreach (BlobItem blobItem in blobContainerClient.GetBlobsAsync())
    {
        app.Logger.LogInformation("\t" + blobItem.Name);
    }
});

// GET /list-containers
app.MapGet("/list-containers", async () =>
{
    var conStr = builder.Configuration["blogConStr"];
    BlobServiceClient blobServiceClient = new BlobServiceClient(conStr);

    await ListContainersAsync(blobServiceClient, "", 99, app.Logger);
});

app.Run();

static async Task ListContainersAsync(BlobServiceClient blobServiceClient,
                                string prefix,
                                int? segmentSize,
                                ILogger logger)
{
    try
    {
        var resultSegment =
            blobServiceClient.GetBlobContainersAsync(BlobContainerTraits.Metadata, prefix, default)
            .AsPages(default, segmentSize);

        await foreach (Azure.Page<BlobContainerItem> containerPage in resultSegment)
        {
            foreach (BlobContainerItem containerItem in containerPage.Values)
            {
                logger.LogInformation($"Container name: {containerItem.Name}");
            }

        }
    }
    catch (Azure.RequestFailedException e)
    {
        logger.LogInformation(e.Message);
    }
}
