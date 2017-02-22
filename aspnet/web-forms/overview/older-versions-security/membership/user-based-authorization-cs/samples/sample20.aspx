<asp:TemplateField ShowHeader="False">
 <ItemTemplate>
 <asp:LoginView ID="LoginView1" runat="server">
 <LoggedInTemplate>
 <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
 CommandName="Select" Text="View"></asp:LinkButton>
 </LoggedInTemplate>
 </asp:LoginView>
 </ItemTemplate>
</asp:TemplateField>