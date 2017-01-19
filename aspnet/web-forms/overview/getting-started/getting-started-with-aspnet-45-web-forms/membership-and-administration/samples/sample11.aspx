<asp:RegularExpressionValidator 
    ID="RegularExpressionValidator1" runat="server"
    Text="* Must be a valid price without $." ControlToValidate="AddProductPrice" 
    SetFocusOnError="True" Display="Dynamic" 
    ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$">
</asp:RegularExpressionValidator>