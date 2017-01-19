<script runat="server">
 Sub ServerButton_Click(ByVal sender As Object, ByVal e As EventArgs)
 ClientScript.RegisterStartupScript(Me.GetType(), "key", "launchModal();", True)
 End Sub
</script>