<asp:UpdatePanel ID="ProductPanel" runat="server">
 <ContentTemplate>
 <asp:DetailsView ID="ProductInfo" runat="server" AutoGenerateRows="False" 
 DataSourceID="RandomProductDataSource">
 <Fields>
 <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
 SortExpression="ProductName" />
 <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
 SortExpression="UnitPrice" />
 </Fields>
 </asp:DetailsView>
 <asp:SqlDataSource ID="RandomProductDataSource" runat="server" 
 ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" SelectCommand="SELECT TOP 1 ProductName, UnitPrice FROM Products ORDER BY NEWID()"></asp:SqlDataSource>
 </ContentTemplate>
</asp:UpdatePanel>