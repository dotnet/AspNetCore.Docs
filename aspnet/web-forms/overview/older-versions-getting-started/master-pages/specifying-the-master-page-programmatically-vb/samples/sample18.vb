Protected Sub SaveLayout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveLayout.Click 
 Session("MyMasterPage") = MasterPageChoice.SelectedValue 
 Response.Redirect("ChooseMasterPage.aspx")
End Sub