<asp:FormView ID="FormView1" runat="server" DataKeyNames="CategoryID"
    DataSourceID="CategoryDataSource" EnableViewState="False" Width="100%">
    <ItemTemplate>
        <h3>
            <asp:Label ID="CategoryNameLabel" runat="server"
                Text='<%# Bind("CategoryName") %>' />
        </h3>
        <p>
            <asp:Label ID="DescriptionLabel" runat="server"
                Text='<%# Bind("Description") %>' />
        </p>
    </ItemTemplate>
</asp:FormView>
 
<asp:ObjectDataSource ID="CategoryDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCategoryByCategoryID" TypeName="CategoriesBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="categoryID" Type="Int32"
            QueryStringField="CategoryID" />
    </SelectParameters>
</asp:ObjectDataSource>