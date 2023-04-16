using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();

builder.Services.TryAddSingleton<ObjectPool<ReusableBuffer>>(serviceProvider =>
{
    var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
    var policy = new ReusableBufferPolicy();
    return provider.Create(policy);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// return the SHA256 hash of a word 
// https://localhost:7214/SamsonAmaugo
app.MapGet("/{name}", async (string name, ObjectPool<ReusableBuffer> bufferPool) =>
{

    var buffer = bufferPool.Get();
    try
    {
        // Set the buffer data to the ASCII values of a word
        for (int i = 0; i < name.Length; i++)
        {
            buffer.Data[i] = (byte)name[i];
        }

        using (var sha256 = SHA256.Create())
        {
            // Calculate the hash of the data
            var hash = sha256.ComputeHash(buffer.Data);
            return "Hash: " + BitConverter.ToString(hash).Replace("-", "");
        }
    }
    finally
    {
        // Data is automatically reset
        bufferPool.Return(buffer); 
    }
});
app.Run();

public class ReusableBuffer : IResettable
{
    public byte[] Data { get; } = new byte[1024 * 1024]; // 1 MB

    public bool TryReset()
    {
        Array.Clear(Data);
        return true;
    }
}
