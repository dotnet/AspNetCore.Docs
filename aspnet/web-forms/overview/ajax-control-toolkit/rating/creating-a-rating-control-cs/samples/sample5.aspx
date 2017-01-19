<script runat="server">
 void Page_Load()
 {
 if (Page.IsPostBack)
 {
 Label1.Text = "Your rating: " + r1.CurrentRating;
 }
 }
</script>