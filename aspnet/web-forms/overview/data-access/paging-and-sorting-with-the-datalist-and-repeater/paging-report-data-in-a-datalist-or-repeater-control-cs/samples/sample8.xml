protected void FirstPage_Click(object sender, EventArgs e)
{
    // Send the user to the first page
    RedirectUser(0);
}
protected void PrevPage_Click(object sender, EventArgs e)
{
    // Send the user to the previous page
    RedirectUser(PageIndex - 1);
}
protected void NextPage_Click(object sender, EventArgs e)
{
    // Send the user to the next page
    RedirectUser(PageIndex + 1);
}
protected void LastPage_Click(object sender, EventArgs e)
{
    // Send the user to the last page
    RedirectUser(PageCount - 1);
}
private void RedirectUser(int sendUserToPageIndex)
{
    // Send the user to the requested page
    Response.Redirect(string.Format("Paging.aspx?pageIndex={0}&pageSize={1}",
        sendUserToPageIndex, PageSize));
}