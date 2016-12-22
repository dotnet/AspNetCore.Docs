// insert a value into cache that will serve
// as the cache key
Cache["CacheKey"] = "something";

// create an array of cache keys
string[] keys = new String[1];
keys[0] = "CacheKey";

CacheDependency dep = new CacheDependency(null, keys);

// insert an item into cache with a dependency on
// the above CacheDependency
Cache.Insert("Key", "Value", dep);