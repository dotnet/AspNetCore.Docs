<h4><%# Eval("CategoryName") %></h4>
<p><%# Eval("Description") %></p>
<asp:Repeater ID="ProductsByCategoryList" EnableViewState="False"
        DataSourceID="ProductsByCategoryDataSource" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><strong><%# Eval("ProductName") %></strong> -
                sold as <%# Eval("QuantityPerUnit") %> at
                <%# Eval("UnitPrice", "{0:C}") %></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="ProductsByCategoryDataSource" runat="server"
           SelectMethod="GetProductsByCategoryID" TypeName="ProductsBLL">
   <SelectParameters>
        <asp:Parameter Name="CategoryID" Type="Int32" />
   </SelectParameters>
</asp:ObjectDataSource>