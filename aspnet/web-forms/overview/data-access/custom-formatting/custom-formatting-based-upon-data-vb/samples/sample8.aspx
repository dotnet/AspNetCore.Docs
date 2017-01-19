<asp:FormView ID="LowStockedProductsInRed" runat="server"
    DataKeyNames="ProductID" DataSourceID="ObjectDataSource1"
    AllowPaging="True" EnableViewState="False">
    <ItemTemplate>
        <b>Product:</b>
        <asp:Label ID="ProductNameLabel" runat="server"
         Text='<%# Bind("ProductName") %>'>
        </asp:Label><br />
        <b>Units In Stock:</b>
        <asp:Label ID="UnitsInStockLabel" runat="server"
          Text='<%# Bind("UnitsInStock") %>'>
        </asp:Label>
    </ItemTemplate>
</asp:FormView>