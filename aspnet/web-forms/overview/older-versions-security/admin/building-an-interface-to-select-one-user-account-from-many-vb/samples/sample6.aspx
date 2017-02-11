<asp:Repeater ID="FilteringUI" runat="server">
 <ItemTemplate>
 <asp:LinkButton runat="server" ID="lnkFilter" 
 Text='<%# Container.DataItem %>'
 CommandName='<%# Container.DataItem %>'></asp:LinkButton>
 </ItemTemplate>
 <SeparatorTemplate>|</SeparatorTemplate>
</asp:Repeater>