.. _security-authorization-policies-based:

Custom Policy-Based Authorization
=================================

By `Rick Anderson`_

Underneath the covers the :ref:`role authorization <security-authorization-role-based>` and :ref:`claims authorization <security-authorization-claims-based>` make use of a requirement, a handler for the requirement and a pre-configured policy. These building blocks allow you to express authorization evaluations in code, allowing for a richer, reusable, and easily testable authorization structure. 

An authorization policy is made up of one or more requirements and registered at application startup as part of the Authorization service configuration, in ``ConfigureServices`` in the *Startup.cs* file.

.. code-block:: c#

 public void ConfigureServices(IServiceCollection services)
 {
     services.AddMvc();

     services.AddAuthorization(options =>
     {
         options.AddPolicy("Over21", 
                           policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
     }
 });

Here you can see an "Over21" policy is created with a single requirement, that of a minimum age, which is passed as a parameter to the requirement.

Policies are applied using the ``Authorize`` attribute simply by specifying the policy name, for example

.. code-block:: c#

  [Authorize(Policy="Over21")]
  public class AlcoholPurchaseRequirementsController : Controller
  {  
      public ActionResult Login()
      {      
      }

      public ActionResult Logout()
      {      
      }
  }

Requirements
------------
An authorization requirement is a collection of data parameters that a policy can use to evaluate the current user principal. In our Minimum Age policy the requirement we have a single parameter, the minimum age. A requirement must implement ``IAuthorizationRequirement``. This is an empty, marker interface. A parameterized minimum age requirement might be implemented as follows;

.. code-block:: c#

 public class MinimumAgeRequirement : IAuthorizationRequirement
 {
     public MinimumAgeRequirement(int age)
     {
         MinimumAge = age;
     }

     protected int MinimumAge { get; set; }
 }

A requirement doesn't need to have data or properties.

.. _security-authorization-policies-based-authorization-handler:

Authorization Handlers
----------------------

An authorization handler is responsible for the evaluation of any properties of a requirement. The  authorization handler must evaluate them against a provided ``AuthorizationContext`` to decide if authorization is allowed. A requirement can have :ref:`multiple handlers <security-authorization-policies-based-multiple-handlers>`. Handlers must inherit ``AuthorizationHandler<T>`` where T is the requirement it handles. 

.. _security-authorization-handler-example:

The minimum age handler might look like this:

.. code-block:: c#

 public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
 {
     protected override void Handle(AuthorizationContext context, MinimumAgeRequirement requirement)
     {
         if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth && 
                                    c.Issuer == "http://contoso.com"))
         {
             return;
         }

         var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(
             c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "http://contoso.com").Value);

         int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
         if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
         {
             calculatedAge--;
         }

         if (calculatedAge >= requirement.MinimumAge)
         {
             context.Succeed(requirement);
         }
     }
 }

In the code above we first look to see if the current user principal has a date of birth claim which has been issued by an Issuer we know and trust. If the claim is missing we can't authorize so we return. If we have a claim, we figure out how old the user is, and if they meet the minimum age passed in by the requirement then authorization has been successful. Once authorization is successful we call ``context.Succeed()`` passing in the requirement that has been successful as a parameter.

.. _security-authorization-policies-based-handler-registration:

Handlers must be registered in the services collection during configuration, for example;

.. code-block:: c#

 public void ConfigureServices(IServiceCollection services)
 {
     services.AddMvc();

     services.AddAuthorization(options =>
     {
         options.AddPolicy("Over21", 
                           policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
     });

     services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
 }

Each handler is added to the services collection by using ``services.AddSingleton<IAuthorizationHandler, YourHandlerClass>();`` passing in your handler class.

What should a handler return?
-----------------------------

You can see in our :ref:`handler example <security-authorization-handler-example>` that the ``Handle()`` method has no return value, so how do we indicate success or failure?

* A handler indicates success by calling ``context.Succeed(IAuthorizationRequirement requirement)``, passing the requirement that has been successfully validated.
* A handler does not need to handle failures generally, as other handlers for the same requirement may succeed.
* To guarantee failure even if other handlers for a requirement succeed, call ``context.Fail``. 
 
Regardless of what you call inside your handler all handlers for a requirement will be called when a policy requires the requirement. This allows requirements to have side effects, such as logging, which will always take place even if ``context.Fail()`` has been called in another handler.

.. _security-authorization-policies-based-multiple-handlers:

Why would I want multiple handlers for a requirement?
-----------------------------------------------------

In cases where you want evaluation to be on an **OR** basis you implement multiple handlers for a single requirement. For example, Microsoft has doors which only open with key cards. If you leave your key card at home the receptionist prints a temporary sticker and opens the door for you. In this scenario you'd have a single requirement, *EnterBuilding*, but multiple handlers, each one examining a single requirement. 

.. code-block:: c#

 public class EnterBuildingRequirement : IAuthorizationRequirement
 {
 }

 public class BadgeEntryHandler : AuthorizationHandler<EnterBuildingRequirement>
 {
     protected override void Handle(AuthorizationContext context, EnterBuildingRequirement requirement)
     {
         if (context.User.HasClaim(c => c.Type == ClaimTypes.BadgeId && 
                                        c.Issuer == "http://microsoftsecurity"))
         {
             context.Succeed(requirement);
         }
     }
 }

 public class HasTemporaryStickerHandler : AuthorizationHandler<EnterBuildingRequirement>
 {
     protected override void Handle(AuthorizationContext context, EnterBuildingRequirement requirement)
     {
         if (context.User.HasClaim(c => c.Type == ClaimTypes.TemporaryBadgeId && 
                                        c.Issuer == "http://microsoftsecurity"))
         {
             // We'd also check the expiration date on the sticker.
             context.Succeed(requirement);
         }
     }
 }

Now, assuming both handlers are :ref:`registered <security-authorization-policies-based-handler-registration>` when a policy evaluates the ``EnterBuildingRequirement`` if either handler succeeds the policy evaluation will succeed.

Accessing Request Context In Handlers
-------------------------------------

The ``Handle`` method you must implement in an authorization handler has two parameters, an ``AuthorizationContext`` and the ``Requirement`` you are handling. Frameworks such as MVC or Jabbr are free to add any object to the ``Resource`` property on the ``AuthorizationContext`` to pass through extra information.

For example MVC passes an instance of ``Microsoft.AspNetCore.Mvc.Filters.AuthorizationContext`` in the resource property which is used to access HttpContext, RouteData and everything else MVC provides.

The use of the ``Resource`` property is framework specific. Using information in the ``Resource`` property will limit your authorization policies to particular frameworks. You should cast the ``Resource`` property using the ``as`` keyword, and then check the cast has succeed to ensure your code doesn't crash with ``InvalidCastExceptions`` when run on other frameworks;

.. code-block:: c#
 
 var mvcContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationContext;

 if (mvcContext != null)
 {
     // Examine MVC specific things like routing data.
 }

