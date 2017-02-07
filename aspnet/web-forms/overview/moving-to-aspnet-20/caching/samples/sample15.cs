System.Web.Caching.CacheDependency dep = new
    System.Web.Caching.CacheDependency(Server.MapPath("cache.xml"));
Response.AddCacheDependency(dep);
Cache.Insert("time", DateTime.Now.ToString());
Response.Write(Cache["time"]);