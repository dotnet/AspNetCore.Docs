<ul> 
 <li> 
 <asp:HyperLink runat="server" ID="lnkHome" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
 </li> 
 <asp:Repeater runat="server" ID="menu" DataSourceID="SiteMapDataSource1"> 
 <ItemTemplate>
 <li> 
 <asp:HyperLink ID="lnkMenuItem" runat="server" 
 NavigateUrl='<%# Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink>
 <asp:Repeater ID="submenu" runat="server" DataSource="<%# 
 CType(Container.DataItem, SiteMapNode).ChildNodes %>"> 
 <HeaderTemplate> 
 <ul> 
 </HeaderTemplate> 
 <ItemTemplate>
 <li> 
 <asp:HyperLink ID="lnkMenuItem" 
 runat="server" NavigateUrl='<%#  Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink> 
 </li>
 </ItemTemplate> 
 <FooterTemplate> 
 </ul> 
 </FooterTemplate>
 </asp:Repeater> 
 </li> 
 </ItemTemplate> 
 </asp:Repeater> 
</ul>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false"/>