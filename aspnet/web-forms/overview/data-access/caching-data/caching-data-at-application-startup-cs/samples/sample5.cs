[System.ComponentModel.DataObject]
public class StaticCache
{
    public static void LoadStaticCache()
    {
        // Get suppliers - cache using the data cache
        SuppliersBLL suppliersBLL = new SuppliersBLL();
        HttpRuntime.Cache.Insert(
          /* key */                "key", 
          /* value */              suppliers, 
          /* dependencies */       null, 
          /* absoluteExpiration */ Cache.NoAbsoluteExpiration, 
          /* slidingExpiration */  Cache.NoSlidingExpiration, 
          /* priority */           CacheItemPriority.NotRemovable, 
          /* onRemoveCallback */   null);
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
    public static Northwind.SuppliersDataTable GetSuppliers()
    {
        return HttpRuntime.Cache["key"] as Northwind.SuppliersDataTable;
    }
}