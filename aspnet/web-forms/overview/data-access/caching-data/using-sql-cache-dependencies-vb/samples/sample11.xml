Dim productsTableDependency As _
    New Caching.SqlCacheDependency("NorthwindDB", "Products")
Cache.Insert(key, _
             value, _ 
             productsTableDependency, _
             System.Web.Caching.Cache.NoAbsoluteExpiration, _
             System.Web.Caching.Cache.NoSlidingExpiration)