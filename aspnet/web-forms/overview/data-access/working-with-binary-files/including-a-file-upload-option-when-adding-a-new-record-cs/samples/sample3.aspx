<asp:ObjectDataSource ID="CategoriesDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories" 
    TypeName="CategoriesBLL" InsertMethod="InsertWithPicture">
    <InsertParameters>
        <asp:Parameter Name="categoryName" Type="String" />
        <asp:Parameter Name="description" Type="String" />
        <asp:Parameter Name="brochurePath" Type="String" />
        <asp:Parameter Name="picture" Type="Object" />
    </InsertParameters>
</asp:ObjectDataSource>