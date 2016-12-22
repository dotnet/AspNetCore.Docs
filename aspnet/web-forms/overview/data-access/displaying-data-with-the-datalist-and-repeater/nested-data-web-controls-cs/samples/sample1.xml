<asp:Repeater ID="CategoryList" DataSourceID="CategoriesDataSource"
    EnableViewState="False" runat="server">
    <ItemTemplate>
        <h4><%# Eval("CategoryName") %></h4>
        <p><%# Eval("Description") %></p>
    </ItemTemplate>
    <SeparatorTemplate>
        <hr />
    </SeparatorTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCategories" TypeName="CategoriesBLL">
</asp:ObjectDataSource>