<asp:TemplateField> 
      <HeaderTemplate>Quantity</HeaderTemplate>
      <ItemTemplate>
         <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" 
                      Text='<%# Bind("Quantity") %>'></asp:TextBox> 
      </ItemTemplate>
    </asp:TemplateField>