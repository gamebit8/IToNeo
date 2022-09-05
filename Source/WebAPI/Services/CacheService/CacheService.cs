using IToNeo.WebAPI.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace IToNeo.WebAPI.Services.CacheService
{
    public class CacheService<T> : ICacheService<T> where T : class
    {
        private readonly IDistributedCache _distributedCache;
        private int _defaultExpirationRelativeInMinutes;
        public CacheService(IDistributedCache distributedCache, int defaultExpirationRelativeInMinutes = 1)
        {
            _distributedCache = distributedCache;
            _defaultExpirationRelativeInMinutes = defaultExpirationRelativeInMinutes;
        }

        public async Task<T> GetAsync(string key)
        {
            string result = await _distributedCache.GetStringAsync(key);

            return result != null ? JsonSerializer.Deserialize<T>(result) : default;
        }

        public async Task SetAsync(string key, T value)
        {
            string stringValue = JsonSerializer.Serialize(value);
            var cacheOption = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(_defaultExpirationRelativeInMinutes));
            await _distributedCache.SetStringAsync(key, stringValue, cacheOption);
        }

        public async Task SetAsync(string key, T value, int expirationRelativeInMinutes)
        {
            string stringValue = JsonSerializer.Serialize(value);
            var cacheOption = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(expirationRelativeInMinutes));
            await _distributedCache.SetStringAsync(key, stringValue, cacheOption);
        }
    }
}
