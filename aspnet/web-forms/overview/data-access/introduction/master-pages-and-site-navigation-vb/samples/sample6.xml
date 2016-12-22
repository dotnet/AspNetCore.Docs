<div id="navigation">
    <ul>
        <li><asp:HyperLink runat="server" ID="lnkHome"
         NavigateUrl="~/Default.aspx">Home</asp:HyperLink></li>

        <asp:Repeater runat="server" ID="menu"
          DataSourceID="SiteMapDataSource1">
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server"
                    NavigateUrl='<%# Eval("Url") %>'>
                    <%# Eval("Title") %></asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <asp:SiteMapDataSource ID="SiteMapDataSource1"
      runat="server" ShowStartingNode="false" />
</div>