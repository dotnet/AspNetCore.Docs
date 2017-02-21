<asp:DropDownList ID="categories" runat="server" AutoPostBack="True"
    DataSourceID="CategoriesDataSource" DataTextField="CategoryName"
    DataValueField="CategoryID" EnableViewState="False">
 
    <asp:ListItem Value="0">-- Choose a Category --</asp:ListItem>
 
</asp:DropDownList>