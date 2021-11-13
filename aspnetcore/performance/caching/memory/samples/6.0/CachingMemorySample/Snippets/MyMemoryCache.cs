using Microsoft.Extensions.Caching.Memory;

namespace CachingMemorySample.Snippets
{
    #region snippet_Class
    public class MyMemoryCache
    {
        public MemoryCache Cache { get; } = new MemoryCache(
            new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
    }
    #endregion
}
