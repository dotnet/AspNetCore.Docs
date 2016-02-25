.. _security-authorization-claims-based:

Claims-Based Authorization
==========================

When an identity is created it may be assigned one or more claims issued by a trusted party. A claim is key value pair, the key being the claim name and the value being the claim value. A claim is what the subject is, not what the subject can do. For example you may have a Drivers License, issued by a local driving license authority. Your driver's license has your date of birth on it. In this case the claim name would be DateOfBirth, the claim value would be your date of birth, for example 8th June 1970 and the issuer would be the driving license authority. Claims based authorization, at its simplest, checks the value of a claim and allows access to a resource based upon that value, for example if you want access to a night club the authorization process, the door man, would evaluate the value of your DateOfBirth claim and whether they trust the issuer, the Driving License Authority before granting you access.

An identity can contain multiple claims with multiple values and can contain multiple claims of the same type.

Adding claims checks
--------------------

Claim based authorization checks are declarative - the developer embeds them within their code, against a controller or an action within a controller, specifying claims which the current user must process, and optionally the value the claim must hold to access the requested resource. Claims requirements are policy based, the developer must build and register a policy expressing the claims requirements.

The simplest type of claim policy looks for the presence of a claim and does not check the value.

First you need to build and register the policy. This takes place as part of the Authorization service configuration, which normally takes part in ``ConfigureServices()`` in your ``startup.cs`` file.

.. code-block:: c#

 public void ConfigureServices(IServiceCollection services)
 {
     services.AddMvc();

     services.AddAuthorization(options =>
     {
         options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
     });
 }

In this case the EmployeeOnly policy checks for the presence of an EmployeeNumber claim on the current identity.

You then apply the policy using the ``Policy`` parameter on the ``Authorize`` attribute to specify the policy name;

.. code-block:: c#

 [Authorize(Policy = "EmployeeOnly")]
 public IActionResult VacationBalance()
 {
     return View();
 }

The ``Authorize`` attribute can be applied to an entire controller, in this instance only identities matching the policy will be allowed access to any Action on the controller.

.. code-block:: c#

  [Authorize(Policy = "EmployeeOnly")]
  public class VactionController : Controller
  {  
      public ActionResult VacationBalance()
      {      
      }
  }

If you have a controller that is protected by the ``Authorize`` attribute, but want to allow anonymous access to particular actions you apply the ``AllowAnonymous`` attribute;

.. code-block:: c#

  [Authorize(Policy = "EmployeeOnly")]
  public class VacationController : Controller
  {  
      public ActionResult VacationBalance()
      {      
      }

      [AllowAnonymous]
      public ActionResult VacationPolicy()
      {      
      }
  }

Remember that most claims come with a value. You can specify a list of allowed values when creating the policy. The following example would only succeed for employees whose employee number was 1, 2, 3, 4 or 5.

.. code-block:: c#

 public void ConfigureServices(IServiceCollection services)
 {
     services.AddMvc();

     services.AddAuthorization(options =>
     {
         options.AddPolicy("Founders", policy => 
                           policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
     }
 }

Multiple Policy Evaluation
--------------------------

If you apply multiple policies to a controller or action then all policies must pass before access is granted. For example;

.. code-block:: c#

  [Authorize(Policy = "EmployeeOnly")]
  public class SalaryController : Controller
  {  
      public ActionResult Payslip()
      {      
      }

      [Authorize(Policy = "HumanResources")]
      public ActionResult UpdateSalary()
      {      
      }
  }

In the above example any identity which fulfills the EmployeeOnly policy can access the Payslip action as that policy is enforced on the controller. However in order to call the UpdateSalary action the identity must fulfill *both* the EmployeeOnly policy and the HumanResources policy.

If you want more complicated policies, such as taking a Date of Birth claim, calculating an age from it then checking the age is 21 or older then you need to write :ref:`custom policy handlers <security-authorization-policies-based>`.
