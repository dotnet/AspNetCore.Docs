<asp:ObjectDataSource ID="AllSuppliersDataSource" runat="server"
    SelectMethod="GetSuppliers" TypeName="SuppliersBLL"
    UpdateMethod="UpdateSupplierAddress">
    <UpdateParameters>
        <asp:Parameter Name="supplierID" Type="Int32" />
        <asp:Parameter Name="address" Type="String" />
        <asp:Parameter Name="city" Type="String" />
        <asp:Parameter Name="country" Type="String" />
    </UpdateParameters>
</asp:ObjectDataSource>
<asp:DetailsView ID="SupplierDetails" runat="server" AllowPaging="True"
    AutoGenerateRows="False" DataKeyNames="SupplierID"
    DataSourceID="AllSuppliersDataSource">
    <Fields>
        <asp:BoundField DataField="CompanyName" HeaderText="Company"
            ReadOnly="True" SortExpression="CompanyName" />
        <asp:BoundField DataField="Address" HeaderText="Address"
            SortExpression="Address" />
        <asp:BoundField DataField="City" HeaderText="City"
            SortExpression="City" />
        <asp:BoundField DataField="Country" HeaderText="Country"
            SortExpression="Country" />
        <asp:BoundField DataField="Phone" HeaderText="Phone" ReadOnly="True"
            SortExpression="Phone" />
        <asp:CommandField ShowEditButton="True" />
    </Fields>
</asp:DetailsView>