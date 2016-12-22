<asp:GridView ID="SuppliersProducts" runat="server" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="SuppliersProductsDataSource"
    EnableViewState="False">
    <Columns>
        <asp:ButtonField ButtonType="Button" CommandName="IncreasePrice"
            Text="Price +10%" />
        <asp:ButtonField ButtonType="Button" CommandName="DecreasePrice"
            Text="Price -10%" />
        <asp:BoundField DataField="ProductName" HeaderText="Product"
            SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" HeaderText="Price"
            SortExpression="UnitPrice" DataFormatString="{0:C}"
            HtmlEncode="False" />
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued"
            SortExpression="Discontinued" />
    </Columns>
</asp:GridView>