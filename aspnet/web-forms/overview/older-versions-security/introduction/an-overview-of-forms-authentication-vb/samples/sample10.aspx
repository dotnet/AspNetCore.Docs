<div id="navigation">
 <asp:ContentPlaceHolder ID="LoginContent" runat="server">
 <asp:LoginView ID="LoginView1" runat="server">
 <LoggedInTemplate>
 Welcome back, <asp:LoginName ID="LoginName1" runat="server" />.
 </LoggedInTemplate>
 <AnonymousTemplate>
 Hello, stranger. <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">Log In</asp:HyperLink>
 </AnonymousTemplate>
 </asp:LoginView>
 <br /><br />
 </asp:ContentPlaceHolder>
 TODO: Menu will go here...
</div>