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
public partial class BatchData_BatchDelete : System.Web.UI.Page
{
    protected void DeleteSelectedProducts_Click(object sender, EventArgs e)
    {
        bool atLeastOneRowDeleted = false;
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in Products.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
            if (cb != null && cb.Checked)
            {
                // Delete row! (Well, not really...)
                atLeastOneRowDeleted = true;
                // First, get the ProductID for the selected row
                int productID = Convert.ToInt32(Products.DataKeys[row.RowIndex].Value);
                // "Delete" the row
                DeleteResults.Text += string.Format
                    ("This would have deleted ProductID {0}<br />", productID);
                //... To actually delete the product, use ...
                //ProductsBLL productAPI = new ProductsBLL();
                //productAPI.DeleteProduct(productID);
                //............................................
            }
        }
        // Show the Label if at least one row was deleted...
        DeleteResults.Visible = atLeastOneRowDeleted;
    }
    private void ToggleCheckState(bool checkState)
    {
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in Products.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("ProductSelector");
            if (cb != null)
                cb.Checked = checkState;
        }
    }
    protected void CheckAll_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true);
    }
    protected void UncheckAll_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false);
    }
}