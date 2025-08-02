services.AddSingleton<IMemoryPoolFactory<byte>,
CustomMemoryPoolFactory>();

public class CustomMemoryPoolFactory : IMemoryPoolFactory<byte>
{
    public MemoryPool<byte> Create()
    {
        // Return a custom MemoryPool implementation
        // or the default, as is shown here.
        return MemoryPool<byte>.Shared;
    }
}

