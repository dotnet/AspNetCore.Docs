protected void NewUserWizard_CreatedUser(object sender, EventArgs e)
{
     // Get the UserId of the just-added user
     MembershipUser newUser = Membership.GetUser(NewUserWizard.UserName);
     Guid newUserId = (Guid)newUser.ProviderUserKey;
 
     // Insert a new record into UserProfiles
     string connectionString = 
          ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
     string insertSql = "INSERT INTO UserProfiles(UserId, HomeTown, HomepageUrl,
          Signature) VALUES(@UserId, @HomeTown, @HomepageUrl, @Signature)";
 
     using (SqlConnection myConnection = new SqlConnection(connectionString))
     {
          myConnection.Open();
          SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
          myCommand.Parameters.AddWithValue("@UserId", newUserId);
          myCommand.Parameters.AddWithValue("@HomeTown", DBNull.Value);
          myCommand.Parameters.AddWithValue("@HomepageUrl", DBNull.Value);
          myCommand.Parameters.AddWithValue("@Signature", DBNull.Value);
          myCommand.ExecuteNonQuery();
          myConnection.Close();
     }
}