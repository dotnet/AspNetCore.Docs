<asp:ObjectDataSource ID="ProductsDataSource" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProducts" TypeName="ProductsBLL">
</asp:ObjectDataSource>