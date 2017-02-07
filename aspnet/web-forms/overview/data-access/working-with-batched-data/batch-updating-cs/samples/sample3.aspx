<asp:DropDownList ID="Categories" runat="server" AppendDataBoundItems="True" 
    DataSourceID="CategoriesDataSource" DataTextField="CategoryName" 
    DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>'>
    <asp:ListItem Value=">-- Select One --</asp:ListItem>
</asp:DropDownList>