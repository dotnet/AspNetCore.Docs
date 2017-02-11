<asp:GridView ID="Suppliers" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource">
    <Columns>
        <asp:CommandField ShowEditButton="True" />
        <asp:BoundField DataField="CompanyName" 
            HeaderText="Company" 
            SortExpression="CompanyName" />
        <asp:BoundField DataField="ContactName" 
            HeaderText="Contact Name" 
            SortExpression="ContactName" />
        <asp:BoundField DataField="ContactTitle" 
            HeaderText="Title" 
            SortExpression="ContactTitle" />
        <asp:BoundField DataField="FullContactName" 
            HeaderText="Full Contact Name"
            SortExpression="FullContactName" 
            ReadOnly="True" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="SuppliersDataSource" runat="server"
    SelectMethod="GetSuppliers" TypeName="SuppliersBLLWithSprocs" 
        UpdateMethod="UpdateSupplier">
    <UpdateParameters>
        <asp:Parameter Name="companyName" Type="String" />
        <asp:Parameter Name="contactName" Type="String" />
        <asp:Parameter Name="contactTitle" Type="String" />
        <asp:Parameter Name="supplierID" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>