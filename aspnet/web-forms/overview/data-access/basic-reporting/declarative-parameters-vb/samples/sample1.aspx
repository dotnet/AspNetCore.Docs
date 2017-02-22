<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
    SelectMethod="GetProductByProductID" TypeName="ProductsBLL">
    <SelectParameters>
        <asp:Parameter DefaultValue="5"
           Name="productID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>