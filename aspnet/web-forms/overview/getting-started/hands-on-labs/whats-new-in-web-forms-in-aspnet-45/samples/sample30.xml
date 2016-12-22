<ItemTemplate>
     <fieldset>
          <p><b><asp:Label ID="Label2" runat="server" AssociatedControlID="itemProductName">Name:</asp:Label></b></p>
          <p><asp:Label runat="server" ID="itemProductName" Text='<%#: Item.ProductName %>' /></p>
          <p><b><asp:Label ID="Label3" runat="server" AssociatedControlID="itemDescription">Description (HTML):</asp:Label></b></p>
          <p><asp:Label runat="server" ID="itemDescription" Text='<%# Item.Description %>' /></p>
          <p><b><asp:Label ID="Label4" runat="server" AssociatedControlID="itemUnitPrice">Price:</asp:Label></b></p>
          <p><asp:Label runat="server" ID="itemUnitPrice" Text='<%#: Item.UnitPrice %>' /></p>

          <p><b><asp:Label ID="Label5" runat="server" AssociatedControlID="itemUnitPrice">Image:</asp:Label></b></p>
          <p>
                <img src="<%# string.IsNullOrEmpty(Item.ImagePath) ? "/Images/noimage.jpg" : 
                Item.ImagePath %>" alt="Image" />
          </p>

          <br />
          <p>
                <asp:Button ID="Button1" runat="server" CommandName="Edit" Text="Edit" />&nbsp;
                <asp:HyperLink NavigateUrl="~/Products.aspx" Text="Back" runat="server" />
          </p>
     </fieldset>
</ItemTemplate>