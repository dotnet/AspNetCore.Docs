<asp:Label runat="server" AssociatedControlID="categories"
Text="Select a category to show products for: " />
<asp:DropDownList runat="server" ID="categories"
SelectMethod="GetCategories" AppendDataBoundItems="true"
DataTextField="CategoryName" DataValueField="CategoryID"
AutoPostBack="true">
  <asp:ListItem Value="" Text="- all -" />
</asp:DropDownList>