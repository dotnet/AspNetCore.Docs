using Microsoft.AspNetCore.ResponseCompression;

public class CustomCompressionProvider : ICompressionProvider
{
    public string EncodingName => "mycustomcompression";
    public bool SupportsFlush => true;

    public Stream CreateStream(Stream outputStream)
    {
        // Replace with a custom compression stream wrapper.
        return outputStream;
    }
}
