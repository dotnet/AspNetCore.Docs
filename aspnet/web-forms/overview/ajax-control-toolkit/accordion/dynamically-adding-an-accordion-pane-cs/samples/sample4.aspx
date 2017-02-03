<script runat="server">
void Page_Load() 
{
 if (!Page.IsPostBack)
 {
 AccordionPane ap1 = new AccordionPane();
 ap1.HeaderContainer.Controls.Add(new LiteralControl("Using Markup"));
 ap1.ContentContainer.Controls.Add(new 
 LiteralControl("Adding panes using markup is really simple."));
 AccordionPane ap2 = new AccordionPane();
 ap2.HeaderContainer.Controls.Add(new LiteralControl("Using Code"));
 ap2.ContentContainer.Controls.Add(new 
 LiteralControl("Adding panes using code is really flexible."));
 acc1.Panes.Add(ap1);
 acc1.Panes.Add(ap2);
 }
}
</script>