---
title: "Part 7: Creating the Main Page | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 07/04/2012
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/older-versions/using-web-api-1-with-entity-framework-5/using-web-api-with-entity-framework-part-7
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\older-versions\using-web-api-1-with-entity-framework-5\using-web-api-with-entity-framework-part-7.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/42626) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/older-versions/using-web-api-1-with-entity-framework-5/using-web-api-with-entity-framework-part-7.html) | [View prod content](http://www.asp.net/web-api/overview/older-versions/using-web-api-1-with-entity-framework-5/using-web-api-with-entity-framework-part-7) | Picker: 42627

Part 7: Creating the Main Page
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](http://code.msdn.microsoft.com/ASP-NET-Web-API-with-afa30545)

## Creating the Main Page

In this section, you will create the main application page. This page will be more complex than the Admin page, so we'll approach it in several steps. Along the way, you'll see some more advanced Knockout.js techniques. Here is the basic layout of the page:

![](using-web-api-with-entity-framework-part-7/_static/image1.png)

- "Products" holds an array of products.
- "Cart" holds an array of products with quantities. Clicking "Add to Cart" updates the cart.
- "Orders" holds an array of order IDs.
- "Details" holds an order detail, which is an array of items (products with quantities)

We'll start by defining some basic layout in HTML, with no data binding or script. Open the file Views/Home/Index.cshtml and replace all of the contents with the following:

    <div class="content">
        <!-- List of products -->
        <div class="float-left">
        <h1>Products</h1>
        <ul id="products">
        </ul>
        </div>
    
        <!-- Cart -->
        <div id="cart" class="float-right">
        <h1>Your Cart</h1>
            <table class="details ui-widget-content">
        </table>
        <input type="button" value="Create Order"/>
        </div>
    </div>
    
    <div id="orders-area" class="content" >
        <!-- List of orders -->
        <div class="float-left">
        <h1>Your Orders</h1>
        <ul id="orders">
        </ul>
        </div>
    
       <!-- Order Details -->
        <div id="order-details" class="float-right">
        <h2>Order #<span></span></h2>
        <table class="details ui-widget-content">
        </table>
        <p>Total: <span></span></p>
        </div>
    </div>

Next, add a Scripts section and create an empty view-model:

    @section Scripts {
      <script type="text/javascript" src="@Url.Content("~/Scripts/knockout-2.1.0.js")"></script>
      <script type="text/javascript">
    
        function AppViewModel() {
            var self = this;
            self.loggedIn = @(Request.IsAuthenticated ? "true" : "false");
        }
    
        $(document).ready(function () {
            ko.applyBindings(new AppViewModel());
        });
    
      </script>
    }

Based on the design sketched earlier, our view model needs observables for products, cart, orders, and details. Add the following variables to the `AppViewModel` object:

    self.products = ko.observableArray();
    self.cart = ko.observableArray();
    self.orders = ko.observableArray();
    self.details = ko.observable();

Users can add items from the products list into the cart, and remove items from the cart. To encapsulate these functions, we'll create another view-model class that represents a product. Add the following code to `AppViewModel`:

[!code[Main](using-web-api-with-entity-framework-part-7/samples/sample1.xml?highlight=4)]

The `ProductViewModel` class contains two functions that are used to move the product to and from the cart: `addItemToCart` adds one unit of the product to the cart, and `removeAllFromCart` removes all quantities of the product.

Users can select an existing order and get the order details. We'll encapsulate this functionality into another view-model:

[!code[Main](using-web-api-with-entity-framework-part-7/samples/sample2.xml?highlight=4)]

The `OrderDetailsViewModel` is initialized with an order, and it fetches the order details by sending an AJAX request to the server.

Also, notice the `total` property on the `OrderDetailsViewModel`. This property is a special kind of observable called a [computed observable](http://knockoutjs.com/documentation/computedObservables.html). As the name implies, a computed observable lets you data bind to a computed value&#8212;in this case, the total cost of the order.

Next, add these functions to `AppViewModel`:

- `resetCart` removes all items from the cart.
- `getDetails` gets the details for an order (by pusing a new `OrderDetailsViewModel` onto the `details` list).
- `createOrder` creates a new order and empties the cart.


[!code[Main](using-web-api-with-entity-framework-part-7/samples/sample3.xml?highlight=4)]

Finally, initialize the view model by making AJAX requests for the products and orders:

    function AppViewModel() {
        // ...
    
        // NEW CODE
        // Initialize the view-model.
        $.getJSON("/api/products", function (products) {
            $.each(products, function (index, product) {
                self.products.push(new ProductViewModel(self, product));
            })
        });
    
        $.getJSON("api/orders", self.orders);
    };

OK, that's a lot of code, but we built it up step-by-step, so hopefully the design is clear. Now we can add some Knockout.js bindings to the HTML.

**Products**

Here are the bindings for the product list:

    <ul id="products" data-bind="foreach: products">
        <li>
            <div>
                <span data-bind="text: Name"></span> 
                <span class="price" data-bind="text: '$' + Price"></span>
            </div>
            <div data-bind="if: $parent.loggedIn">
                <button data-bind="click: addItemToCart">Add to Order</button>
            </div>
        </li>
    </ul>

This iterates over the products array and displays the name and price. The "Add to Order" button is visible only when the user is logged in.

The "Add to Order" button calls `addItemToCart` on the `ProductViewModel` instance for the product. This demonstrates a nice feature of Knockout.js: When a view-model contains other view-models, you can apply the bindings to the inner model. In this example, the bindings within the `foreach` are applied to each of the `ProductViewModel` instances. This approach is much cleaner than putting all of the functionality into a single view-model.

**Cart**

Here are the bindings for the cart:

    <div id="cart" class="float-right" data-bind="visible: cart().length > 0">
    <h1>Your Cart</h1>
        <table class="details ui-widget-content">
        <thead>
            <tr><td>Item</td><td>Price</td><td>Quantity</td><td></td></tr>
        </thead>    
        <tbody data-bind="foreach: cart">
            <tr>
                <td><span data-bind="text: $data.Name"></span></td>
                <td>$<span data-bind="text: $data.Price"></span></td>
                <td class="qty"><span data-bind="text: $data.Quantity()"></span></td>
                <td><a href="#" data-bind="click: removeAllFromCart">Remove</a></td>
            </tr>
        </tbody>
    </table>
    <input type="button" data-bind="click: createOrder" value="Create Order"/>

This iterates over the cart array and displays the name, price, and quantity. Note that the "Remove" link and the "Create Order" button are bound to view-model functions.

**Orders**

Here are the bindings for the orders list:

    <h1>Your Orders</h1>
    <ul id="orders" data-bind="foreach: orders">
    <li class="ui-widget-content">
        <a href="#" data-bind="click: $root.getDetails">
            Order # <span data-bind="text: $data.Id"></span></a>
    </li>
    </ul>

This iterates over the orders and shows the order ID. The click event on the link is bound to the `getDetails` function.

**Order Details**

Here are the bindings for the order details:

    <div id="order-details" class="float-right" data-bind="if: details()">
    <h2>Order #<span data-bind="text: details().Id"></span></h2>
    <table class="details ui-widget-content">
        <thead>
            <tr><td>Item</td><td>Price</td><td>Quantity</td><td>Subtotal</td></tr>
        </thead>    
        <tbody data-bind="foreach: details().items">
            <tr>
                <td><span data-bind="text: $data.Product"></span></td>
                <td><span data-bind="text: $data.Price"></span></td>
                <td><span data-bind="text: $data.Quantity"></span></td>
                <td>
                    <span data-bind="text: ($data.Price * $data.Quantity).toFixed(2)"></span>
                </td>
            </tr>
        </tbody>
    </table>
    <p>Total: <span data-bind="text: details().total"></span></p>
    </div>

This iterates over the items in the order and displays the product, price, and quanity. The surrounding div is visible only if the details array contains one or more items.

## Conclusion

In this tutorial, you created an application that uses Entity Framework to communicate with the database, and ASP.NET Web API to provide a public-facing interface on top of the data layer. We use ASP.NET MVC 4 to render the HTML pages, and Knockout.js plus jQuery to provide dynamic interactions without page reloads.

Additional resources:

- [ASP.NET Data Access Content Map](https://msdn.microsoft.com/en-us/library/6759sth4.aspx)
- [Entity Framework Developer Center](https://msdn.microsoft.com/en-US/data/ef)

>[!div class="step-by-step"] [Previous](using-web-api-with-entity-framework-part-6.md)