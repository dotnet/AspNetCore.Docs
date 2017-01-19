<script runat="server">
 protected void ServerButton_Click(object sender, EventArgs e)
 {
 ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
 }
</script>