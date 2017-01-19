<asp:Repeater runat="server" ID="ProductsByCategoryList" EnableViewState="False"
      DataSource='<%# GetProductsInCategory(CType(Eval("CategoryID"), Integer)) %>'>
  ...
</asp:Repeater>