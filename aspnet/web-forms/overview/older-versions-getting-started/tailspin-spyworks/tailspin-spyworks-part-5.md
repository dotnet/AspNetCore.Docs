---
title: "Part 5: Business Logic | Microsoft Docs"
author: JoeStagner
description: "This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 5 adds some business logic."
ms.author: riande
manager: wpickett
ms.date: 07/21/2010
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/tailspin-spyworks/tailspin-spyworks-part-5
---
Part 5: Business Logic
====================
by [Joe Stagner](https://github.com/JoeStagner)

> Tailspin Spyworks demonstrates how extraordinarily simple it is to create powerful, scalable applications for the .NET platform. It shows off how to use the great new features in ASP.NET 4 to build an online store, including shopping, checkout, and administration.
> 
> This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 5 adds some business logic.


## <a id="_Toc260221671"></a>  Adding Some Business Logic

We want our shopping experience to be available whenever someone visits our web site. Visitors will be able to browse and add items to the shopping cart even if they are not registered or logged in. When they are ready to check out they will be given the option to authenticate and if they are not yet members they will be able to create an account.

This means that we will need to implement the logic to convert the shopping cart from an anonymous state to a "Registered User" state.

Let's create a directory named "Classes" then Right-Click on the folder and create a new "Class" file named MyShoppingCart.cs

![](tailspin-spyworks-part-5/_static/image1.jpg)

![](tailspin-spyworks-part-5/_static/image1.png)

As previously mentioned we will be extending the class that implements the MyShoppingCart.aspx page and we will do this using .NET's powerful "Partial Class" construct.

The generated call for our MyShoppingCart.aspx.cf file looks like this.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace TailspinSpyworks
    {
        public partial class MyShoppingCart : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
        }
    }

Note the use of the "partial" keyword.

The class file that we just generated looks like this.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace TailspinSpyworks.Classes
    {
        public class MyShoppingCart
        {
        }
    }

We will merge our implementations by adding the partial keyword to this file as well.

Our new class file now looks like this.

    namespace TailspinSpyworks.Classes
    {
        public partial class MyShoppingCart
        {
        }
    }

The first method that we will add to our class is the "AddItem" method. This is the method that will ultimately be called when the user clicks on the "Add to Art" links on the Product List and Product Details pages.

Append the following to the using statements at the top of the page.

    using TailspinSpyworks.Data_Access;

And add this method to the MyShoppingCart class.

    //------------------------------------------------------------------------------------+
    public void AddItem(string cartID, int productID, int quantity)
    {
      using (CommerceEntities db = new CommerceEntities())
        {
        try 
          {
          var myItem = (from c in db.ShoppingCarts where c.CartID == cartID && 
                                  c.ProductID == productID select c).FirstOrDefault();
          if(myItem == null)
            {
            ShoppingCart cartadd = new ShoppingCart();
            cartadd.CartID = cartID;
            cartadd.Quantity = quantity;
            cartadd.ProductID = productID;
            cartadd.DateCreated = DateTime.Now;
            db.ShoppingCarts.AddObject(cartadd);
            }
          else
            {
            myItem.Quantity += quantity;
            }
          db.SaveChanges();
          }
        catch (Exception exp)
          {
          throw new Exception("ERROR: Unable to Add Item to Cart - " + 
                                                              exp.Message.ToString(), exp);
          }
       }
    }

We are using LINQ to Entities to see if the item is already in the cart. If so, we update the order quantity of the item, otherwise we create a new entry for the selected item

In order to call this method we will implement an AddToCart.aspx page that not only class this method but then displayed the current shopping a=cart after the item has been added.

Right-Click on the solution name in the solution explorer and add and new page named AddToCart.aspx as we have done previously.

While we could use this page to display interim results like low stock issues, etc, in our implementation, the page will not actually render, but rather call the "Add" logic and redirect.

To accomplish this we'll add the following code to the Page\_Load event.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Diagnostics;
    
    namespace TailspinSpyworks
    {
        public partial class AddToCart : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                string rawId = Request.QueryString["ProductID"];
                int productId;
                if (!String.IsNullOrEmpty(rawId) && Int32.TryParse(rawId, out productId))
                {
                    MyShoppingCart usersShoppingCart = new MyShoppingCart();
                    String cartId = usersShoppingCart.GetShoppingCartId();
                    usersShoppingCart.AddItem(cartId, productId, 1);
                }
                else
                {
                    Debug.Fail("ERROR : We should never get to AddToCart.aspx 
                                                       without a ProductId.");
                    throw new Exception("ERROR : It is illegal to load AddToCart.aspx 
                                                       without setting a ProductId.");
                }
                Response.Redirect("MyShoppingCart.aspx");
            }
        }
    }

