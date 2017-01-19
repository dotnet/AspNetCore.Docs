protected void Products_DataBound(object sender, EventArgs e)
{
    // Send user to last page of data, if needed
    if (SendUserToLastPage)
        Products.PageIndex = Products.PageCount - 1;
}