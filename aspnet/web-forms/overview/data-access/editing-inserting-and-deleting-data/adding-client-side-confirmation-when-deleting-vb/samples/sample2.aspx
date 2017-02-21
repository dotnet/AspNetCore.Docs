<asp:FormView ID="FormView1" AllowPaging="True" DataKeyNames="ProductID"
    DataSourceID="ObjectDataSource1" runat="server">
    <ItemTemplate>
        <h3><i><%# Eval("ProductName") %></i></h3>
        <b>Category:</b>
        <asp:Label ID="CategoryNameLabel" runat="server"
            Text='<%# Eval("CategoryName") %>'>
        </asp:Label><br />
        <b>Supplier:</b>
        <asp:Label ID="SupplierNameLabel" runat="server"
            Text='<%# Eval("SupplierName") %>'>
        </asp:Label><br />
        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False"
            CommandName="Delete" Text="Delete">
        </asp:LinkButton>
    </ItemTemplate>
</asp:FormView>