<asp:GridView ID="GridView1" runat="server"
    AutoGenerateColumns="False" DataKeyNames="SupplierID"
    DataSourceID="ObjectDataSource1" EnableViewState="False">
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="SupplierID"
            DataNavigateUrlFormatString=
            "ProductsForSupplierDetails.aspx?SupplierID={0}"
            Text="View Products" />
        <asp:BoundField DataField="CompanyName"
          HeaderText="Company" SortExpression="CompanyName" />
        <asp:BoundField DataField="City" HeaderText="City"
          SortExpression="City" />
        <asp:BoundField DataField="Country" HeaderText="Country"
          SortExpression="Country" />
    </Columns>
</asp:GridView>