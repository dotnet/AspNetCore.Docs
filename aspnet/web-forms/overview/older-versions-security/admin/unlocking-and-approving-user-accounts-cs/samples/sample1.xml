protected void Page_Load(object sender, EventArgs e)
{
     if (!Page.IsPostBack)
     {

          // If querystring value is missing, send the user to ManageUsers.aspx
          string userName = Request.QueryString["user"];
          if (string.IsNullOrEmpty(userName))
               Response.Redirect("ManageUsers.aspx");

          // Get information about this user
          MembershipUser usr = Membership.GetUser(userName);
          if (usr == null)
               Response.Redirect("ManageUsers.aspx");

          UserNameLabel.Text = usr.UserName;
          IsApproved.Checked = usr.IsApproved;
          if (usr.LastLockoutDate.Year < 2000)

               LastLockoutDateLabel.Text = string.Empty;
          else
               LastLockoutDateLabel.Text = usr.LastLockoutDate.ToShortDateString();

          UnlockUserButton.Enabled = usr.IsLockedOut;
     }
}