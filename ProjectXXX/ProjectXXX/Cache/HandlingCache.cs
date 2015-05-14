using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectXXX.Cache
{
    public class HandlingCache
    {
        public static TType FromCache<TType>(string key, Func<TType> function)
            where TType : class
        {
            var cacheValue = HttpContext.Current.Cache.Get(key);
            if (cacheValue != null)
                return (TType)cacheValue;

            var value = function();

            HttpContext.Current.Cache.Insert(key, value);
            return value;
        }

        public static void Clear()
        {
            foreach (DictionaryEntry entry in HttpContext.Current.Cache)
            {
                HttpContext.Current.Cache.Remove((string)entry.Key);
            }
        }
    }
}