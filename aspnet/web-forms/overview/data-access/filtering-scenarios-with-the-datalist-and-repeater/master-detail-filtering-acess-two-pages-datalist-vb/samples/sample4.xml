<asp:DataList ID="ProductsInCategory" DataKeyField="ProductID" RepeatColumns="2"
    DataSourceID="ProductsInCategoryDataSource" EnableViewState="False"
    runat="server">
    <ItemTemplate>
        <h5><%# Eval("ProductName") %></h5>
        <p>
            Supplied by <%# Eval("SupplierName") %><br />
            <%# Eval("UnitPrice", "{0:C}") %>
        </p>
    </ItemTemplate>
</asp:DataList>
 
<asp:ObjectDataSource ID="ProductsInCategoryDataSource"
    OldValuesParameterFormatString="original_{0}" runat="server"
    SelectMethod="GetProductsByCategoryID" TypeName="ProductsBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="categoryID" QueryStringField="CategoryID"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>