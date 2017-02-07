[System.ComponentModel.DataObject]
public class StaticCache
{
    private static Northwind.SuppliersDataTable suppliers = null;
    public static void LoadStaticCache()
    {
        // Get suppliers - cache using a static member variable
        SuppliersBLL suppliersBLL = new SuppliersBLL();
        suppliers = suppliersBLL.GetSuppliers();
    }
    [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
    public static Northwind.SuppliersDataTable GetSuppliers()
    {
        return suppliers;
    }
}