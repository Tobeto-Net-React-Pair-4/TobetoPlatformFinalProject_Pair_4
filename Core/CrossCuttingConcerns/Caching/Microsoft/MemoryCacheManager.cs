using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern
        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            // Önbellek girişleri koleksiyonunu al
            dynamic cacheEntriesCollection = null;
            var cacheEntriesFieldCollectionDefinition = typeof(MemoryCache).GetField("_coherentState", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (cacheEntriesFieldCollectionDefinition != null)
            {
                var coherentStateValueCollection = cacheEntriesFieldCollectionDefinition.GetValue(_memoryCache);
                var entriesCollectionValueCollection = coherentStateValueCollection.GetType().GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                cacheEntriesCollection = entriesCollectionValueCollection.GetValue(coherentStateValueCollection);
            }

            // Önbellek koleksiyonu değerlerini tutacak bir liste oluştur
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            // Populate cacheCollectionValues with actual cache entries // Önbellek koleksiyonu değerlerini gerçek önbellek girişleriyle doldur
            foreach (var cacheEntry in cacheEntriesCollection)
            {
                var value = cacheEntry.GetType().GetProperty("Value").GetValue(cacheEntry, null);
                cacheCollectionValues.Add(value);
            }

            // Verilen desene uyan anahtarları seç ve kaldır
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => d != null && regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            // Anahtarları önbellekten kaldır
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
