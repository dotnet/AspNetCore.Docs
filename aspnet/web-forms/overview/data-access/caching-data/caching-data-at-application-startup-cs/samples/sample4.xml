[System.ComponentModel.DataObject]
public class StaticCache
{
    public static void LoadStaticCache()
    {
        // Get suppliers - cache using application state
        SuppliersBLL suppliersBLL = new SuppliersBLL();
        HttpContext.Current.Application["key"] = suppliersBLL.GetSuppliers();
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
    public static Northwind.SuppliersDataTable GetSuppliers()
    {
        return HttpContext.Current.Application["key"] as Northwind.SuppliersDataTable;
    }
}