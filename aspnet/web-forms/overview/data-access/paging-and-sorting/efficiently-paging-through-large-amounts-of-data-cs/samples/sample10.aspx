<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
    OldValuesParameterFormatString="original_{0}" TypeName="ProductsBLL"
    SelectMethod="GetProductsPaged" EnablePaging="True"
    SelectCountMethod="TotalNumberOfProducts">
</asp:ObjectDataSource>