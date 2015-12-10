.. _security-authorization-simple:

Simple Authorization
====================

Authorization in MVC is controlled through the ``Authorize`` attribute and its various parameters. At its simplest applying the ``Authorize`` attribute to a controller or action limits access to the controller or action to any authorized user.

For example, the following code limits access to the AccountController to any authenticated user.

.. code-block:: c#

  [Authorize]
  public class AccountController : Controller
  {  
      public ActionResult Login()
      {      
      }

      public ActionResult Logout()
      {      
      }
  }

If you want to apply authorization to an action rather than the controller simply apply the ``Authorize`` attribute to the action itself;

.. code-block:: c#

  public class AccountController : Controller
  {  
      public ActionResult Login()
      {      
      }

      [Authorize]
      public ActionResult Logout()
      {      
      }
  }

Now only authenticated users can access the logout function.

You can also use the MVC's ``AllowAnonymous`` attribute to allow access by non-authenticated users to individual actions; for example

.. code-block:: c#

  [Authorize]
  public class AccountController : Controller
  {  
      [AllowAnonymous]
      public ActionResult Login()
      {      
      }

      public ActionResult Logout()
      {      
      }
  }

This would allow only authenticated users to the Account controller, except for the Login action, which is accessible by everyone, regardless of their authenticated or unauthenticated / anonymous status.

.. WARNING::
  ``[AllowAnonymous]`` bypasses all authorization statements. If you apply combine ``[AllowAnonymous]`` and any ``[Authorize]`` attribute then the Authorize attributes will always be ignored. For example if you apply ``[AllowAnonymous]`` at the controller level any ``[Authorize]`` attributes on the same controller, or on any action within it will be ignored.

