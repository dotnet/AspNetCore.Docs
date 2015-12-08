.. _security-authorization-role-based:

Role based Authorization
========================

When an identity is created it may belong to one or more roles, for example Tracy may belong to the Administrator and User roles whilst Scott may only belong to the user role. How these roles are created and managed depends on the backing store of the authorization process. Roles are exposed to the developer through the `IsInRole <https://msdn.microsoft.com/en-us/library/system.security.claims.claimsprincipal.isinrole(v=vs.110).aspx>`_ property on the `ClaimsPrinciple <https://msdn.microsoft.com/en-us/library/system.security.claims.claimsprincipal(v=vs.110).aspx>`_ class.

Adding role checks
------------------

Role based authorization checks are declarative - the developer embeds them within their code, against a controller or an action within a controller, specifying roles which the current user must be a member of to access the requested resource.

For example the following code would limit access to any actions on the Administration controller to users who are a member of the Administrator group.

.. code-block:: c#

  [Authorize(Roles = "Administrator")]
  public class AdministrationController : Controller
  {  
  }

You can specify multiple roles as a comma separated list;

.. code-block:: c#

  [Authorize(Roles = "HRManager, Finance")]
  public class SalaryController : Controller
  {  
  }

This controller would be only accessible by users who are members of the HRManager role or the Finance Role.

If you apply multiple attributes then an accessing user must be a member of all the roles specified; the following sample requires that a user must be a member of both the PowerUser and ControlPanelUser role.

.. code-block:: c#

  [Authorize(Roles = "PowerUser")]
  [Authorize(Roles = "ControlPanelUser")]
  public class ControlPanelController : Controller
  {  
  }

You can further limit access by applying additional role authorization attributes at the action level;

.. code-block:: c#

  [Authorize(Roles = "Administrator, PowerUser")]
  public class ControlPanelController : Controller
  {  
      public ActionResult SetTime()
      {      
      }

      [Authorize(Roles = "Administrator")]
      public ActionResult ShutDown()
      {      
      }
  }

In the previous code snippet both members of the Administrator role and the PowerUser role can access the controller and the SetTime action, but only members of the Administrator role can access the ShutDown action.

You can also lock down a controller but allow anonymous, unauthenticated access to individual actions.

.. code-block:: c#

  [Authorize]
  public class ControlPanelController : Controller
  {  
      public ActionResult SetTime()
      {      
      }

      [AllowAnonymous]
      public ActionResult Login()
      {      
      }
  }

.. _security-authorization-role-policy:

Policy based role checks
------------------------

Role requirements can also be expressed using the new Policy syntax, where a developer registers a policy at startup as part of the Authorization service configuration. This normally takes part in`` ConfigureServices()`` in your ``startup.cs`` file.

.. code-block:: c#

 public void ConfigureServices(IServiceCollection services)
 {
     services.AddMvc();

     services.AddAuthorization(options =>
     {
         options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
     }
 }

Policies are applied using the ``Policy`` parameter on the ``Authorize`` attribute;

.. code-block:: c#

 [Authorize(Policy = "RequireAdministratorRole")]
 public IActionResult Shutdown()
 {
     return View();
 }

If you want to specify multiple allowed roles in a requirement then you you can specify them as parameters to the ``RequireRole`` method;

.. code-block:: c#

  options.AddPolicy("ElevatedRights", policy => 
                    policy.RequireRole("Administrator", "PowerUser", "BackupAdministrator"));

This example would authorize any user who has a role of Administrator, PowerUser and/or BackupAdministrator.