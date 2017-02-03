System.Web.Caching.CacheDependency dep = new
    System.Web.Caching.CacheDependency(Server.MapPath("stuff.xml"));
Response.AddCacheDependency(dep);
Cache.Insert("key", "value");