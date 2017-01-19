<asp:FormView ID="FormView1" runat="server"
  DataSourceID="ObjectDataSource1" EnableViewState="False">
    <ItemTemplate>
        <h4><%# Eval("ProductName") %>
          (<%# Eval("UnitPrice", "{0:c}") %>)</h4>
        Category: <%# Eval("CategoryName") %>;
        Supplier: <%# Eval("SupplierName") %>
    </ItemTemplate>
</asp:FormView>