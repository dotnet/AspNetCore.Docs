<asp:GridView ID="Suppliers" runat="server" AutoGenerateColumns="False"
    DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource" 
    EnableViewState="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector" runat="server" 
                    GroupName="SuppliersGroup" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CompanyName" HeaderText="Supplier" 
            SortExpression="CompanyName" />
        <asp:BoundField DataField="City" HeaderText="City" 
            SortExpression="City" />
        <asp:BoundField DataField="Country" HeaderText="Country" 
            SortExpression="Country" />
    </Columns>
</asp:GridView>