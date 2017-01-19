protected void Products_DataBound(object sender, EventArgs e)
{
    PagingInformation.Text = string.Format("You are viewing page {0} of {1}...",
        Products.PageIndex + 1, Products.PageCount);
}