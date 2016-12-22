<asp:TemplateField HeaderText="Discontinued" SortExpression="Discontinued">
    <ItemTemplate>
        <asp:RadioButtonList ID="DiscontinuedChoice" runat="server"
          Enabled="False" SelectedValue='<%# Bind("Discontinued") %>'>
            <asp:ListItem Value="False">Active</asp:ListItem>
            <asp:ListItem Value="True">Discontinued</asp:ListItem>
        </asp:RadioButtonList>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:RadioButtonList ID="DiscontinuedChoice" runat="server"
            SelectedValue='<%# Bind("Discontinued") %>'>
            <asp:ListItem Value="False">Active</asp:ListItem>
            <asp:ListItem Value="True">Discontinued</asp:ListItem>
        </asp:RadioButtonList>
    </EditItemTemplate>
</asp:TemplateField>