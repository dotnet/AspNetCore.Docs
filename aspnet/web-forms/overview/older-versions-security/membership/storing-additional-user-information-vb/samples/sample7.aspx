<asp:LoginView ID="LoginView1" runat="server">
     <LoggedInTemplate>
          Welcome back,
          <asp:LoginName ID="LoginName1" runat="server" />.

          <br />
          <asp:HyperLink ID="lnkUpdateSettings" runat="server" 
               NavigateUrl="~/Membership/AdditionalUserInfo.aspx">
               Update Your Settings</asp:HyperLink>
     </LoggedInTemplate>
     <AnonymousTemplate>

          Hello, stranger.
     </AnonymousTemplate>
</asp:LoginView>