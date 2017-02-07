<asp:GridView ID="productsGrid"
runat="server" DataKeyNames="ProductID"
AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false"
SelectMethod="GetProducts" >
<Columns>
 	   <asp:BoundField DataField="ProductID" HeaderText="ID" />
 	   <asp:BoundField DataField="ProductName" HeaderText="Name"				  
 			SortExpression="ProductName" />
 	   <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" 
 			SortExpression="UnitPrice" />
 	   <asp:BoundField DataField="UnitsInStock" HeaderText="# in Stock" 
 			SortExpression="UnitsInStock" />
</Columns>
<EmptyDataTemplate>
 		No products matching the filter criteria were found</EmptyDataTemplate>
</asp:GridView>