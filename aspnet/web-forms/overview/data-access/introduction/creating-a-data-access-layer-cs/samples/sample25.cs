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
public partial class SuppliersAndProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SuppliersTableAdapter suppliersAdapter = new
          SuppliersTableAdapter();
        GridView1.DataSource = suppliersAdapter.GetSuppliers();
        GridView1.DataBind();
    }
}