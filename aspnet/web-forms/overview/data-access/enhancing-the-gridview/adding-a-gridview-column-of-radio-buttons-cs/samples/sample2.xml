<asp:GridView ID="Suppliers" runat="server" AutoGenerateColumns="False"
    DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource" 
    EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="CompanyName" HeaderText="Supplier" 
            SortExpression="CompanyName" />
        <asp:BoundField DataField="City" HeaderText="City" 
            SortExpression="City" />
        <asp:BoundField DataField="Country" HeaderText="Country" 
            SortExpression="Country" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="SuppliersDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetSuppliersByCountry" TypeName="SuppliersBLL">
    <SelectParameters>
        <asp:Parameter DefaultValue="USA" Name="country" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>