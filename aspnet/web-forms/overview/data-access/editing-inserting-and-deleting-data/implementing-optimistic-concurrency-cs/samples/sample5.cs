using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NorthwindOptimisticConcurrencyTableAdapters;
[System.ComponentModel.DataObject]
public class ProductsOptimisticConcurrencyBLL
{
    private ProductsOptimisticConcurrencyTableAdapter _productsAdapter = null;
    protected ProductsOptimisticConcurrencyTableAdapter Adapter
    {
        get
        {
            if (_productsAdapter == null)
                _productsAdapter = new ProductsOptimisticConcurrencyTableAdapter();
            return _productsAdapter;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute
    (System.ComponentModel.DataObjectMethodType.Select, true)]
    public NorthwindOptimisticConcurrency.ProductsOptimisticConcurrencyDataTable GetProducts()
    {
        return Adapter.GetProducts();
    }
}