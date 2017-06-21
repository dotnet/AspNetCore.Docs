<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  ...
  <ul>
    <asp:Repeater ID="customersRepeater" ItemType="WebFormsLab.Model.Customer" runat="server">
      <ItemTemplate>
        <li>
          <a href="CustomerDetails.aspx?id=<%#: Item.Id %>">
            <%#: Item.FirstName %> <%#: Item.LastName %>
          </a>
        </li>
      </ItemTemplate>
    </asp:Repeater>
  </ul>
  <a href="CustomerDetails.aspx">Add a New Customer</a>
</asp:Content>