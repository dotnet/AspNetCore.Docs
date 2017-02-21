<asp:GridView ID="HighlightCheapProducts" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="ObjectDataSource1"
    EnableViewState="False" runat="server">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="Product"
          SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category"
          ReadOnly="True" SortExpression="CategoryName" />
        <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}"
          HeaderText="Price"
            HtmlEncode="False" SortExpression="UnitPrice" />
    </Columns>
</asp:GridView>