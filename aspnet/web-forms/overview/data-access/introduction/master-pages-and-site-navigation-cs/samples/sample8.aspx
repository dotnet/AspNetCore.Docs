<asp:Repeater runat="server" ID="menu" DataSourceID="SiteMapDataSource1">
    <ItemTemplate>
        <li>
            <asp:HyperLink runat="server"
             NavigateUrl='<%# Eval("Url") %>'>
             <%# Eval("Title") %></asp:HyperLink>

            <asp:Repeater runat="server"
                DataSource='<%# ((SiteMapNode) Container.DataItem).ChildNodes %>'>
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>

                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server"
                         NavigateUrl='<%# Eval("Url") %>'>
                         <%# Eval("Title") %></asp:HyperLink>
                    </li>
                </ItemTemplate>

                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </li>
    </ItemTemplate>
</asp:Repeater>