<div id="CheckOutHeader" runat="server" class="ContentHead">
  Review and Submit Your Order
</div>
<span id="Message" runat="server"><br />     
   <asp:Label ID="LabelCartHeader" runat="server" 
              Text="Please check all the information below to be sure it&#39;s correct.">
   </asp:Label>
</span><br /> 
<asp:GridView ID="MyList" runat="server" AutoGenerateColumns="False" 
              DataKeyNames="ProductID,UnitCost,Quantity" 
              DataSourceID="EDS_Cart" 
              CellPadding="4" GridLines="Vertical" CssClass="CartListItem" 
              onrowdatabound="MyList_RowDataBound" ShowFooter="True">
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
        <%# (Convert.ToDouble(Eval("Quantity")) * Convert.ToDouble(Eval("UnitCost")))%>
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
  <FooterStyle CssClass="CartListFooter"/>
  <HeaderStyle  CssClass="CartListHead" />
</asp:GridView>   
    
<br />
<asp:imagebutton id="CheckoutBtn" runat="server" ImageURL="Styles/Images/submit.gif" 
                                  onclick="CheckoutBtn_Click">
</asp:imagebutton>
<asp:EntityDataSource ID="EDS_Cart" runat="server" 
                      ConnectionString="name=CommerceEntities" 
                      DefaultContainerName="CommerceEntities" 
                      EnableFlattening="False" 
                      EnableUpdate="True" 
                      EntitySetName="ViewCarts" 
                      AutoGenerateWhereClause="True" 
                      EntityTypeFilter="" 
                      Select="" Where="">
   <WhereParameters>
      <asp:SessionParameter Name="CartID" DefaultValue="0" 
                                          SessionField="TailSpinSpyWorks_CartID" />
   </WhereParameters>
</asp:EntityDataSource>