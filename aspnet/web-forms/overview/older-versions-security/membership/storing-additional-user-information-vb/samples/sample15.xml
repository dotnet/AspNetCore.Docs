Protected Sub NewUserWizard_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUserWizard.ActiveStepChanged
     ' Have we JUST reached the Complete step?
     If NewUserWizard.ActiveStep.Title = "Complete" Then
          Dim UserSettings As WizardStep = CType(NewUserWizard.FindControl("UserSettings"),WizardStep)

          ' Programmatically reference the TextBox controls
          Dim HomeTown As TextBox = CType(UserSettings.FindControl("HomeTown"), TextBox)
          Dim HomepageUrl As TextBox = CType(UserSettings.FindControl("HomepageUrl"), TextBox)
          Dim Signature As TextBox = CType(UserSettings.FindControl("Signature"), TextBox)

          ' Update the UserProfiles record for this user
          ' Get the UserId of the just-added user
          Dim newUser As MembershipUser = Membership.GetUser(NewUserWizard.UserName)
          Dim newUserId As Guid = CType(newUser.ProviderUserKey, Guid)

          ' Insert a new record into UserProfiles
          Dim connectionString As String = ConfigurationManager.ConnectionStrings("SecurityTutorialsConnectionString").ConnectionString

          Dim updateSql As String = "UPDATE UserProfiles SET HomeTown = @HomeTown, HomepageUrl
               = @HomepageUrl, Signature = @Signature WHERE UserId = @UserId"

          Using myConnection As New SqlConnection(connectionString)
               myConnection.Open()
               Dim myCommand As New SqlCommand(updateSql, myConnection)
               myCommand.Parameters.AddWithValue("@HomeTown", HomeTown.Text.Trim())
               myCommand.Parameters.AddWithValue("@HomepageUrl", HomepageUrl.Text.Trim())
               myCommand.Parameters.AddWithValue("@Signature", Signature.Text.Trim())

               myCommand.Parameters.AddWithValue("@UserId", newUserId)
               myCommand.ExecuteNonQuery()
               myConnection.Close()
          End Using
     End If
End Sub