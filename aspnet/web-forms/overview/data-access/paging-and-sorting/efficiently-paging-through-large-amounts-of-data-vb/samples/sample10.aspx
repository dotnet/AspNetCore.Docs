<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsPaged"
    TypeName="ProductsBLL" EnablePaging="True" SelectCountMethod="
    TotalNumberOfProducts">
</asp:ObjectDataSource>