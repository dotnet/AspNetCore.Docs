<asp:TemplateField HeaderText="Category" SortExpression="CategoryName">
    <EditItemTemplate>
        <asp:DropDownList ID="Categories" runat="server"
          DataSourceID="CategoriesDataSource"
          DataTextField="CategoryName" DataValueField="CategoryID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCategories" TypeName="CategoriesBLL">
        </asp:ObjectDataSource>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="Label1" runat="server"
          Text='<%# Bind("CategoryName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>