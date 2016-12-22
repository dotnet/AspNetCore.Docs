<asp:FormView ID="Suppliers" runat="server" DataKeyNames="SupplierID"
    DataSourceID="SuppliersDataSource" EnableViewState="False"
    AllowPaging="True">
    <ItemTemplate>
        <h3><asp:Label ID="CompanyName" runat="server"
            Text='<%# Bind("CompanyName") %>'></asp:Label></h3>
        <b>Phone:</b>
        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
        <br />
        <asp:Button ID="DiscontinueAllProductsForSupplier" runat="server"
            CommandName="DiscontinueProducts" Text="Discontinue All Products"
            OnClientClick="return confirm('This will mark _all_ of this supplier\'s
                products as discontinued. Are you certain you want to do this?');" />
    </ItemTemplate>
</asp:FormView>