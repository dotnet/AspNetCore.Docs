Maximum price:
$<asp:TextBox ID="MaxPrice" runat="server" Columns="5" />
 
<asp:Button ID="DisplayProductsLessThanButton" runat="server"
    Text="Display Matching Products" />
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
    DataSourceID="ProductsFilteredByPriceDataSource" EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="Product"
            SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" HeaderText="Price"
            HtmlEncode="False" DataFormatString="{0:c}"
            SortExpression="UnitPrice" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="ProductsFilteredByPriceDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
    SelectCommand=
        "SELECT ProductName, UnitPrice 
        FROM Products WHERE UnitPrice <= @MaximumPrice">
    <SelectParameters>
        <asp:ControlParameter ControlID="MaxPrice" Name="MaximumPrice"
            PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>