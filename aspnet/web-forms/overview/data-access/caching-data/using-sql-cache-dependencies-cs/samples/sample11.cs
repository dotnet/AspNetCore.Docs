Caching.SqlCacheDependency productsTableDependency = 
    new Caching.SqlCacheDependency("NorthwindDB", "Products");
Cache.Insert(key, 
             value, 
             productsTableDependency, 
             System.Web.Caching.Cache.NoAbsoluteExpiration, 
             System.Web.Caching.Cache.NoSlidingExpiration);