Note that we are retrieving the product to add to the shopping cart from a QueryString parameter and calling the AddItem method of our class.

Assuming no errors are encountered control is passed to the SHoppingCart.aspx page which we will fully implement next. If there should be an error we throw an exception.

Currently we have not yet implemented a global error handler so this exception would go unhandled by our application but we will remedy this shortly.

Note also the use of the statement Debug.Fail() (available via `using System.Diagnostics;)`

Is the application is running inside the debugger, this method will display a detailed dialog with information about the applications state along with the error message that we specify.

When running in production the Debug.Fail() statement is ignored.

You will note in the code above a call to a method in our shopping cart class names "GetShoppingCartId".

Add the code to implement the method as follows.

Note that we've also added update and checkout buttons and a label where we can display the cart "total".

    public const string CartId = "TailSpinSpyWorks_CartID";
    
    //--------------------------------------------------------------------------------------+
    public String GetShoppingCartId()
    {
      if (Session[CartId] == null)
         {
         Session[CartId] = System.Web.HttpContext.Current.Request.IsAuthenticated ? 
                                            User.Identity.Name : Guid.NewGuid().ToString();
         }
      return Session[CartId].ToString();
    }

We can now add items to our shopping cart but we have not implemented the logic to display the cart after a product has been added.

So, in the MyShoppingCart.aspx page we'll add an EntityDataSource control and a GridVire control as follows.

    <div id="ShoppingCartTitle" runat="server" class="ContentHead">Shopping Cart</div>
    <asp:GridView ID="MyList" runat="server" AutoGenerateColumns="False" ShowFooter="True" 
                              GridLines="Vertical" CellPadding="4"
                              DataSourceID="EDS_Cart"  
                              DataKeyNames="ProductID,UnitCost,Quantity" 
                              CssClass="CartListItem">              
      <AlternatingRowStyle CssClass="CartListItemAlt" />
      <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" 
                                              SortExpression="ProductID"  />
        <asp:BoundField DataField="ModelNumber" HeaderText="Model Number" 
                                                SortExpression="ModelNumber" />
        <asp:BoundField DataField="ModelName" HeaderText="Model Name" 
                                              SortExpression="ModelName"  />
        <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" ReadOnly="True" 
                                             SortExpression="UnitCost" 
                                             DataFormatString="{0:c}" />         
        <asp:TemplateField> 
          <HeaderTemplate>Quantity</HeaderTemplate>
          <ItemTemplate>
             <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" 
                          Text='<%# Bind("Quantity") %>'></asp:TextBox> 
          </ItemTemplate>
        </asp:TemplateField>           
        <asp:TemplateField> 
          <HeaderTemplate>Item Total</HeaderTemplate>
          <ItemTemplate>
            <%# (Convert.ToDouble(Eval("Quantity")) *  
                 Convert.ToDouble(Eval("UnitCost")))%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField> 
        <HeaderTemplate>Remove Item</HeaderTemplate>
          <ItemTemplate>
            <center>
              <asp:CheckBox id="Remove" runat="server" />
            </center>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
      <FooterStyle CssClass="CartListFooter"/>
      <HeaderStyle  CssClass="CartListHead" />
    </asp:GridView>
    
    <div>
      <strong>
        <asp:Label ID="LabelTotalText" runat="server" Text="Order Total : ">  
        </asp:Label>
        <asp:Label CssClass="NormalBold" id="lblTotal" runat="server" 
                                                       EnableViewState="false">
        </asp:Label>
      </strong> 
    </div>
    <br />
    <asp:imagebutton id="UpdateBtn" runat="server" ImageURL="Styles/Images/update_cart.gif" 
                                    onclick="UpdateBtn_Click"></asp:imagebutton>
    <asp:imagebutton id="CheckoutBtn" runat="server"  
                                      ImageURL="Styles/Images/final_checkout.gif"    
                                      PostBackUrl="~/CheckOut.aspx">
    </asp:imagebutton>
    <asp:EntityDataSource ID="EDS_Cart" runat="server" 
                          ConnectionString="name=CommerceEntities" 
                          DefaultContainerName="CommerceEntities" EnableFlattening="False" 
                          EnableUpdate="True" EntitySetName="ViewCarts" 
                          AutoGenerateWhereClause="True" EntityTypeFilter="" Select=""                         
                          Where="">
      <WhereParameters>
        <asp:SessionParameter Name="CartID" DefaultValue="0" 
                                            SessionField="TailSpinSpyWorks_CartID" />
      </WhereParameters>
    </asp:EntityDataSource>

