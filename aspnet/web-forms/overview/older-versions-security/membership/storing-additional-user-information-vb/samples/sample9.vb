Protected Sub PostCommentButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PostCommentButton.Click
     If Not Page.IsValid Then Exit Sub

     ' Determine the currently logged on user's UserId
     Dim currentUser As MembershipUser = Membership.GetUser()
     Dim currentUserId As Guid = CType(currentUser.ProviderUserKey, Guid)

     ' Insert a new record into GuestbookComments
     Dim connectionString As String = 
          ConfigurationManager.ConnectionStrings("SecurityTutorialsConnectionString").ConnectionString
     Dim insertSql As String = "INSERT INTO GuestbookComments(Subject, Body, UserId)
          VALUES(@Subject, @Body, @UserId)"

     Using myConnection As New SqlConnection(connectionString)

          myConnection.Open()
          Dim myCommand As New SqlCommand(insertSql, myConnection)
          myCommand.Parameters.AddWithValue("@Subject", Subject.Text.Trim())
          myCommand.Parameters.AddWithValue("@Body", Body.Text.Trim())
          myCommand.Parameters.AddWithValue("@UserId", currentUserId)
          myCommand.ExecuteNonQuery()
          myConnection.Close()
     End Using

     ' "Reset" the Subject and Body TextBoxes

     Subject.Text = String.Empty
     Body.Text = String.Empty
End Sub