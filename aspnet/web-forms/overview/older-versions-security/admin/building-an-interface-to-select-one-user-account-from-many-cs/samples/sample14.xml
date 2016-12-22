protected void lnkFirst_Click(object sender, EventArgs e)
{
 this.PageIndex = 0;
 BindUserAccounts();
}

protected void lnkPrev_Click(object sender, EventArgs e)
{
 this.PageIndex -= 1;
 BindUserAccounts();
}

protected void lnkNext_Click(object sender, EventArgs e)
{
 this.PageIndex += 1;
 BindUserAccounts();
}

protected void lnkLast_Click(object sender, EventArgs e)
{
 // Determine the total number of records
 int totalRecords;
 Membership.FindUsersByName(this.UsernameToMatch + "%", this.PageIndex,this.PageSize, out totalRecords);
 // Navigate to the last page index
 this.PageIndex = (totalRecords - 1) / this.PageSize;
 BindUserAccounts();
}