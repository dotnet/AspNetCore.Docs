Protected Sub NewUserWizard_CreatedUser(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUserWizard.CreatedUser
     ' Get the UserId of the just-added user
     Dim newUser As MembershipUser = Membership.GetUser(NewUserWizard.UserName)
     Dim newUserId As Guid = CType(newUser.ProviderUserKey, Guid)

     ' Insert a new record into UserProfiles
     Dim connectionString As String = 

          ConfigurationManager.ConnectionStrings("SecurityTutorialsConnectionString").ConnectionString
     Dim insertSql As String = "INSERT INTO UserProfiles(UserId, HomeTown, HomepageUrl,
          Signature) VALUES(@UserId, @HomeTown, @HomepageUrl, @Signature)"

     Using myConnection As New SqlConnection(connectionString)
          myConnection.Open()
          Dim myCommand As New SqlCommand(insertSql, myConnection)
          myCommand.Parameters.AddWithValue("@UserId", newUserId)
          myCommand.Parameters.AddWithValue("@HomeTown", DBNull.Value)

          myCommand.Parameters.AddWithValue("@HomepageUrl", DBNull.Value)
          myCommand.Parameters.AddWithValue("@Signature", DBNull.Value)
          myCommand.ExecuteNonQuery()
          myConnection.Close()
     End Using
End Sub