<asp:FormView ID="Suppliers" runat="server" DataKeyNames="SupplierID"
    DataSourceID="SuppliersDataSource" EnableViewState="False" AllowPaging="True">
    <ItemTemplate>
        <h3>
            <asp:Label ID="CompanyName" runat="server"
                Text='<%# Bind("CompanyName") %>' />
        </h3>
        <b>Phone:</b>
        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
    </ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="SuppliersDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetSuppliers" TypeName="SuppliersBLL">
</asp:ObjectDataSource>