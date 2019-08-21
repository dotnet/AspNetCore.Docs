using System.IO;
using Microsoft.AspNetCore.ResponseCompression;

namespace ResponseCompressionSample
{
    #region snippet1
    public class CustomCompressionProvider : ICompressionProvider
    {
        public string EncodingName => "mycustomcompression";
        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream)
        {
            // Create a custom compression stream wrapper here
            return outputStream;
        }
    }
    #endregion
}
