<script runat="server">
Sub Page_Load()
 If Not Page.IsPostBack Then
 Dim ap1 As New AccordionPane()
 ap1.HeaderContainer.Controls.Add(New LiteralControl("Using Markup"))
 ap1.ContentContainer.Controls.Add(New LiteralControl("Adding panes using markup is really simple."))
 Dim ap2 As New AccordionPane()
 ap2.HeaderContainer.Controls.Add(New LiteralControl("Using Code"))
 ap2.ContentContainer.Controls.Add(New LiteralControl("Adding panes using code is really flexible."))
 acc1.Panes.Add(ap1)
 acc1.Panes.Add(ap2)
 End If
End Sub
</script>