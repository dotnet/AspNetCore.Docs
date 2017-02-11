<div class="ContentHead">Order History</div><br />

<asp:GridView ID="GridView_OrderList" runat="server" AllowPaging="True" 
              ForeColor="#333333" GridLines="None" CellPadding="4" Width="100%" 
              AutoGenerateColumns="False" DataKeyNames="OrderID" 
              DataSourceID="EDS_Orders" AllowSorting="True" ViewStateMode="Disabled" >
  <AlternatingRowStyle BackColor="White" />
  <Columns>
    <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" 
                    SortExpression="OrderID" />
    <asp:BoundField DataField="CustomerName" HeaderText="Customer" 
                    SortExpression="CustomerName" />
    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" 
                    SortExpression="OrderDate" />
    <asp:BoundField DataField="ShipDate" HeaderText="Ship Date" 
                    SortExpression="ShipDate" />
    <asp:HyperLinkField HeaderText="Show Details" Text="Show Details" 
                 DataNavigateUrlFields="OrderID" 
                 DataNavigateUrlFormatString="~/Account/OrderDetails.aspx?OrderID={0}" />
  </Columns>
  <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
  <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
  <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
  <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
  <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
  <SortedAscendingCellStyle BackColor="#FDF5AC" />
  <SortedAscendingHeaderStyle BackColor="#4D0000" />
  <SortedDescendingCellStyle BackColor="#FCF6C0" />
  <SortedDescendingHeaderStyle BackColor="#820000" />
  <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>
  <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>
  <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>
  <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
</asp:GridView>

<asp:EntityDataSource ID="EDS_Orders" runat="server" EnableFlattening="False" 
                      AutoGenerateWhereClause="True" 
                      Where="" 
                      OrderBy="it.OrderDate DESC"
                      ConnectionString="name=CommerceEntities"  
                      DefaultContainerName="CommerceEntities" 
                      EntitySetName="Orders" >
   <WhereParameters>
      <asp:SessionParameter Name="CustomerName" SessionField="UserName" />
   </WhereParameters>
</asp:EntityDataSource>