Call up the form in the designer so that you can double click on the Update Cart button and generate the click event handler that is specified in the declaration in the markup.

We'll implement the details later but doing this will let us build and run our application without errors.

When you run the application and add an item to the shopping cart you will see this.

![](tailspin-spyworks-part-5/_static/image2.jpg)

Note that we have deviated from the "default" grid display by implementing three custom columns.

The first is an Editable, "Bound" field for the Quantity:

    <asp:TemplateField> 
          <HeaderTemplate>Quantity</HeaderTemplate>
          <ItemTemplate>
             <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" 
                          Text='<%# Bind("Quantity") %>'></asp:TextBox> 
          </ItemTemplate>
        </asp:TemplateField>

The next is a "calculated" column that displays the line item total (the item cost times the quantity to be ordered):

    <asp:TemplateField> 
          <HeaderTemplate>Item Total</HeaderTemplate>
          <ItemTemplate>
            <%# (Convert.ToDouble(Eval("Quantity")) *  
                 Convert.ToDouble(Eval("UnitCost")))%>
          </ItemTemplate>
        </asp:TemplateField>

Lastly we have a custom column that contains a CheckBox control that the user will use to indicate that the item should be removed from the shopping chart.

    <asp:TemplateField> 
        <HeaderTemplate>Remove Item</HeaderTemplate>
          <ItemTemplate>
            <center>
              <asp:CheckBox id="Remove" runat="server" />
            </center>
          </ItemTemplate>
        </asp:TemplateField>

![](tailspin-spyworks-part-5/_static/image3.jpg)

As you can see, the Order Total line is empty so let's add some logic to calculate the Order Total.

We'll first implement a "GetTotal" method to our MyShoppingCart Class.

In the MyShoppingCart.cs file add the following code.

    //--------------------------------------------------------------------------------------+
    public decimal GetTotal(string cartID)
    {
      using (CommerceEntities db = new CommerceEntities())
        {
        decimal cartTotal = 0;
        try
          {
          var myCart = (from c in db.ViewCarts where c.CartID == cartID select c);
          if (myCart.Count() > 0)
             {
             cartTotal = myCart.Sum(od => (decimal)od.Quantity * (decimal)od.UnitCost);
             }
           }
         catch (Exception exp)
           {
           throw new Exception("ERROR: Unable to Calculate Order Total - " + 
    exp.Message.ToString(), exp);
           }
         return (cartTotal);
         }
       }

Then in the Page\_Load event handler we'll can call our GetTotal method. At the same time we'll add a test to see if the shopping cart is empty and adjust the display accordingly if it is.

Now if the shopping cart is empty we get this:

![](tailspin-spyworks-part-5/_static/image4.jpg)

And if not, we see our total.

![](tailspin-spyworks-part-5/_static/image5.jpg)

However, this page is not yet complete.

We will need additional logic to recalculate the shopping cart by removing items marked for removal and by determining new quantity values as some may have been changed in the grid by the user.

Lets add a "RemoveItem" method to our shopping cart class in MyShoppingCart.cs to handle the case when a user marks an item for removal.

    //------------------------------------------------------------------------------------+
    public void RemoveItem(string cartID, int  productID)
    {
      using (CommerceEntities db = new CommerceEntities())
        {
        try
          {
          var myItem = (from c in db.ShoppingCarts where c.CartID == cartID && 
                             c.ProductID == productID select c).FirstOrDefault();
          if (myItem != null)
             {
             db.DeleteObject(myItem);
             db.SaveChanges();
             }
          }
        catch (Exception exp)
          {
          throw new Exception("ERROR: Unable to Remove Cart Item - " + 
                                      exp.Message.ToString(), exp);
          }
        }
    }

