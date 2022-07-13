using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Net.Http.Headers;            // for app.MapGet("/stream-video/{blobName}/{containerName}"
// <snippet>
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/process-image/{strImage}", (string strImage, HttpContext http, CancellationToken token) =>
{
    http.Response.Headers.CacheControl = $"public,max-age={TimeSpan.FromHours(24).TotalSeconds}";
    return Results.Stream(stream => Resize(strImage, stream, token), "image/jpeg");
});

async Task Resize(string strImage, Stream stream, CancellationToken token)
{
    var strPath = $"wwwroot/img/{strImage}";
    using var image = await Image.LoadAsync(strPath, token);
    int width = image.Width / 2;
    int height = image.Height / 2;
    image.Mutate(x =>x.Resize(width, height)
    );
    await image.SaveAsync(stream, JpegFormat.Instance, cancellationToken: token);
}
// </snippet>

app.MapGet("/rotate-image/{strImage}", (string strImage, HttpContext http, CancellationToken token) =>
{
    http.Response.Headers.CacheControl = $"public,max-age={TimeSpan.FromHours(24).TotalSeconds}";
    return Results.Stream(stream => RotateImage(strImage, stream, token), "image/jpeg");
});

async Task RotateImage(string strImage, Stream stream, CancellationToken token)
{
    var strPath = $"wwwroot/img/{strImage}";
    using var image = await Image.LoadAsync(strPath, token);
    int width = image.Width / 2;
    int height = image.Height / 2;
    image.Mutate(x => x.Rotate(RotateMode.Rotate90)
    );
    await image.SaveAsync(stream, JpegFormat.Instance, cancellationToken: token);
}

// GET /stream-image/microsoft.jpg/pictures
// <snippet_abs>
app.MapGet("/stream-image/{blobName}/{containerName}", 
    async (string blobName, string containerName, CancellationToken token) =>
{
    var conStr = builder.Configuration["blogConStr"];
    BlobContainerClient blobContainerClient = new BlobContainerClient(conStr, containerName);
    BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
    return Results.Stream(await blobClient.OpenReadAsync(cancellationToken: token), "image/jpeg");
});
// </snippet_abs>

// <snippet_video>
// GET /stream-video/earth.mp4/videos
app.MapGet("/stream-video/{blobName}/{containerName}",
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
    
    http.Response.Headers.CacheControl = "public,max-age=86400";

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
    return Results.Stream(stream => Resize(strImage, stream, token), "image/jpeg");
});

// Upload an image to blob storage from local wwwroot/img folder
// The following code requires an Azure storage account with the access key connection
// string stored in configuration.
///POST stream-video/earth.mp4/videos
app.MapPost("/up/{blobName}/{containerName}", (string blobName, string containerName) =>
{
    var conStr = builder.Configuration["blogConStr"];
    BlobContainerClient blobContainerClient = new BlobContainerClient(conStr, containerName);

    if (!blobContainerClient.Exists())
    {
        blobContainerClient.Create();
    }

    BlobClient blob = blobContainerClient.GetBlobClient(blobName);

    blob.Upload($"wwwroot/img/{blobName}");
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

// GET 
app.MapGet("/list-containers/", async () =>
{
    var conStr = builder.Configuration["blogConStr"];
    BlobServiceClient blobServiceClient = new BlobServiceClient(conStr);

    await ListContainers(blobServiceClient, "",99,app.Logger);
});

app.Run();

async static Task ListContainers(BlobServiceClient blobServiceClient,
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
                logger.LogInformation("Container name: {0}", containerItem.Name);
            }

        }
    }
    catch (Azure.RequestFailedException e)
    {
        logger.LogInformation(e.Message);
    }
}
