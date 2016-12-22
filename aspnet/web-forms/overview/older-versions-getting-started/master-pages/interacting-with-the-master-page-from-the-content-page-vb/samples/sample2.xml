<asp:Label ID="GridMessage" runat="server" EnableViewState="false"></asp:Label> 
<asp:GridView ID="RecentProducts" runat="server" AutoGenerateColumns="False" 
 DataSourceID="RecentProductsDataSource">
 <Columns> 
 <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
 SortExpression="ProductName" /> 
 <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
 SortExpression="UnitPrice" /> 
 </Columns> 
</asp:GridView> 
<asp:SqlDataSource ID="RecentProductsDataSource" runat="server" 
 ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
 SelectCommand="SELECT TOP 5 ProductName, UnitPrice FROM Products ORDER BY ProductID DESC"> 
</asp:SqlDataSource>