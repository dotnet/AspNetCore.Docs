Sub Page_Load()
 If Not Page.IsPostBack Then
 tbName.Text = lblName.Text
 tbEmail.Text = lblEmail.Text
 End If
End Sub