<asp:ListView ID="ListView_ProductsMenu" runat="server" DataKeyNames="CategoryID" 	DataSourceID="EDS_Category_Menu">
   <EmptyDataTemplate>No Menu Items.</EmptyDataTemplate>
   <ItemSeparatorTemplate></ItemSeparatorTemplate>
   <ItemTemplate>
      <li>
         <a href='<%# VirtualPathUtility.ToAbsolute("~/ProductsList.aspx?CategoryId=" + 
                                Eval("CategoryID")) %>'><%# Eval("CategoryName") %></a>
      </li>
   </ItemTemplate>               
   <LayoutTemplate>
      <ul ID="itemPlaceholderContainer" runat="server">
         <li runat="server" id="itemPlaceholder" />
      </ul>
      <div>
      </div>
   </LayoutTemplate>