<asp:Repeater ID="ProductsByCategoryList" EnableViewState="False"
    runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><strong><%# Eval("ProductName") %></strong>
            (<%# Eval("UnitPrice", "{0:C}") %>)</li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>