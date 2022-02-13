using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace ProjectCommons.CacheCommon.CacheServiceCommon
{
    public class CacheService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IDistributedCache cache, ILogger<CacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task PutCacheValue<T>(CachedEnum entity, string id, T value, TimeSpan? expiration = null)
        {
            var key = ConstructCacheKey(entity, id);
            var jsonValue = JsonConvert.SerializeObject(value);
            var encodedValues = Encoding.UTF8.GetBytes(jsonValue);
            await _cache.SetAsync(key, encodedValues, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            });
        }

        public async Task<T> GetCachedValue<T>(CachedEnum entity, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return default;
            }
            var key = ConstructCacheKey(entity, id);
            var valueArray = await _cache.GetAsync(key);
            if (valueArray == null)
            {
                _logger.LogInformation(new EventId(20, "CacheMiss"), "cache miss for key {key}", key);
                return default;
            }
            _logger.LogInformation(new EventId(10, "CacheHit"), "cache hit for key {key}", key);
            var jsonValue = Encoding.UTF8.GetString(valueArray);
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }

        public async Task EvictKey(CachedEnum entity, string id)
        {
            var key = ConstructCacheKey(entity, id);
            await _cache.RemoveAsync(key);
        }

        private static string ConstructCacheKey(CachedEnum entity, string id)
        {
            var key = $"HotelRecord_{entity.ToString().ToLower()}_{id.ToLower()}";
            return key;
        }
    }
}
