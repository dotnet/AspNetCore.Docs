using Microsoft.AspNetCore.RequestDecompression;

namespace RequestDecompressionSample;

#region snippet_CustomDecompressionProvider
public class CustomDecompressionProvider : IDecompressionProvider
{
    public Stream GetDecompressionStream(Stream stream)
    {
        // Perform custom decompression logic here
        return stream;
    }
}
#endregion
