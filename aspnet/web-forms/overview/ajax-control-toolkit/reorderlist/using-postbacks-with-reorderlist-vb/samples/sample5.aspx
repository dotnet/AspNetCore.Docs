<script runat="server">
 Sub Page_Load()
 If Page.IsPostBack Then
 lastUpdate.Text = "List last reordered at " & DateTime.Now.ToLongTimeString()
 End If
 End Sub
</script>