Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     If String.IsNullOrEmpty(Request.QueryString("ID")) Then
          StatusMessage.Text = "The UserId was not included in the querystring..."
     Else
          Dim userId As Guid
          Try
               userId = New Guid(Request.QueryString("ID"))
          Catch
               StatusMessage.Text = "The UserId passed into the querystring is not in the proper format..."

               Exit Sub
          End Try

          Dim usr As MembershipUser = Membership.GetUser(userId)
          If usr Is Nothing Then
               StatusMessage.Text = "User account could not be found..."
          Else
               ' Approve the user
               usr.IsApproved = True
               Membership.UpdateUser(usr)
               StatusMessage.Text = "Your account has been approved. Please <a href=""Login.aspx"">login</a> to the site."

          End If
     End If
End Sub