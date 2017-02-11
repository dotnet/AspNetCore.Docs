<asp:Repeater ID="Categories" DataSourceID="CategoriesDataSource"
    runat="server">
    <ItemTemplate>
        <h3><%# Eval("CategoryName") %></h3>
        <p>
            <%# Eval("Description") %>
            [<asp:LinkButton runat="server" ID="ShowProducts">
                Show Products</asp:LinkButton>]
        </p>
    </ItemTemplate>
    <SeparatorTemplate><hr /></SeparatorTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCategories" TypeName="CategoriesBLL">
</asp:ObjectDataSource>