using System;
using System.Runtime.Caching;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public static class CachingHelper
    {
        private static readonly ObjectCache Cache = MemoryCache.Default;

        public static T GetCache<T>(string key)
        {
            if (Cache.Contains(key))
            {
                return (T)Cache.Get(key);
            }

            return default(T);
        }
        public static void SetCache(string key, object item, double expiryHour)
        {
            Cache.Add(key, item, new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(expiryHour) });
        }
    }
}
