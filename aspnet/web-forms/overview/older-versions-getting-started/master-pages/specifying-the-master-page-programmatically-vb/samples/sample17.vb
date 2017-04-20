Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load 
 If Not Page.IsPostBack Then 
 If Session("MyMasterPage") IsNot Nothing Then 
 Dim li As ListItem = MasterPageChoice.Items.FindByText(Session("MyMasterPage").ToString())
 If li IsNot Nothing Then 
 li.Selected = True
 End If 
 End If 
 End If 
End Sub