<EditItemTemplate>
    <asp:TextBox ID="EditUnitPrice" runat="server"
      Text='<%# Bind("UnitPrice", "{0:c}") %>'
      Columns="6"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator1" runat="server"
        ControlToValidate="EditUnitPrice"
        ErrorMessage="The price must be greater than or equal to zero and
                       cannot include the currency symbol"
        Operator="GreaterThanEqual" Type="Currency"
        ValueToCompare="0">*</asp:CompareValidator>
</EditItemTemplate>