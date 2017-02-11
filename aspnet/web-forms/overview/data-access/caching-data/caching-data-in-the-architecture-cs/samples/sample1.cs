// Read from the cache
object value = Cache["key"];
// Add a new item to the cache
Cache["key"] = value;
Cache.Insert(key, value);
Cache.Insert(key, value, CacheDependency);
Cache.Insert(key, value, CacheDependency, DateTime, TimeSpan);