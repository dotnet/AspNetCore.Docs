private void BindUserAccounts()
{
 int totalRecords;
 UserAccounts.DataSource = Membership.FindUsersByName(this.UsernameToMatch + "%",this.PageIndex, this.PageSize, out totalRecords);
 UserAccounts.DataBind();

 // Enable/disable the paging interface
 bool visitingFirstPage = (this.PageIndex == 0);
 lnkFirst.Enabled = !visitingFirstPage;
 lnkPrev.Enabled = !visitingFirstPage;

 int lastPageIndex = (totalRecords - 1) / this.PageSize;
 bool visitingLastPage = (this.PageIndex >= lastPageIndex);
 lnkNext.Enabled = !visitingLastPage;
 lnkLast.Enabled = !visitingLastPage;
}