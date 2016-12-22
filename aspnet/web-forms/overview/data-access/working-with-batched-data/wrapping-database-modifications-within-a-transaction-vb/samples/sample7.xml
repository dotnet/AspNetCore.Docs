<asp:GridView ID="Products" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataKeyNames="ProductID" 
    DataSourceID="ProductsDataSource">
    <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ProductID" 
            InsertVisible="False" ReadOnly="True" 
            SortExpression="ProductID" />
        <asp:BoundField DataField="ProductName" HeaderText="Product" 
            SortExpression="ProductName" />
        <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
            SortExpression="CategoryID" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category" 
            SortExpression="CategoryName" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ProductsDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProducts" TypeName="ProductsBLL">
</asp:ObjectDataSource>