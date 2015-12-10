.. include:: /../common/stub-topic.txt

|stub-icon| Routing to Controller Actions
=========================================

What is Routing?  Routing is the term we use to describe the process through which we expose our content or application features to the world.  In the early days of the web we didn’t think about routing as most web sites or applications simply referenced folders and files on a disk.  So if you had a url for http://example.com/books/mybook.htm then there actually was a folder called books with a file called mybook.htm on the disk someplace.  With modern web frameworks like ASP.net MVC we do not have to structure our content or application exactly how the world will see it.  We can present it however we choose and organize our software in the way that makes sense.  Routing is what we use to connect our code to the urls and features our application exposes.  Routes can be public, they can be private, we can specify who can see a route and what incoming data is allowable.  We can also create multiple routes that lead to the same content if we desire.

Routing at The Action Level
**********************************************
A simple example that specifies the entire route at the action level.
 
 .. literalinclude:: routing/sample/routingSample/Controllers/OrdersController.cs
  :language: C#
  :lines: 106-117  
	
 In this example we have fully declared the route at the Action level.  We do this by using the Route attribute.  Our route specifies a name for the controller Orders, and a parameter orderId.  If we were to use this to find a Order say 1234 then our route would look like this /orders/1234.

 Using Html Helpers to create an action link for this route.  

 .. code-block:: none
  :emphasize-lines: 1
  
  @Html.ActionLink("View Order", "GetByOrderID", "Orders", new {orderId = 5678})
  
Will produce a url like /orders/5678 
This works really well if we have a single action, but that’s rarely going to be the case and repeating the name of the controller over and over again is not a great practice – simply because it could change or we might want to refer to it differently.  The fewer places to change it, the better.

Routing at the Class Level
**********************************************

Now let's take a look at our orders controller.  Instead of handling all of the routing at the action level, we can handle some of it at the class level and build up the routes in the actions ensuring that we don't repeat ourselves and reuse our routing logic.

 .. literalinclude:: routing/sample/routingSample/Controllers/OrdersController.cs
  :language: C#
  :lines: 12-50,121-123
  :emphasize-lines: 53,66
  
 
Using Constraints 
---------------------------------
We also can use constraints to help route to our controller actions.  Let’s say that we have two concepts, an OrderID which is an integer and an Order Subject which is a string.  If we use constraints on our routes we can support both concepts easily.  

Our goal will be to be able to use the route /orders/1234 to view an order by its Integer ID,  but also to use /orders/mybacktoschoolorder to view an order by its subject.  

 .. literalinclude:: routing/sample/routingSample/Controllers/OrdersController.cs
  :language: C#
  :lines: 53-70
  :emphasize-lines: 53,66

By simply putting in a constraint for the parameter, ASP.net is able to route requests for an integer to the action that is prepared to handle them, and the requests with the string value to the other action.  This lets us create a nice experience from a url point of view in that we can keep our urls, short and simple.

Using HTTP Verbs
-----------------------------
Another common scenario is wanting the same route to react differently depending upon what the http verb is.  For example, I might want a page that displays an order by id with the route /orders/1234 but also on that page be able to edit the order, change a quantity or a price etc..  Then I’d want to post that data back to the server and have it updated in the database.  
 
Our requirements here: 
GET /orders/1234 shows the order and lets us build a form.  
POST /orders/1234 allows us to post the edited order back to the server for processing.  

 .. literalinclude:: routing/sample/routingSample/Controllers/OrdersController.cs
  :language: C#
  :lines: 45-64

	
By supplying an additional Attribute, we are able to give asp.net the context it needs to make the correct decision when it routes the request to our action.  Http Verbs are used extensively when creating APIs, as we’ll see more examples of when it comes time to look at inheritance. 

Overriding the Route
------------------------------------

This is great functionality, its very useful, but what if we don’t want the routes to build upon one another.  Let’s say we have a business requirement to support urls like 

===========  =========================
Url                       Desired Goal  
===========  =========================
orders/1234       list a specific order
orders                list all orders 
my-orders          list all orders for the current user
===========  =========================
 
In that case, two of our routes can use the information specified by the controller, but the third cannot.  And create a whole separate controller for this seems like a bad idea.  What option do we have? 
Luckily we can choose to override the information specified for the route in previous Route attributes (either inherited, or from controller).  To do this we append ~/ to the start of the route.
Here’s what that looks like.


 .. literalinclude:: routing/sample/routingSample/Controllers/OrdersController.cs
  :language: C#
  :lines: 72-102
  
      
The route on line 1 sets up the route for the controller, but to meet our requirement of having a url /my-orders we append ~/ to the route on line 4.  Now when we make a request to /my-orders asp.net will route that request to our action here.

With a route like this we’ll be able to view this at /my-orders instead of /orders/my-orders.  

Using Inheritance
**********************************************
For this next section, I want to illustrate a slightly more advanced use of routing that when used in your applications can bring some pretty interesting capabilities to the table.  
We want to make our applications intuitive, but sometimes despite our best results its important to offer some help for our users.  By using inheritance with Routing you can create a great system that’s very easy to maintain. 
Here’s our Requirements:  Have a default help page that can be accessed by /something/help where something is a controller – ie Orders or Products.  Also have the ability to very easily override that functionality and supply different content at the view or even at the functional level in the controller.  
To do this we’ll create a new Controller called BaseController

 .. literalinclude:: routing/sample/routingSample/Controllers/BaseController.cs
  :language: C#
  
There are a few things to take note of with this code.  First, look at the Route attribute it uses the new Data Token syntax, where [controller] is replaced with the name of the controller at runtime.  
For this action, I’ve created a simple view in the Shared folder called Help with some default help content.


 .. literalinclude:: routing/sample/routingSample/Views/Shared/Help.cshtml
   :language: javascript

We’ll then replace the inheritance for our Orders controller so that it will inherit from this new controller instead.

 .. code-block:: c#
  :emphasize-lines: 2
  
    [Route("orders")]
    public class OrdersController : BaseController
    {
       // Methods snipped for brevity.
    }

We’ll also add a new controller called Products 

 .. literalinclude:: routing/sample/routingSample/Controllers/ProductsController.cs
  :language: C#

Once we compile the code we’ll quickly see that we can view the new help action from both the Orders and Products controllers just the way we expect.  Both controllers display the help text that we put into the shared view folder.

Now let’s push this a bit further, let’s say that we need to supply different content for the orders controller.  To accomplish this we create a help view in the Orders view folder.

 .. literalinclude:: routing/sample/routingSample/Views/Orders/Help.cshtml
   :language: javascript
   
  
Now compile and let’s try it.  For Orders we see a different set of help content just as we wanted.  Ok let’s take it one step further.  Let’s introduce a new controller Finance and let’s assume that if you need Finance help there’s a special support site you go to.  So for that scenario we’ll need to redirect the user to specialsupportsite.example.com 
Here’s how we can do this.  Create a new controller FinanceController.  Don’t forget to derive from BaseController instead of Controller.
 
 .. literalinclude:: routing/sample/routingSample/Controllers/FinanceController.cs
  :emphasize-lines: 9,11
  :language: C#
   
    


	
.. _issue: https://github.com/aspnet/Docs/issues/117
