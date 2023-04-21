using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();

builder.Services.TryAddSingleton<ObjectPool<ReusableBuffer>>(serviceProvider =>
{
    var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
    var policy = new DefaultPooledObjectPolicy<ReusableBuffer>();
    return provider.Create(policy);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// return the SHA256 hash of a word 
// https://localhost:7214/hash/SamsonAmaugo
app.MapGet("/hash/{name}", (string name, ObjectPool<ReusableBuffer> bufferPool) =>
{

    var buffer = bufferPool.Get();
    try
    {
        // Set the buffer data to the ASCII values of a word
        for (var i = 0; i < name.Length; i++)
        {
            buffer.Data[i] = (byte)name[i];
        }

        Span<byte> hash = stackalloc byte[32];
        SHA256.HashData(buffer.Data.AsSpan(0, name.Length), hash);
        return "Hash: " + Convert.ToHexString(hash);
    }
    finally
    {
        // Data is automatically reset because thit type implemented IResettable
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
