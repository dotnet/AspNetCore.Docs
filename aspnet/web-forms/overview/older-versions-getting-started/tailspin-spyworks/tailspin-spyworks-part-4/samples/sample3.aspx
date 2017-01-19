<asp:FormView ID="FormView_Product" runat="server" DataKeyNames="ProductID" 
                                                           DataSourceID="EDS_Product">
  <ItemTemplate>
    <div class="ContentHead"><%# Eval("ModelName") %></div><br />
      <table  border="0">
        <tr>
          <td>
            <img src='Catalog/Images/<%# Eval("ProductImage") %>'  border="0" 
                                                       alt='<%# Eval("ModelName") %>' />
          </td>
          <td><%# Eval("Description") %>
            <br /><br /><br />                  
          </td>
        </tr>
      </table>
      <span class="UnitCost"><b>Your Price:</b> <%# Eval("UnitCost", "{0:c}")%> 
      <br /> 
      <span class="ModelNumber">
        <b>Model Number:</b> <%# Eval("ModelNumber") %>
      </span><br />
      <a href='AddToCart.aspx?ProductID=
        <%# Eval("ProductID") %>'> 
        <img id="Img1" src="~/Styles/Images/add_to_cart.gif" runat="server" 
             alt="" />
      </a>
      <br /><br />      
    </ItemTemplate>
  </asp:FormView>
  <asp:EntityDataSource ID="EDS_Product" runat="server" AutoGenerateWhereClause="True"  
                        EnableFlattening="False" 
                        ConnectionString="name=CommerceEntities" 
                        DefaultContainerName="CommerceEntities" 
                        EntitySetName="Products" 
                        EntityTypeFilter="" 
                        Select="" Where="">
    <WhereParameters>
      <asp:QueryStringParameter Name="ProductID" 
                                QueryStringField="productID"  Type="Int32" />
    </WhereParameters>
  </asp:EntityDataSource>