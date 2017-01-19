private string SortExpression
{
    get
    {
        if (!string.IsNullOrEmpty(Request.QueryString["sortExpression"]))
            return Request.QueryString["sortExpression"];
        else
            return "ProductName";
    }
}
private void RedirectUser(int sendUserToPageIndex)
{
    // Use the SortExpression property to get the sort expression
    // from the querystring
    RedirectUser(sendUserToPageIndex, SortExpression);
}
private void RedirectUser(int sendUserToPageIndex, string sendUserSortingBy)
{
   // Send the user to the requested page with the requested sort expression
   Response.Redirect(string.Format(
      "SortingWithDefaultPaging.aspx?pageIndex={0}&pageSize={1}&sortExpression={2}",
      sendUserToPageIndex, PageSize, sendUserSortingBy));
}