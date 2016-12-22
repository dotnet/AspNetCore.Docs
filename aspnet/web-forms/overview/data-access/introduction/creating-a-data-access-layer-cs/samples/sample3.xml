using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NorthwindTableAdapters;
public partial class AllProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProductsTableAdapter productsAdapter = new
         ProductsTableAdapter();
        GridView1.DataSource = productsAdapter.GetProducts();
        GridView1.DataBind();
    }
}