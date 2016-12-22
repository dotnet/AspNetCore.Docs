protected void IsApproved_CheckedChanged(object sender, EventArgs e)
{
     // Toggle the user's approved status
     string userName = Request.QueryString["user"];
     MembershipUser usr = Membership.GetUser(userName);
     usr.IsApproved = IsApproved.Checked;
     Membership.UpdateUser(usr);
     StatusMessage.Text = "The user's approved status has been updated.";
}

protected void UnlockUserButton_Click(object sender, EventArgs e)
{
     // Unlock the user account
     string userName = Request.QueryString["user"];
     MembershipUser usr = Membership.GetUser(userName);

     usr.UnlockUser();
     UnlockUserButton.Enabled = false;
     StatusMessage.Text = "The user account has been unlocked.";
}