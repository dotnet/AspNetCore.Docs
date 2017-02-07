<fieldset>
     <p><asp:Label ID="Label2" runat="server" AssociatedControlID="ProductName">Name:</asp:Label></p>
     <p><asp:TextBox runat="server" ID="ProductName" Text='<%#: BindItem.ProductName %>' /></p>
     <p><asp:Label ID="Label3" runat="server" AssociatedControlID="Description">Description (HTML):</asp:Label></p>
     <p>
          <asp:TextBox runat="server" ID="Description" TextMode="MultiLine" Cols="60" Rows="8" Text='<%# BindItem.Description %>'
                ValidateRequestMode="Disabled" />
     </p>
     <p><asp:Label ID="Label4" runat="server" AssociatedControlID="UnitPrice">Price:</asp:Label></p>
     <p><asp:TextBox runat="server" ID="UnitPrice" Text='<%#: BindItem.UnitPrice %>' /></p>

     <p><asp:Label ID="Label1" runat="server" AssociatedControlID="ImagePath">Image URL:</asp:Label></p>
     <p><asp:TextBox runat="server" ID="ImagePath" Text='<%#:  BindItem.ImagePath %>' /></p>

     <br />
     <p>
          <asp:Button runat="server" CommandName="Update" Text="Save" />
          <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
     </p>
</fieldset>