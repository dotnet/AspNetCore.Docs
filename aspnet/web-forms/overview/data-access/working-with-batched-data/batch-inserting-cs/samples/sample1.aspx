<asp:Panel ID="DisplayInterface" runat="server">
    <p>
        <asp:Button ID="ProcessShipment" runat="server" 
            Text="Process Product Shipment" /> 
    </p>
    <asp:GridView ID="ProductsGrid" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" 
        DataKeyNames="ProductID" DataSourceID="ProductsDataSource">
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Product" 
                SortExpression="ProductName" />
            <asp:BoundField DataField="CategoryName" HeaderText="Category" 
                ReadOnly="True" SortExpression="CategoryName" />
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier" 
                ReadOnly="True" SortExpression="SupplierName" />
            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" 
                HeaderText="Price" HtmlEncode="False" 
                SortExpression="UnitPrice">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" 
                SortExpression="Discontinued">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CheckBoxField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ProductsDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetProducts" TypeName="ProductsBLL">
    </asp:ObjectDataSource>
</asp:Panel>