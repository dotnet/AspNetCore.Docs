<script runat="server">
 void Page_Load()
 {
 if (Page.IsPostBack)
 {
 NoBotState state;
 if (!nb.IsValid(out state))
 {
 Label1.Text = "Data refused (" 
 + HttpUtility.HtmlEncode(state.ToString()) + ")";
 }
 else
 {
 Label1.Text = "Data entered.";
 }
 }
 }
</script>