<EditItemTemplate>
    Product name:
        <asp:TextBox ID="ProductName" runat="server"
            Text='<%# Eval("ProductName") %>'></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            ControlToValidate="ProductName"
            ErrorMessage="You must provide the product's name"
            runat="server">*</asp:RequiredFieldValidator>
    <br />
    Price:
        <asp:TextBox ID="UnitPrice" runat="server"
            Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1"
            ControlToValidate="UnitPrice"
            ErrorMessage="The price must be greater than or equal to zero
                          and cannot include the currency symbol"
            Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0"
            runat="server">*</asp:CompareValidator><br />
    <br />
    <asp:Button ID="UpdateProduct" runat="server" CommandName="Update"
        Text="Update" /> 
    <asp:Button ID="CancelUpdate" runat="server" CommandName="Cancel"
        Text="Cancel" />
</EditItemTemplate>