protected void PostCommentButton_Click(object sender, EventArgs e)
{
     if (!Page.IsValid)
          return;
 
     // Determine the currently logged on user's UserId
     MembershipUser currentUser = Membership.GetUser();
     Guid currentUserId = (Guid)currentUser.ProviderUserKey;
 
     // Insert a new record into GuestbookComments
     string connectionString = 
          ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
     string insertSql = "INSERT INTO GuestbookComments(Subject, Body, UserId) VALUES(@Subject,
               @Body, @UserId)";
 
     using (SqlConnection myConnection = new SqlConnection(connectionString))
     {
          myConnection.Open();
          SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
          myCommand.Parameters.AddWithValue("@Subject", Subject.Text.Trim());
          myCommand.Parameters.AddWithValue("@Body", Body.Text.Trim());
          myCommand.Parameters.AddWithValue("@UserId", currentUserId);
          myCommand.ExecuteNonQuery();
          myConnection.Close();
     }
 
     // "Reset" the Subject and Body TextBoxes
     Subject.Text = string.Empty;
     Body.Text = string.Empty;
}