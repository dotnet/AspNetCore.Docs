Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 If Not Page.IsPostBack Then
 If Request.IsAuthenticated AndAlso Not String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
 ' This is an unauthorized, authenticated request...
 Response.Redirect("~/UnauthorizedAccess.aspx")
 End If
 End If
End Sub