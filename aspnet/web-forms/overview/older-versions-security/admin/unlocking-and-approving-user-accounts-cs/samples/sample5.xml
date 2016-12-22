protected void Page_Load(object sender, EventArgs e)
{
     if (string.IsNullOrEmpty(Request.QueryString["ID"]))
          StatusMessage.Text = "The UserId was not included in the querystring...";
     else
     {
          Guid userId;
          try
          {
               userId = new Guid(Request.QueryString["ID"]);
          }

          catch
          {
               StatusMessage.Text = "The UserId passed into the querystring is not in the
                    proper format...";
               return;
          }

          MembershipUser usr = Membership.GetUser(userId);
          if (usr == null)
               StatusMessage.Text = "User account could not be found...";
          else
          {
               // Approve the user
               usr.IsApproved = true;

               Membership.UpdateUser(usr);
               StatusMessage.Text = "Your account has been approved. 
                    Please <a href=\"Login.aspx\">login</a> to the site.";
          }
     }
}