<ItemTemplate>
  <td runat="server">
    <table>
      <tr>
        <td>
          <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.ProductName}) %>">
            <image src='/Catalog/Images/Thumbs/<%#:Item.ImagePath%>'
              width="100" height="75" border="1" />
          </a>
        </td>
      </tr>
      <tr>
        <td>
          <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productName = Item.ProductName}) %>">
            <%#:Item.ProductName%>
          </a>
          <br />
          <span>
            <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
          </span>
          <br />
          <a href="/AddToCart.aspx?productID=<%#:Item.ProductID %>">
            <span class="ProductListItem">
              <b>Add To Cart<b>
            </span>
          </a>
        </td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
    </table>
    </p>
  </td>
</ItemTemplate>