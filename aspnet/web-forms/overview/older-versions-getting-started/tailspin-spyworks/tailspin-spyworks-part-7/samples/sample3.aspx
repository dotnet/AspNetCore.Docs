<asp:FormView ID="FormView1" runat="server" CellPadding="4" 
                             DataKeyNames="OrderID" 
                             DataSourceID="EDS_Order" ForeColor="#333333" Width="250px">
   <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
   <ItemTemplate>
      OrderID : <%# Eval("OrderID") %><br />
      CustomerName : <%# Eval("CustomerName") %><br />
      Order Date : <%# Eval("OrderDate") %><br />
      Ship Date : <%# Eval("ShipDate") %><br />
   </ItemTemplate>
   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
</asp:FormView>
<asp:EntityDataSource ID="EDS_Order" runat="server"  EnableFlattening="False" 
                      ConnectionString="name=CommerceEntities" 
                      DefaultContainerName="CommerceEntities" 
                      EntitySetName="Orders" 
                      AutoGenerateWhereClause="True" 
                      Where="" 
                      EntityTypeFilter="" Select="">
   <WhereParameters>
      <asp:QueryStringParameter Name="OrderID" QueryStringField="OrderID" Type="Int32" />
   </WhereParameters>
</asp:EntityDataSource>

<asp:GridView ID="GridView_OrderDetails" runat="server" 
              AutoGenerateColumns="False" 
              DataKeyNames="ProductID,UnitCost,Quantity" 
              DataSourceID="EDS_OrderDetails" 
              CellPadding="4" GridLines="Vertical" CssClass="CartListItem" 
              onrowdatabound="MyList_RowDataBound" ShowFooter="True" 
              ViewStateMode="Disabled">
   <AlternatingRowStyle CssClass="CartListItemAlt" />
   <Columns>
     <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" 
                     SortExpression="ProductID"  />
     <asp:BoundField DataField="ModelNumber" HeaderText="Model Number"  
                     SortExpression="ModelNumber" />
     <asp:BoundField DataField="ModelName" HeaderText="Model Name" 
                     SortExpression="ModelName" />
     <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" ReadOnly="True" 
                     SortExpression="UnitCost" DataFormatString="{0:c}" />
     <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" 
                     SortExpression="Quantity" />
     <asp:TemplateField> 
       <HeaderTemplate>Item Total</HeaderTemplate>
       <ItemTemplate>
         <%# (Convert.ToDouble(Eval("Quantity")) *  Convert.ToDouble(Eval("UnitCost")))%>
       </ItemTemplate>
     </asp:TemplateField>
   </Columns>
   <FooterStyle CssClass="CartListFooter"/>
   <HeaderStyle  CssClass="CartListHead" />
 </asp:GridView> 
 <asp:EntityDataSource ID="EDS_OrderDetails" runat="server" 
                       ConnectionString="name=CommerceEntities" 
                       DefaultContainerName="CommerceEntities" 
                       EnableFlattening="False" 
                       EntitySetName="VewOrderDetails" 
                       AutoGenerateWhereClause="True" 
                       Where="">
   <WhereParameters>
     <asp:QueryStringParameter Name="OrderID" QueryStringField="OrderID" Type="Int32" />
   </WhereParameters>
</asp:EntityDataSource>