<asp:CommandField ShowEditButton="True" ValidationGroup="EditValidationControls" />
<asp:TemplateField HeaderText="ProductName"
  SortExpression="ProductName">
    <EditItemTemplate>
        <asp:TextBox ID="EditProductName" runat="server"
          Text='<%# Bind("ProductName") %>'>
        </asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            runat="server" ControlToValidate="EditProductName"
            ErrorMessage="You must provide the product name"
            ValidationGroup="EditValidationControls">*
        </asp:RequiredFieldValidator>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="Label1" runat="server"
          Text='<%# Bind("ProductName") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnitPrice" SortExpression="UnitPrice">
    <EditItemTemplate>
        <asp:TextBox ID="EditUnitPrice" runat="server"
          Text='<%# Bind("UnitPrice", "{0:n2}") %>' Columns="6"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server"
            ControlToValidate="EditUnitPrice"
            ErrorMessage="The price must be greater than or equal to zero and
                           cannot include the currency symbol"
            Operator="GreaterThanEqual" Type="Currency"
            ValueToCompare="0"
            ValidationGroup="EditValidationControls">*
        </asp:CompareValidator>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="Label2" runat="server"
            Text='<%# Bind("UnitPrice", "{0:c}") %>'>
        </asp:Label>
    </ItemTemplate>
</asp:TemplateField>