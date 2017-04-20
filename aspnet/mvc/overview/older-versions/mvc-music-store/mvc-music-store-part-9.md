---
uid: mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-9
title: "Part 9: Registration and Checkout | Microsoft Docs"
author: jongalloway
description: "This tutorial series details all of the steps taken to build the ASP.NET MVC Music Store sample application. Part 9 covers Registration and Checkout."
ms.author: aspnetcontent
manager: wpickett
ms.date: 04/21/2011
ms.topic: article
ms.assetid: d65c5c2b-a039-463f-ad29-25cf9fb7a1ba
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-9
msc.type: authoredcontent
---
Part 9: Registration and Checkout
====================
by [Jon Galloway](https://github.com/jongalloway)

> The MVC Music Store is a tutorial application that introduces and explains step-by-step how to use ASP.NET MVC and Visual Studio for web development.  
>   
> The MVC Music Store is a lightweight sample store implementation which sells music albums online, and implements basic site administration, user sign-in, and shopping cart functionality.  
>   
> This tutorial series details all of the steps taken to build the ASP.NET MVC Music Store sample application. Part 9 covers Registration and Checkout.


In this section, we will be creating a CheckoutController which will collect the shopper's address and payment information. We will require users to register with our site prior to checking out, so this controller will require authorization.

Users will navigate to the checkout process from their shopping cart by clicking the "Checkout" button.

![](mvc-music-store-part-9/_static/image1.jpg)

If the user is not logged in, they will be prompted to.

![](mvc-music-store-part-9/_static/image1.png)

Upon successful login, the user is then shown the Address and Payment view.

![](mvc-music-store-part-9/_static/image2.png)

Once they have filled the form and submitted the order, they will be shown the order confirmation screen.

![](mvc-music-store-part-9/_static/image3.png)

Attempting to view either a non-existent order or an order that doesn't belong to you will show the Error view.

![](mvc-music-store-part-9/_static/image4.png)

## Migrating the Shopping Cart

While the shopping process is anonymous, when the user clicks on the Checkout button, they will be required to register and login. Users will expect that we will maintain their shopping cart information between visits, so we will need to associate the shopping cart information with a user when they complete registration or login.

This is actually very simple to do, as our ShoppingCart class already has a method which will associate all the items in the current cart with a username. We will just need to call this method when a user completes registration or login.

Open the **AccountController** class that we added when we were setting up Membership and Authorization. Add a using statement referencing MvcMusicStore.Models, then add the following MigrateShoppingCart method:

[!code-csharp[Main](mvc-music-store-part-9/samples/sample1.cs)]

Next, modify the LogOn post action to call MigrateShoppingCart after the user has been validated, as shown below:

[!code-csharp[Main](mvc-music-store-part-9/samples/sample2.cs)]

Make the same change to the Register post action, immediately after the user account is successfully created:

[!code-csharp[Main](mvc-music-store-part-9/samples/sample3.cs)]

That's it - now an anonymous shopping cart will be automatically transferred to a user account upon successful registration or login.

## Creating the CheckoutController

Right-click on the Controllers folder and add a new Controller to the project named CheckoutController using the Empty controller template.

![](mvc-music-store-part-9/_static/image5.png)

First, add the Authorize attribute above the Controller class declaration to require users to register before checkout:

[!code-csharp[Main](mvc-music-store-part-9/samples/sample4.cs)]

*Note: This is similar to the change we previously made to the StoreManagerController, but in that case the Authorize attribute required that the user be in an Administrator role. In the Checkout Controller, we're requiring the user be logged in but aren't requiring that they be administrators.*

For the sake of simplicity, we won't be dealing with payment information in this tutorial. Instead, we are allowing users to check out using a promotional code. We will store this promotional code using a constant named PromoCode.

As in the StoreController, we'll declare a field to hold an instance of the MusicStoreEntities class, named storeDB. In order to make use of the MusicStoreEntities class, we will need to add a using statement for the MvcMusicStore.Models namespace. The top of our Checkout controller appears below.

[!code-csharp[Main](mvc-music-store-part-9/samples/sample5.cs)]

The CheckoutController will have the following controller actions:

**AddressAndPayment (GET method)** will display a form to allow the user to enter their information.

**AddressAndPayment (POST method)** will validate the input and process the order.

**Complete** will be shown after a user has successfully finished the checkout process. This view will include the user's order number, as confirmation.

First, let's rename the Index controller action (which was generated when we created the controller) to AddressAndPayment. This controller action just displays the checkout form, so it doesn't require any model information.

[!code-csharp[Main](mvc-music-store-part-9/samples/sample6.cs)]

Our AddressAndPayment POST method will follow the same pattern we used in the StoreManagerController: it will try to accept the form submission and complete the order, and will re-display the form if it fails.

After validating the form input meets our validation requirements for an Order, we will check the PromoCode form value directly. Assuming everything is correct, we will save the updated information with the order, tell the ShoppingCart object to complete the order process, and redirect to the Complete action.

[!code-csharp[Main](mvc-music-store-part-9/samples/sample7.cs)]

Upon successful completion of the checkout process, users will be redirected to the Complete controller action. This action will perform a simple check to validate that the order does indeed belong to the logged-in user before showing the order number as a confirmation.

[!code-csharp[Main](mvc-music-store-part-9/samples/sample8.cs)]

*Note: The Error view was automatically created for us in the /Views/Shared folder when we began the project.*

The complete CheckoutController code is as follows:

[!code-csharp[Main](mvc-music-store-part-9/samples/sample9.cs)]

## Adding the AddressAndPayment view

Now, let's create the AddressAndPayment view. Right-click on one of the the AddressAndPayment controller actions and add a view named AddressAndPayment which is strongly typed as an Order and uses the Edit template, as shown below.

![](mvc-music-store-part-9/_static/image6.png)

This view will make use of two of the techniques we looked at while building the StoreManagerEdit view:

- We will use Html.EditorForModel() to display form fields for the Order model
- We will leverage validation rules using an Order class with validation attributes

We'll start by updating the form code to use Html.EditorForModel(), followed by an additional textbox for the Promo Code. The complete code for the AddressAndPayment view is shown below.

[!code-cshtml[Main](mvc-music-store-part-9/samples/sample10.cshtml)]

## Defining validation rules for the Order

Now that our view is set up, we will set up the validation rules for our Order model as we did previously for the Album model. Right-click on the Models folder and add a class named Order. In addition to the validation attributes we used previously for the Album, we will also be using a Regular Expression to validate the user's e-mail address.

[!code-csharp[Main](mvc-music-store-part-9/samples/sample11.cs)]

Attempting to submit the form with missing or invalid information will now show error message using client-side validation.

![](mvc-music-store-part-9/_static/image7.png)

Okay, we've done most of the hard work for the checkout process; we just have a few odds and ends to finish. We need to add two simple views, and we need to take care of the handoff of the cart information during the login process.

## Adding the Checkout Complete view

The Checkout Complete view is pretty simple, as it just needs to display the Order ID. Right-click on the Complete controller action and add a view named Complete which is strongly typed as an int.

![](mvc-music-store-part-9/_static/image8.png)

Now we will update the view code to display the Order ID, as shown below.

[!code-cshtml[Main](mvc-music-store-part-9/samples/sample12.cshtml)]

## Updating The Error view

The default template includes an Error view in the Shared views folder so that it can be re-used elsewhere in the site. This Error view contains a very simple error and doesn't use our site Layout, so we'll update it.

Since this is a generic error page, the content is very simple. We'll include a message and a link to navigate to the previous page in history if the user wants to re-try their action.

[!code-cshtml[Main](mvc-music-store-part-9/samples/sample13.cshtml)]

*Please use the Discussions at [http://mvcmusicstore.codeplex.com](http://mvcmusicstore.codeplex.com) for any questions or comments.*

>[!div class="step-by-step"]
[Previous](mvc-music-store-part-8.md)
[Next](mvc-music-store-part-10.md)