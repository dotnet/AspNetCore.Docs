<asp:EntityTemplate runat="server" ID="TemplateContainer1"> 
  <ItemTemplate> 
    <tr 
      <td> 
        <asp:Label ID="Label1" runat="server" OnInit="Label_Init" /> 
      </td> 
      <td> 
        <asp:DynamicControl runat="server" OnInit="DynamicControl_Init" /> 
      </td> 
    </tr> 
  </ItemTemplate> 

</asp:EntityTemplate>