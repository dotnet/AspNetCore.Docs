<p>
    <asp:GridView ID="Products" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ProductID" DataSourceID="ProductsDataSource" 
        AllowPaging="True" EnableViewState="False">
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Product" 
                SortExpression="ProductName" />
            <asp:BoundField DataField="CategoryName" HeaderText="Category" 
                ReadOnly="True" SortExpression="CategoryName" />
            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" 
                HeaderText="Price" HtmlEncode="False" 
                SortExpression="UnitPrice" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ProductsDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetProducts" TypeName="ProductsBLL">            
    </asp:ObjectDataSource>
</p>
<p>
    <asp:Button ID="DeleteSelectedProducts" runat="server" 
        Text="Delete Selected Products" />
</p>
<p>
    <asp:Label ID="DeleteResults" runat="server" EnableViewState="False" 
        Visible="False"></asp:Label>
</p>