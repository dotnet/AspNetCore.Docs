<asp:TemplateField HeaderText="ProductName"
  SortExpression="ProductName">
    <InsertItemTemplate>
        <asp:TextBox ID="InsertProductName" runat="server"
         Text='<%# Bind("ProductName") %>'></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
          runat="server" ControlToValidate="InsertProductName"
            ErrorMessage="You must provide the product name"
            ValidationGroup="InsertValidationControls">*
        </asp:RequiredFieldValidator>
    </InsertItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnitPrice" SortExpression="UnitPrice">
    <InsertItemTemplate>
         <asp:TextBox ID="InsertUnitPrice" runat="server"
           Text='<%# Bind("UnitPrice") %>' Columns="6">
         </asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
           runat="server" ControlToValidate="InsertUnitPrice"
            ErrorMessage="You must provide the product price"
            ValidationGroup="InsertValidationControls">*
         </asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server"
           ControlToValidate="InsertUnitPrice"
           ErrorMessage="The price must be greater than or equal to zero and
                          cannot include the currency symbol"
           Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0"
           ValidationGroup="InsertValidationControls">*
        </asp:CompareValidator>
     </InsertItemTemplate>
 </asp:TemplateField>
<asp:CommandField ShowInsertButton="True"
  ValidationGroup="InsertValidationControls" />