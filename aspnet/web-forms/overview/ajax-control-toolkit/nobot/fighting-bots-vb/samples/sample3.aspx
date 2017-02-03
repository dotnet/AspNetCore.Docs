<script runat="server">
 Sub Page_Load()
 If Page.IsPostBack Then
 Dim state As NoBotState
 If Not nb.IsValid(state) Then
 Label1.Text = "Data refused (" + HttpUtility.HtmlEncode(state.ToString()) + ")"
 Else
 Label1.Text = "Data entered."
 End If
 End If
 End Sub
</script>