Now let's ad a method to handle the circumstance when a user simply changes the quality to be ordered in the GridView.

    //--------------------------------------------------------------------------------------+
    public void UpdateItem(string cartID, int productID, int quantity)
    {
       using (CommerceEntities db = new CommerceEntities())
          {
          try
            {
            var myItem = (from c in db.ShoppingCarts where c.CartID == cartID && 
                                    c.ProductID == productID select c).FirstOrDefault();
            if (myItem != null)
               {
               myItem.Quantity = quantity;
               db.SaveChanges();
               }
            }
         catch (Exception exp)
            {
            throw new Exception("ERROR: Unable to Update Cart Item - " +     
                                                            exp.Message.ToString(), exp);
            }
          }
    }

With the basic Remove and Update features in place we can implement the logic that actually updates the shopping cart in the database. (In MyShoppingCart.cs)

    //-------------------------------------------------------------------------------------+
    public void UpdateShoppingCartDatabase(String cartId, 
                                           ShoppingCartUpdates[] CartItemUpdates)
    {
      using (CommerceEntities db = new CommerceEntities())
        {
        try
          {
          int CartItemCOunt = CartItemUpdates.Count();
          var myCart = (from c in db.ViewCarts where c.CartID == cartId select c);
          foreach (var cartItem in myCart)
            {
            // Iterate through all rows within shopping cart list
            for (int i = 0; i < CartItemCOunt; i++)
              {
              if (cartItem.ProductID == CartItemUpdates[i].ProductId)
                 {
                 if (CartItemUpdates[i].PurchaseQantity < 1 || 
       CartItemUpdates[i].RemoveItem == true)
                    {
                    RemoveItem(cartId, cartItem.ProductID);
                    }
                 else 
                    {
                    UpdateItem(cartId, cartItem.ProductID, 
                                       CartItemUpdates[i].PurchaseQantity);
                    }
                  }
                }
              }
            }
          catch (Exception exp)
            {
            throw new Exception("ERROR: Unable to Update Cart Database - " + 
                                 exp.Message.ToString(), exp);
            }            
        }           
    }

You'll note that this method expects two parameters. One is the shopping cart Id and the other is an array of objects of user defined type.

So as to minimize the dependency of our logic on user interface specifics, we've defined a data structure that we can use to pass the shopping cart items to our code without our method needing to directly access the GridView control.

    public struct ShoppingCartUpdates
    {
       public int ProductId;
       public int PurchaseQantity;
       public bool RemoveItem;
    }

In our MyShoppingCart.aspx.cs file we can use this structure in our Update Button Click Event handler as follows. Note that in addition to updating the cart we will update the cart total as well.

    //--------------------------------------------------------------------------------------+
    protected void UpdateBtn_Click(object sender, ImageClickEventArgs e)
    {
      MyShoppingCart usersShoppingCart = new MyShoppingCart();
      String cartId = usersShoppingCart.GetShoppingCartId();
    
      ShoppingCartUpdates[] cartUpdates = new ShoppingCartUpdates[MyList.Rows.Count];
      for (int i = 0; i < MyList.Rows.Count; i++)
        {
        IOrderedDictionary rowValues = new OrderedDictionary();
        rowValues = GetValues(MyList.Rows[i]);
        cartUpdates[i].ProductId =  Convert.ToInt32(rowValues["ProductID"]);
        cartUpdates[i].PurchaseQantity = Convert.ToInt32(rowValues["Quantity"]); 
    
        CheckBox cbRemove = new CheckBox();
        cbRemove = (CheckBox)MyList.Rows[i].FindControl("Remove");
        cartUpdates[i].RemoveItem = cbRemove.Checked;
        }
    
       usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
       MyList.DataBind();
       lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal(cartId));
    }

Note with particular interest this line of code:

    rowValues = GetValues(MyList.Rows[i]);

GetValues() is a special helper function that we will implement in MyShoppingCart.aspx.cs as follows.

    //--------------------------------------------------------------------------------------+
    public static IOrderedDictionary GetValues(GridViewRow row)
    {
      IOrderedDictionary values = new OrderedDictionary();
      foreach (DataControlFieldCell cell in row.Cells)
        {
        if (cell.Visible)
          {
          // Extract values from the cell
          cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
          }
        }
        return values;
    }

This provides a clean way to access the values of the bound elements in our GridView control. Since our "Remove Item" CheckBox Control is not bound we'll access it via the FindControl() method.

At this stage in your project's development we are getting ready to implement the checkout process.

Before doing so let's use Visual Studio to generate the membership database and add a user to the membership repository.

>[!div class="step-by-step"] [Previous](tailspin-spyworks-part-4.md) [Next](tailspin-spyworks-part-6.md)