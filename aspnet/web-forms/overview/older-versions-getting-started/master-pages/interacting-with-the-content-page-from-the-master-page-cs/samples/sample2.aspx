<asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="False" 
 DataSourceID="ProductsDataSource">
 <Columns>
 <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
 SortExpression="ProductName" />
 <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
 SortExpression="UnitPrice" />
 </Columns>
</asp:GridView>

<asp:SqlDataSource ID="ProductsDataSource" runat="server" 
 ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
 SelectCommand="SELECT [ProductName], [UnitPrice] FROM [Products]">
</asp:SqlDataSource>