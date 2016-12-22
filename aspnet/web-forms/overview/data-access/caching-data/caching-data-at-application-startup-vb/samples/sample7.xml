<asp:GridView ID="Suppliers" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="SupplierID" DataSourceID="SuppliersCachedDataSource" 
    EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" 
            InsertVisible="False" ReadOnly="True" 
            SortExpression="SupplierID" />
        <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
            SortExpression="CompanyName" />
        <asp:BoundField DataField="Address" HeaderText="Address" 
            SortExpression="Address" />
        <asp:BoundField DataField="City" HeaderText="City" 
            SortExpression="City" />
        <asp:BoundField DataField="Country" HeaderText="Country" 
            SortExpression="Country" />
        <asp:BoundField DataField="Phone" HeaderText="Phone" 
            SortExpression="Phone" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="SuppliersCachedDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetSuppliers" TypeName="StaticCache" />