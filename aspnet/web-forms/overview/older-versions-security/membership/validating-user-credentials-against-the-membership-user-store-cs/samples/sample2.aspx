<tr>
 <td align="right">
 <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email:</asp:Label>
 </td>
 <td>
 <asp:TextBox ID="Email" runat="server"></asp:TextBox>
 <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
 ControlToValidate="Email" ErrorMessage="Email is required." 
 ToolTip="Email is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
 </td>
</tr>