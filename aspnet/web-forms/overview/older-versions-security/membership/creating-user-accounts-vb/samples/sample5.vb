Const passwordQuestion As String = "What is your favorite color"
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load 
 If Not Page.IsPostBack Then 
 SecurityQuestion.Text = passwordQuestion 
 End If 
End Sub