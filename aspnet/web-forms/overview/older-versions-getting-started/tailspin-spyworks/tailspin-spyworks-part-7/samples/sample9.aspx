<asp:ListView ID="ListView_Comments" runat="server" 
              DataKeyNames="ReviewID,ProductID,Rating" DataSourceID="EDS_CommentsList">
  <ItemTemplate>
    <tr>
      <td><%# Eval("CustomerName") %></td>
      <td>
        <img src='Styles/Images/ReviewRating_d<%# Eval("Rating") %>.gif' alt="">
        <br />
      </td>
      <td>
        <%# Eval("Comments") %>
      </td>
    </tr>
  </ItemTemplate>
  <AlternatingItemTemplate>
    <tr>
      <td><%# Eval("CustomerName") %></td>
      <td>
        <img src='Styles/Images/ReviewRating_da<%# Eval("Rating") %>.gif' alt="">
        <br />
      </td>
      <td><%# Eval("Comments") %></td>
    </tr>
  </AlternatingItemTemplate>
   <EmptyDataTemplate>
     <table runat="server">
       <tr><td>There are no reviews yet for this product.</td></tr>
     </table>
  </EmptyDataTemplate>
  <LayoutTemplate>
    <table runat="server">
      <tr runat="server">
        <td runat="server">
          <table ID="itemPlaceholderContainer" runat="server" border="1">
            <tr runat="server">
              <th runat="server">Customer</th>
              <th runat="server">Rating</th>
              <th runat="server">Comments</th>
             </tr>
             <tr ID="itemPlaceholder" runat="server"></tr>
           </table>
         </td>
       </tr>
       <tr runat="server">
         <td runat="server">
           <asp:DataPager ID="DataPager1" runat="server">
             <Fields>
               <asp:NextPreviousPagerField ButtonType="Button" 
                                           ShowFirstPageButton="True"
                                           ShowLastPageButton="True" />
             </Fields>
           </asp:DataPager>
         </td>
       </tr>
     </table>
  </LayoutTemplate>
</asp:ListView>
<asp:EntityDataSource ID="EDS_CommentsList" runat="server"  EnableFlattening="False" 
                       AutoGenerateWhereClause="True" 
                       EntityTypeFilter="" 
                       Select="" Where=""
                       ConnectionString="name=CommerceEntities" 
                       DefaultContainerName="CommerceEntities" 
                       EntitySetName="Reviews">
   <WhereParameters>
    <asp:QueryStringParameter Name="ProductID" QueryStringField="productID"  
                                               Type="Int32" />
  </WhereParameters>
</asp:EntityDataSource>