using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
namespace Util
{
    public sealed class CacheManager
    {
        private static readonly Cache _cache;
        

        static CacheManager()
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                _cache = current.Cache;
            }
            _cache = HttpRuntime.Cache;

        }

        public static void Insert(string key, object value)
        {
            Insert(key, value, null, 60);
        }

        public static void Insert(string key, object value, int seconds)
        {
            Insert(key, value, null, seconds);
        }

        public static void Insert(string key, object value, CacheDependency dep)
        {
            Insert(key, value, dep, 0x21c0);
        }

        public static void Insert(string key, object value, int seconds, CacheItemPriority priority)
        {
            Insert(key, value, null, seconds, priority);
        }

        public static void Insert(string key, object value, CacheDependency dep, int seconds)
        {
            Insert(key, value, dep, seconds, CacheItemPriority.NotRemovable);
        }

        public static void Insert(string key, object value, CacheDependency dep, int seconds, CacheItemPriority priority)
        {
            if (value != null)
            {
                _cache.Insert(key, value, dep, DateTime.Now.AddSeconds((double)seconds), TimeSpan.Zero, priority, null);
            }
        }

        public static void Insert(string key, object value, CacheDependency dep, int seconds,CacheItemPriority priority, CacheItemRemovedCallback callback)
        {
            if (value != null)
            {
                _cache.Insert(key, value, dep, DateTime.Now.AddSeconds((double)seconds),Cache.NoSlidingExpiration, priority, callback);
            }
        }

        public static void Insert(string key, object value, CacheDependency dep, TimeSpan ts, CacheItemPriority priority)
        {
            if (value != null)
            {
                _cache.Insert(key, value, dep, Cache.NoAbsoluteExpiration, ts, priority, null);
            }
        }

        public static void Insert(string key, object value, CacheDependency dep, TimeSpan ts, CacheItemPriority priority,CacheItemRemovedCallback callback)
        {
            if (value != null)
            {
                _cache.Insert(key, value, dep, Cache.NoAbsoluteExpiration, ts, priority, callback);
            }
        }

        public static void RemoveByPattern(string pattern)
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            ArrayList list = new ArrayList();
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(enumerator.Key.ToString()))
                {
                    list.Add(enumerator.Key);
                }
            }
            foreach (string str in list)
            {
                _cache.Remove(str);
            }
        }


        public static object Get(string key)
        {
            return _cache[key];

        }

        public static void Remove(string key)
        {
            _cache.Remove(key);

        }

        public static void Clear()
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            ArrayList list = new ArrayList();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Key);
            }
            foreach (string str in list)
            {
                _cache.Remove(str);
            }

        }
    }
}
