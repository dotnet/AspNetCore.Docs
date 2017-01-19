<script runat="server">
 Sub Page_Load()
 If Page.IsPostBack Then
 LastUpdate.Text = "Last update: " & DateTime.Now.ToLongTimeString()
 End If
 End Sub
</script>