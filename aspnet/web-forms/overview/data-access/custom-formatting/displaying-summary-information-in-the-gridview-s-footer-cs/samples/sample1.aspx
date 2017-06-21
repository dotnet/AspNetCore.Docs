<asp:GridView ID="ProductsInCategory" runat="server"
    AutoGenerateColumns="False" DataKeyNames="ProductID"
    DataSourceID="ProductsInCategoryDataSource" EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="Product"
          SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}"
            HeaderText="Price"
            HtmlEncode="False" SortExpression="UnitPrice">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="UnitsInStock"
         HeaderText="Units In Stock" SortExpression="UnitsInStock">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="UnitsOnOrder"
           HeaderText="Units On Order" SortExpression="UnitsOnOrder">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
</asp:GridView>