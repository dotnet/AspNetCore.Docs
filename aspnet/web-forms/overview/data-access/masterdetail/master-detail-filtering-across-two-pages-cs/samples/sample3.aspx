<asp:FormView ID="FormView1" runat="server" DataKeyNames="SupplierID"
    DataSourceID="suppliersDataSource" EnableViewState="False">
    <ItemTemplate>
        <h3><%# Eval("CompanyName") %></h3>
        <p>
            <asp:Label ID="AddressLabel" runat="server"
                Text='<%# Bind("Address") %>'></asp:Label><br />
            <asp:Label ID="CityLabel" runat="server"
                Text='<%# Bind("City") %>'></asp:Label>,
            <asp:Label ID="CountryLabel" runat="server"
                Text='<%# Bind("Country") %>'></asp:Label><br />
            Phone:
            <asp:Label ID="PhoneLabel" runat="server"
                Text='<%# Bind("Phone") %>'></asp:Label>
        </p>
    </ItemTemplate>
</asp:FormView>