protected void UserProfileDataSource_Selecting(object sender, 
          SqlDataSourceSelectingEventArgs e)
{
     // Get a reference to the currently logged on user
     MembershipUser currentUser = Membership.GetUser();
 
     // Determine the currently logged on user's UserId value
     Guid currentUserId = (Guid)currentUser.ProviderUserKey;
 
     // Assign the currently logged on user's UserId to the @UserId parameter
     e.Command.Parameters["@UserId"].Value = currentUserId;
}