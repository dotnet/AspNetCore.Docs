<asp:ObjectDataSource ID="ProductsOptimisticConcurrencyDataSource" runat="server"
    DeleteMethod="DeleteProduct" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProducts" TypeName="ProductsOptimisticConcurrencyBLL"
    UpdateMethod="UpdateProduct">
    <DeleteParameters>
        <asp:Parameter Name="original_productID" Type="Int32" />
        <asp:Parameter Name="original_productName" Type="String" />
        <asp:Parameter Name="original_supplierID" Type="Int32" />
        <asp:Parameter Name="original_categoryID" Type="Int32" />
        <asp:Parameter Name="original_quantityPerUnit" Type="String" />
        <asp:Parameter Name="original_unitPrice" Type="Decimal" />
        <asp:Parameter Name="original_unitsInStock" Type="Int16" />
        <asp:Parameter Name="original_unitsOnOrder" Type="Int16" />
        <asp:Parameter Name="original_reorderLevel" Type="Int16" />
        <asp:Parameter Name="original_discontinued" Type="Boolean" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="productName" Type="String" />
        <asp:Parameter Name="supplierID" Type="Int32" />
        <asp:Parameter Name="categoryID" Type="Int32" />
        <asp:Parameter Name="quantityPerUnit" Type="String" />
        <asp:Parameter Name="unitPrice" Type="Decimal" />
        <asp:Parameter Name="unitsInStock" Type="Int16" />
        <asp:Parameter Name="unitsOnOrder" Type="Int16" />
        <asp:Parameter Name="reorderLevel" Type="Int16" />
        <asp:Parameter Name="discontinued" Type="Boolean" />
        <asp:Parameter Name="productID" Type="Int32" />
        <asp:Parameter Name="original_productName" Type="String" />
        <asp:Parameter Name="original_supplierID" Type="Int32" />
        <asp:Parameter Name="original_categoryID" Type="Int32" />
        <asp:Parameter Name="original_quantityPerUnit" Type="String" />
        <asp:Parameter Name="original_unitPrice" Type="Decimal" />
        <asp:Parameter Name="original_unitsInStock" Type="Int16" />
        <asp:Parameter Name="original_unitsOnOrder" Type="Int16" />
        <asp:Parameter Name="original_reorderLevel" Type="Int16" />
        <asp:Parameter Name="original_discontinued" Type="Boolean" />
        <asp:Parameter Name="original_productID" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>