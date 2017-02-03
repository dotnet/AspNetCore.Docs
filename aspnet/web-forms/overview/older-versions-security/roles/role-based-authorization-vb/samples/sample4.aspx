<asp:TemplateField HeaderText="Email">
     <ItemTemplate>
          <asp:Label runat="server" ID="Label1" Text='<%# Eval("Email")%>'></asp:Label>

     </ItemTemplate>
     <EditItemTemplate>
          <asp:TextBox runat="server" ID="Email" Text='<%# Bind("Email")%>'></asp:TextBox>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
               ControlToValidate="Email" Display="Dynamic"
               ErrorMessage="You must provide an email address."
               SetFocusOnError="True">*</asp:RequiredFieldValidator>

          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
               ControlToValidate="Email" Display="Dynamic"
               ErrorMessage="The email address you have entered is not valid. Please fix 
               this and try again."
               SetFocusOnError="True"

               ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*
          </asp:RegularExpressionValidator>
     </EditItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Comment">
     <ItemTemplate>
          <asp:Label runat="server" ID="Label2" Text='<%# Eval("Comment")%>'></asp:Label>

     </ItemTemplate>
     <EditItemTemplate>
          <asp:TextBox runat="server" ID="Comment" TextMode="MultiLine"
               Columns="40" Rows="4" Text='<%# Bind("Comment")%>'>

          </asp:TextBox>
     </EditItemTemplate>
</asp:TemplateField>