<script runat="server">
 protected void btn_Click(object sender, EventArgs e)
 {
 lbl.Text = HttpUtility.HtmlEncode(Name.Text);
 }
</script>