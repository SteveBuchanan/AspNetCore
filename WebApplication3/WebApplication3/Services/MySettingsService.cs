using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;



namespace WebApplication3.Services
{
    public class MySettingsService
    {
        private const string MySettingsCacheKey = "blah-cache-key";

        private readonly IMemoryCache _cache;
        public MySettingsService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public IEnumerable<ToDoItem> GetSettings()
        {
            if (_cache.TryGetValue(MySettingsCacheKey, out IEnumerable<ToDoItem> items))
            {

                return items; 
            }

            items = MySettings.GetList();

            _cache.Set(MySettingsCacheKey, items);

            return items;
        }
    }
}
