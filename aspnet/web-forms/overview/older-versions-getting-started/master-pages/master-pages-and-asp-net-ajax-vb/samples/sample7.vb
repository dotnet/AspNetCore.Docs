Protected Sub ProductPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductPanel.Load
 LastUpdateTime.Text = "Last updated at " & DateTime.Now.ToLongTimeString()
End Sub