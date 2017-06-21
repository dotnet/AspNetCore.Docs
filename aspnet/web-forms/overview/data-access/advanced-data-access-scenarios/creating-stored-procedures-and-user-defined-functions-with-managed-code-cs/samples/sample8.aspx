<asp:GridView ID="DiscontinuedProducts" runat="server" 
    AutoGenerateColumns="False" DataKeyNames="ProductID" 
    DataSourceID="DiscontinuedProductsDataSource">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
            SortExpression="ProductName" />
        <asp:CheckBoxField DataField="Discontinued" 
            HeaderText="Discontinued" 
            SortExpression="Discontinued" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="DiscontinuedProductsDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetDiscontinuedProducts" TypeName="ProductsBLLWithSprocs">
</asp:ObjectDataSource>