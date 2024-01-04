using Microsoft.Extensions.Caching.Memory;
using System;

namespace InMemoryCache.Services
{
    public class CachingService
    {
        private readonly IMemoryCache _memoryCache;

        public CachingService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public string GetOrSetCachedData()
        {
            // Check if the data is already in the cache
            if (_memoryCache.TryGetValue<string>("cachedData", out var cachedData))
            {
                return cachedData;
            }

            // If not in the cache, fetch the data (simulated data in this example)
            var newData = "This data is fetched at: " + DateTime.Now.ToString();

            // Set the data in the cache with a specified expiration time
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(10)
            };

            _memoryCache.Set("cachedData", newData, cacheEntryOptions);

            return newData;
        }
    }
}
