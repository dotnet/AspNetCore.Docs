<asp:ListView ID="categoryList"  
    ItemType="WingtipToys.Models.Category" 
    runat="server"
    SelectMethod="GetCategories" >
    <ItemTemplate>
        <b style="font-size: large; font-style: normal">
        <a href="<%#: GetRouteUrl("ProductsByCategoryRoute", new {categoryName = Item.CategoryName}) %>">
            <%#: Item.CategoryName %>
        </a>
        </b>
    </ItemTemplate>
    <ItemSeparatorTemplate>  |  </ItemSeparatorTemplate>
</asp:ListView>