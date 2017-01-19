<asp:ListView ID="ListView1" runat="server"> 
  <LayoutTemplate> 
    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder> 
  </LayoutTemplate> 
  <ItemTemplate> 
    <% Eval("LastName")%> 
  </ItemTemplate> 
</asp:ListView>