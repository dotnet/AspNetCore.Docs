using System.Threading;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Xunit;

namespace CachingSample.Tests
{
    public class MemoryCacheTests
    {
        private readonly MemoryCache _memoryCache;
        private readonly string _cacheItem = "value";
        private readonly string _cacheKey = "key";
        private string _result;

        public MemoryCacheTests()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        [Fact]
        public void RemovalFiresCallback()
        {
            var pause = new ManualResetEvent(false);

            _memoryCache.Set(_cacheKey, _cacheItem,
                new MemoryCacheEntryOptions()
                .RegisterPostEvictionCallback(
                    (key, value, reason, substate) =>
                    {
                        _result = $"'{key}':'{value}' was evicted because: {reason}";
                        pause.Set();
                    }
                ));

            _memoryCache.Remove(_cacheKey);

            Assert.True(pause.WaitOne(500));

            Assert.Equal("'key':'value' was evicted because: Removed", _result);
        }

        [Fact]
        public void CancellationTokenFiresCallback()
        {
            var cts = new CancellationTokenSource();
            var pause = new ManualResetEvent(false);
            _memoryCache.Set(_cacheKey, _cacheItem,
                new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(cts.Token))
                .RegisterPostEvictionCallback(
                    (key, value, reason, substate) =>
                    {
                        _result = $"'{key}':'{value}' was evicted because: {reason}";
                        pause.Set();
                    }
                ));

            // trigger the token
            cts.Cancel();

            Assert.True(pause.WaitOne(500));

            Assert.Equal("'key':'value' was evicted because: TokenExpired", _result);
        }

        [Fact]
        public void CacheEntryDependencies()
        {
            var cts = new CancellationTokenSource();
            var pause = new ManualResetEvent(false);

            using (var cacheLink = _memoryCache.CreateLinkingScope())
            {
                _memoryCache.Set("master key", "some value",
                    new MemoryCacheEntryOptions()
                    .AddExpirationToken(new CancellationChangeToken(cts.Token)));

                _memoryCache.Set(_cacheKey, _cacheItem,
                    new MemoryCacheEntryOptions()
                    .AddEntryLink(cacheLink)
                    .RegisterPostEvictionCallback(
                        (key, value, reason, substate) =>
                        {
                            _result = $"'{key}':'{value}' was evicted because: {reason}";
                            pause.Set();
                        }
                    ));
            }

            // trigger the token to expire the master item
            cts.Cancel();

            Assert.True(pause.WaitOne(500));

            Assert.Equal("'key':'value' was evicted because: TokenExpired", _result);
        }
    }
}
