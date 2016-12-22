<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1"
    EnableViewState="False">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
 
    <ItemTemplate>
        <li><%# Eval("CategoryName") %> - <%# Eval("Description") %></li>
    </ItemTemplate>
 
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
 
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCategories" TypeName="CategoriesBLL">
</asp:ObjectDataSource>