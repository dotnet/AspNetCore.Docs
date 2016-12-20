---
title: "Part 8: Shopping Cart with Ajax Updates | Microsoft Docs"
author: jongalloway
description: "This tutorial series details all of the steps taken to build the ASP.NET MVC Music Store sample application. Part 8 covers Shopping Cart with Ajax Updates."
ms.author: riande
manager: wpickett
ms.date: 04/21/2011
ms.topic: article
ms.assetid: 
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-8
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\mvc\overview\older-versions\mvc-music-store\mvc-music-store-part-8.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/24899) | [View dev content](http://docs.aspdev.net/tutorials/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-8.html) | [View prod content](http://www.asp.net/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-8) | Picker: 27632

Part 8: Shopping Cart with Ajax Updates
====================
by [Jon Galloway](https://github.com/jongalloway)

> The MVC Music Store is a tutorial application that introduces and explains step-by-step how to use ASP.NET MVC and Visual Studio for web development.  
>   
> The MVC Music Store is a lightweight sample store implementation which sells music albums online, and implements basic site administration, user sign-in, and shopping cart functionality.  
>   
> This tutorial series details all of the steps taken to build the ASP.NET MVC Music Store sample application. Part 8 covers Shopping Cart with Ajax Updates.


We'll allow users to place albums in their cart without registering, but they'll need to register as guests to complete checkout. The shopping and checkout process will be separated into two controllers: a ShoppingCart Controller which allows anonymously adding items to a cart, and a Checkout Controller which handles the checkout process. We'll start with the Shopping Cart in this section, then build the Checkout process in the following section.

## Adding the Cart, Order, and OrderDetail model classes

Our Shopping Cart and Checkout processes will make use of some new classes. Right-click the Models folder and add a Cart class (Cart.cs) with the following code.

    using System.ComponentModel.DataAnnotations;
     
    namespace MvcMusicStore.Models
    {
        public class Cart
        {
            [Key]
            public int      RecordId    { get; set; }
            public string   CartId      { get; set; }
            public int      AlbumId     { get; set; }
            public int      Count       { get; set; }
            public System.DateTime DateCreated { get; set; }
            public virtual Album Album  { get; set; }
        }
    }

This class is pretty similar to others we've used so far, with the exception of the [Key] attribute for the RecordId property. Our Cart items will have a string identifier named CartID to allow anonymous shopping, but the table includes an integer primary key named RecordId. By convention, Entity Framework Code-First expects that the primary key for a table named Cart will be either CartId or ID, but we can easily override that via annotations or code if we want. This is an example of how we can use the simple conventions in Entity Framework Code-First when they suit us, but we're not constrained by them when they don't.

Next, add an Order class (Order.cs) with the following code.

    using System.Collections.Generic;
     
    namespace MvcMusicStore.Models
    {
        public partial class Order
        {
            public int    OrderId    { get; set; }
            public string Username   { get; set; }
            public string FirstName  { get; set; }
            public string LastName   { get; set; }
            public string Address    { get; set; }
            public string City       { get; set; }
            public string State      { get; set; }
            public string PostalCode { get; set; }
            public string Country    { get; set; }
            public string Phone      { get; set; }
            public string Email      { get; set; }
            public decimal Total     { get; set; }
            public System.DateTime OrderDate      { get; set; }
            public List<OrderDetail> OrderDetails { get; set; }
        }
    }

This class tracks summary and delivery information for an order. **It won't compile yet**, because it has an OrderDetails navigation property which depends on a class we haven't created yet. Let's fix that now by adding a class named OrderDetail.cs, adding the following code.

    namespace MvcMusicStore.Models
    {
        public class OrderDetail
        {
            public int OrderDetailId { get; set; }
            public int OrderId { get; set; }
            public int AlbumId { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public virtual Album Album { get; set; }
            public virtual Order Order { get; set; }
        }
    }

We'll make one last update to our MusicStoreEntities class to include DbSets which expose those new Model classes, also including a DbSet&lt;Artist&gt;. The updated MusicStoreEntities class appears as below.

    using System.Data.Entity;
     
    namespace MvcMusicStore.Models
    {
        public class MusicStoreEntities : DbContext
        {
            public DbSet<Album>     Albums  { get; set; }
            public DbSet<Genre>     Genres  { get; set; }
            public DbSet<Artist>    Artists {
    get; set; }
            public DbSet<Cart>     
    Carts { get; set; }
            public DbSet<Order>     Orders
    { get; set; }
            public DbSet<OrderDetail>
    OrderDetails { get; set; }
        }
    }

## Managing the Shopping Cart business logic

Next, we'll create the ShoppingCart class in the Models folder. The ShoppingCart model handles data access to the Cart table. Additionally, it will handle the business logic to for adding and removing items from the shopping cart.

Since we don't want to require users to sign up for an account just to add items to their shopping cart, we will assign users a temporary unique identifier (using a GUID, or globally unique identifier) when they access the shopping cart. We'll store this ID using the ASP.NET Session class.

*Note: The ASP.NET Session is a convenient place to store user-specific information which will expire after they leave the site. While misuse of session state can have performance implications on larger sites, our light use will work well for demonstration purposes.*

The ShoppingCart class exposes the following methods:

**AddToCart** takes an Album as a parameter and adds it to the user's cart. Since the Cart table tracks quantity for each album, it includes logic to create a new row if needed or just increment the quantity if the user has already ordered one copy of the album.

**RemoveFromCart** takes an Album ID and removes it from the user's cart. If the user only had one copy of the album in their cart, the row is removed.

**EmptyCart** removes all items from a user's shopping cart.

**GetCartItems** retrieves a list of CartItems for display or processing.

**GetCount** retrieves a the total number of albums a user has in their shopping cart.

**GetTotal** calculates the total cost of all items in the cart.

**CreateOrder** converts the shopping cart to an order during the checkout phase.

**GetCart** is a static method which allows our controllers to obtain a cart object. It uses the **GetCartId** method to handle reading the CartId from the user's session. The GetCartId method requires the HttpContextBase so that it can read the user's CartId from user's session.

Here's the complete **ShoppingCart class**:

    using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Web;
     using System.Web.Mvc;
     
    namespace MvcMusicStore.Models
    {
        public partial class ShoppingCart
        {
            MusicStoreEntities storeDB = new MusicStoreEntities();
            string ShoppingCartId { get; set; }
            public const string CartSessionKey = "CartId";
            public static ShoppingCart GetCart(HttpContextBase context)
            {
                var cart = new ShoppingCart();
                cart.ShoppingCartId = cart.GetCartId(context);
                return cart;
            }
            // Helper method to simplify shopping cart calls
            public static ShoppingCart GetCart(Controller controller)
            {
                return GetCart(controller.HttpContext);
            }
            public void AddToCart(Album album)
            {
                // Get the matching cart and album instances
                var cartItem = storeDB.Carts.SingleOrDefault(
                    c => c.CartId == ShoppingCartId 
                    && c.AlbumId == album.AlbumId);
     
                if (cartItem == null)
                {
                    // Create a new cart item if no cart item exists
                    cartItem = new Cart
                    {
                        AlbumId = album.AlbumId,
                        CartId = ShoppingCartId,
                        Count = 1,
                        DateCreated = DateTime.Now
                    };
                    storeDB.Carts.Add(cartItem);
                }
                else
                {
                    // If the item does exist in the cart, 
                    // then add one to the quantity
                    cartItem.Count++;
                }
                // Save changes
                storeDB.SaveChanges();
            }
            public int RemoveFromCart(int id)
            {
                // Get the cart
                var cartItem = storeDB.Carts.Single(
                    cart => cart.CartId == ShoppingCartId 
                    && cart.RecordId == id);
     
                int itemCount = 0;
     
                if (cartItem != null)
                {
                    if (cartItem.Count > 1)
                    {
                        cartItem.Count--;
                        itemCount = cartItem.Count;
                    }
                    else
                    {
                        storeDB.Carts.Remove(cartItem);
                    }
                    // Save changes
                    storeDB.SaveChanges();
                }
                return itemCount;
            }
            public void EmptyCart()
            {
                var cartItems = storeDB.Carts.Where(
                    cart => cart.CartId == ShoppingCartId);
     
                foreach (var cartItem in cartItems)
                {
                    storeDB.Carts.Remove(cartItem);
                }
                // Save changes
                storeDB.SaveChanges();
            }
            public List<Cart> GetCartItems()
            {
                return storeDB.Carts.Where(
                    cart => cart.CartId == ShoppingCartId).ToList();
            }
            public int GetCount()
            {
                // Get the count of each item in the cart and sum them up
                int? count = (from cartItems in storeDB.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count).Sum();
                // Return 0 if all entries are null
                return count ?? 0;
            }
            public decimal GetTotal()
            {
                // Multiply album price by count of that album to get 
                // the current price for each of those albums in the cart
                // sum all album price totals to get the cart total
                decimal? total = (from cartItems in storeDB.Carts
                                  where cartItems.CartId == ShoppingCartId
                                  select (int?)cartItems.Count *
                                  cartItems.Album.Price).Sum();
    
                return total ?? decimal.Zero;
            }
            public int CreateOrder(Order order)
            {
                decimal orderTotal = 0;
     
                var cartItems = GetCartItems();
                // Iterate over the items in the cart, 
                // adding the order details for each
                foreach (var item in cartItems)
                {
                    var orderDetail = new OrderDetail
                    {
                        AlbumId = item.AlbumId,
                        OrderId = order.OrderId,
                        UnitPrice = item.Album.Price,
                        Quantity = item.Count
                    };
                    // Set the order total of the shopping cart
                    orderTotal += (item.Count * item.Album.Price);
     
                    storeDB.OrderDetails.Add(orderDetail);
     
                }
                // Set the order's total to the orderTotal count
                order.Total = orderTotal;
     
                // Save the order
                storeDB.SaveChanges();
                // Empty the shopping cart
                EmptyCart();
                // Return the OrderId as the confirmation number
                return order.OrderId;
            }
            // We're using HttpContextBase to allow access to cookies.
            public string GetCartId(HttpContextBase context)
            {
                if (context.Session[CartSessionKey] == null)
                {
                    if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                    {
                        context.Session[CartSessionKey] =
                            context.User.Identity.Name;
                    }
                    else
                    {
                        // Generate a new random GUID using System.Guid class
                        Guid tempCartId = Guid.NewGuid();
                        // Send tempCartId back to client as a cookie
                        context.Session[CartSessionKey] = tempCartId.ToString();
                    }
                }
                return context.Session[CartSessionKey].ToString();
            }
            // When a user has logged in, migrate their shopping cart to
            // be associated with their username
            public void MigrateCart(string userName)
            {
                var shoppingCart = storeDB.Carts.Where(
                    c => c.CartId == ShoppingCartId);
     
                foreach (Cart item in shoppingCart)
                {
                    item.CartId = userName;
                }
                storeDB.SaveChanges();
            }
        }
    }

## ViewModels

Our Shopping Cart Controller will need to communicate some complex information to its views which doesn't map cleanly to our Model objects. We don't want to modify our Models to suit our views; Model classes should represent our domain, not the user interface. One solution would be to pass the information to our Views using the ViewBag class, as we did with the Store Manager dropdown information, but passing a lot of information via ViewBag gets hard to manage.

A solution to this is to use the *ViewModel* pattern. When using this pattern we create strongly-typed classes that are optimized for our specific view scenarios, and which expose properties for the dynamic values/content needed by our view templates. Our controller classes can then populate and pass these view-optimized classes to our view template to use. This enables type-safety, compile-time checking, and editor IntelliSense within view templates.

We'll create two View Models for use in our Shopping Cart controller: the ShoppingCartViewModel will hold the contents of the user's shopping cart, and the ShoppingCartRemoveViewModel will be used to display confirmation information when a user removes something from their cart.

Let's create a new ViewModels folder in the root of our project to keep things organized. Right-click the project, select Add / New Folder.

![](mvc-music-store-part-8/_static/image1.jpg)

Name the folder ViewModels.

![](mvc-music-store-part-8/_static/image1.png)

Next, add the ShoppingCartViewModel class in the ViewModels folder. It has two properties: a list of Cart items, and a decimal value to hold the total price for all items in the cart.

    using System.Collections.Generic;
     using MvcMusicStore.Models;
     
    namespace MvcMusicStore.ViewModels
    {
        public class ShoppingCartViewModel
        {
            public List<Cart> CartItems { get; set; }
            public decimal CartTotal { get; set; }
        }
    }

Now add the ShoppingCartRemoveViewModel to the ViewModels folder, with the following four properties.

    namespace MvcMusicStore.ViewModels
    {
        public class ShoppingCartRemoveViewModel
        {
            public string Message { get; set; }
            public decimal CartTotal { get; set; }
            public int CartCount { get; set; }
            public int ItemCount { get; set; }
            public int DeleteId { get; set; }
        }
    }

## The Shopping Cart Controller

The Shopping Cart controller has three main purposes: adding items to a cart, removing items from the cart, and viewing items in the cart. It will make use of the three classes we just created: ShoppingCartViewModel, ShoppingCartRemoveViewModel, and ShoppingCart. As in the StoreController and StoreManagerController, we'll add a field to hold an instance of MusicStoreEntities.

Add a new Shopping Cart controller to the project using the Empty controller template.

![](mvc-music-store-part-8/_static/image2.png)

Here's the complete ShoppingCart Controller. The Index and Add Controller actions should look very familiar. The Remove and CartSummary controller actions handle two special cases, which we'll discuss in the following section.

    using System.Linq;
     using System.Web.Mvc;
     using MvcMusicStore.Models;
     using MvcMusicStore.ViewModels;
     
    namespace MvcMusicStore.Controllers
    {
        public class ShoppingCartController : Controller
        {
            MusicStoreEntities storeDB = new MusicStoreEntities();
            //
            // GET: /ShoppingCart/
            public ActionResult Index()
            {
                var cart = ShoppingCart.GetCart(this.HttpContext);
     
                // Set up our ViewModel
                var viewModel = new ShoppingCartViewModel
                {
                    CartItems = cart.GetCartItems(),
                    CartTotal = cart.GetTotal()
                };
                // Return the view
                return View(viewModel);
            }
            //
            // GET: /Store/AddToCart/5
            public ActionResult AddToCart(int id)
            {
                // Retrieve the album from the database
                var addedAlbum = storeDB.Albums
                    .Single(album => album.AlbumId == id);
     
                // Add it to the shopping cart
                var cart = ShoppingCart.GetCart(this.HttpContext);
     
                cart.AddToCart(addedAlbum);
     
                // Go back to the main store page for more shopping
                return RedirectToAction("Index");
            }
            //
            // AJAX: /ShoppingCart/RemoveFromCart/5
            [HttpPost]
            public ActionResult RemoveFromCart(int id)
            {
                // Remove the item from the cart
                var cart = ShoppingCart.GetCart(this.HttpContext);
     
                // Get the name of the album to display confirmation
                string albumName = storeDB.Carts
                    .Single(item => item.RecordId == id).Album.Title;
     
                // Remove from cart
                int itemCount = cart.RemoveFromCart(id);
     
                // Display the confirmation message
                var results = new ShoppingCartRemoveViewModel
                {
                    Message = Server.HtmlEncode(albumName) +
                        " has been removed from your shopping cart.",
                    CartTotal = cart.GetTotal(),
                    CartCount = cart.GetCount(),
                    ItemCount = itemCount,
                    DeleteId = id
                };
                return Json(results);
            }
            //
            // GET: /ShoppingCart/CartSummary
            [ChildActionOnly]
            public ActionResult CartSummary()
            {
                var cart = ShoppingCart.GetCart(this.HttpContext);
     
                ViewData["CartCount"] = cart.GetCount();
                return PartialView("CartSummary");
            }
        }
    }

## Ajax Updates with jQuery

We'll next create a Shopping Cart Index page that is strongly typed to the ShoppingCartViewModel and uses the List View template using the same method as before.

![](mvc-music-store-part-8/_static/image3.png)

However, instead of using an Html.ActionLink to remove items from the cart, we'll use jQuery to "wire up" the click event for all links in this view which have the HTML class RemoveLink. Rather than posting the form, this click event handler will just make an AJAX callback to our RemoveFromCart controller action. The RemoveFromCart returns a JSON serialized result, which our jQuery callback then parses and performs four quick updates to the page using jQuery:

- 1. Removes the deleted album from the list
- 2. Updates the cart count in the header
- 3. Displays an update message to the user
- 4. Updates the cart total price

Since the remove scenario is being handled by an Ajax callback within the Index view, we don't need an additional view for RemoveFromCart action. Here is the complete code for the /ShoppingCart/Index view:

    @model MvcMusicStore.ViewModels.ShoppingCartViewModel
    @{
        ViewBag.Title = "Shopping Cart";
    }
    <script src="/Scripts/jquery-1.4.4.min.js"
    type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            // Document.ready -> link up remove event handler
            $(".RemoveLink").click(function () {
                // Get the id from the link
                var recordToDelete = $(this).attr("data-id");
                if (recordToDelete != '') {
                    // Perform the ajax post
                    $.post("/ShoppingCart/RemoveFromCart", {"id": recordToDelete },
                        function (data) {
                            // Successful requests get here
                            // Update the page elements
                            if (data.ItemCount == 0) {
                                $('#row-' + data.DeleteId).fadeOut('slow');
                            } else {
                                $('#item-count-' + data.DeleteId).text(data.ItemCount);
                            }
                            $('#cart-total').text(data.CartTotal);
                            $('#update-message').text(data.Message);
                            $('#cart-status').text('Cart (' + data.CartCount + ')');
                        });
                }
            });
        });
    </script>
    <h3>
        <em>Review</em> your cart:
     </h3>
    <p class="button">
        @Html.ActionLink("Checkout
    >>", "AddressAndPayment", "Checkout")
    </p>
    <div id="update-message">
    </div>
    <table>
        <tr>
            <th>
                Album Name
            </th>
            <th>
                Price (each)
            </th>
            <th>
                Quantity
            </th>
            <th></th>
        </tr>
        @foreach (var item in
    Model.CartItems)
        {
            <tr id="row-@item.RecordId">
                <td>
                    @Html.ActionLink(item.Album.Title,
    "Details", "Store", new { id = item.AlbumId }, null)
                </td>
                <td>
                    @item.Album.Price
                </td>
                <td id="item-count-@item.RecordId">
                    @item.Count
                </td>
                <td>
                    <a href="#" class="RemoveLink"
    data-id="@item.RecordId">Remove
    from cart</a>
                </td>
            </tr>
        }
        <tr>
            <td>
                Total
            </td>
            <td>
            </td>
            <td>
            </td>
            <td id="cart-total">
                @Model.CartTotal
            </td>
        </tr>
    </table>

In order to test this out, we need to be able to add items to our shopping cart. We'll update our **Store Details** view to include an "Add to cart" button. While we're at it, we can include some of the Album additional information which we've added since we last updated this view: Genre, Artist, Price, and Album Art. The updated Store Details view code appears as shown below.

    @model MvcMusicStore.Models.Album
    @{
        ViewBag.Title = "Album - " + Model.Title;
     }
    <h2>@Model.Title</h2>
    <p>
        <img alt="@Model.Title"
    src="@Model.AlbumArtUrl" />
    </p>
    <div id="album-details">
        <p>
            <em>Genre:</em>
            @Model.Genre.Name
        </p>
        <p>
            <em>Artist:</em>
            @Model.Artist.Name
        </p>
        <p>
            <em>Price:</em>
            @String.Format("{0:F}",
    Model.Price)
        </p>
        <p class="button">
            @Html.ActionLink("Add to
    cart", "AddToCart", 
            "ShoppingCart", new { id = Model.AlbumId }, "")
        </p>
    </div>

Now we can click through the store and test adding and removing Albums to and from our shopping cart. Run the application and browse to the Store Index.

![](mvc-music-store-part-8/_static/image4.png)

Next, click on a Genre to view a list of albums.

![](mvc-music-store-part-8/_static/image5.png)

Clicking on an Album title now shows our updated Album Details view, including the "Add to cart" button.

![](mvc-music-store-part-8/_static/image6.png)

Clicking the "Add to cart" button shows our Shopping Cart Index view with the shopping cart summary list.

![](mvc-music-store-part-8/_static/image7.png)

After loading up your shopping cart, you can click on the Remove from cart link to see the Ajax update to your shopping cart.

![](mvc-music-store-part-8/_static/image8.png)

We've built out a working shopping cart which allows unregistered users to add items to their cart. In the following section, we'll allow them to register and complete the checkout process.

*Please use the Discussions at [http://mvcmusicstore.codeplex.com](http://mvcmusicstore.codeplex.com) for any questions or comments.*

>[!div class="step-by-step"] [Previous](mvc-music-store-part-7.md) [Next](mvc-music-store-part-9.md)