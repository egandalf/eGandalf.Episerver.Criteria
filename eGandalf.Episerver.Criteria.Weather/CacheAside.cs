using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace eGandalf.Episerver.Criteria.Weather
{
    public static class CacheAside
    {
        public static T GetOrAddAbsoluteCache<T>(string key, Func<T> builder, DateTime expiration)
        {
            var cache = HttpContext.Current.Cache;
            T result = (T)cache[key];

            if (result != null) return result;

            result = builder();

            cache.Add(key, result, null, expiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            return result;
        }
    }
}
