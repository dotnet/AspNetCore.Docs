<asp:DataList ID="CategoryProducts" runat="server" DataKeyField="ProductID"
    DataSourceID="CategoryProductsDataSource" RepeatColumns="2"
    EnableViewState="False">
    <ItemTemplate>
        <h5><%# Eval("ProductName") %></h5>
        <p>
            Supplied by <%# Eval("SupplierName") %><br />
            <%# Eval("UnitPrice", "{0:C}") %>
        </p>
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="CategoryProductsDataSource"
    OldValuesParameterFormatString="original_{0}"  runat="server"
    SelectMethod="GetProductsByCategoryID" TypeName="ProductsBLL">
    <SelectParameters>
        <asp:Parameter Name="categoryID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>