<asp:GridView ID="Categories" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="CategoryID" DataSourceID="CategoriesDataSource" 
    EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="CategoryName" HeaderText="Category" 
            SortExpression="CategoryName" />
        <asp:BoundField DataField="Description" HeaderText="Description" 
            SortExpression="Description" />
        <asp:TemplateField HeaderText="Brochure">
            <ItemTemplate>
                <%# GenerateBrochureLink(Eval("BrochurePath")) %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ImageField DataImageUrlField="CategoryID" 
            DataImageUrlFormatString="DisplayCategoryPicture.aspx?CategoryID={0}">
        </asp:ImageField>
    </Columns>
</asp:GridView>