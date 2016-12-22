using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NorthwindWithSprocsTableAdapters;
[System.ComponentModel.DataObject]
public class SuppliersBLLWithSprocs
{
    private SuppliersTableAdapter _suppliersAdapter = null;
    protected SuppliersTableAdapter Adapter
    {
        get
        {
            if (_suppliersAdapter == null)
                _suppliersAdapter = new SuppliersTableAdapter();
            return _suppliersAdapter;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute
        (System.ComponentModel.DataObjectMethodType.Select, true)]
    public NorthwindWithSprocs.SuppliersDataTable GetSuppliers()
    {
        return Adapter.GetSuppliers();
    }
    [System.ComponentModel.DataObjectMethodAttribute
        (System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateSupplier(string companyName, string contactName, 
        string contactTitle, int supplierID)
    {
        NorthwindWithSprocs.SuppliersDataTable suppliers = 
            Adapter.GetSupplierBySupplierID(supplierID);
        if (suppliers.Count == 0)
            // no matching record found, return false
            return false;
        NorthwindWithSprocs.SuppliersRow supplier = suppliers[0];
        supplier.CompanyName = companyName;
        if (contactName == null) 
            supplier.SetContactNameNull(); 
        else 
            supplier.ContactName = contactName;
        if (contactTitle == null) 
            supplier.SetContactTitleNull(); 
        else 
            supplier.ContactTitle = contactTitle;
        // Update the product record
        int rowsAffected = Adapter.Update(supplier);
        // Return true if precisely one row was updated, otherwise false
        return rowsAffected == 1;
    }
}