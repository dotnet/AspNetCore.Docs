<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource2"
    EnableViewState="False">
    <HeaderTemplate>
        <table>
            <tr>
    </HeaderTemplate>
    <ItemTemplate>
                <td><%# Eval("CategoryName") %></td>
    </ItemTemplate>
    <FooterTemplate>
            </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>