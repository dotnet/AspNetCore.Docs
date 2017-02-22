<asp:DropDownList ID="Suppliers" runat="server" AppendDataBoundItems="True"
    DataSourceID="AllSuppliersDataSource" DataTextField="CompanyName"
    DataValueField="SupplierID">
    <asp:ListItem Value="-1">Show/Edit ALL Suppliers</asp:ListItem>
</asp:DropDownList>