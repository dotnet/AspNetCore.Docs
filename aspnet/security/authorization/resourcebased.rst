.. _security-authorization-resource-based:

Resource Based Authorization
============================

Often authorization depends upon the resource being accessed. For example a document may have an author property. Only the document author would be allowed to update it, so the resource must be loaded from the document repository before an authorization evaluation can be made. This cannot be done with an Authorize attribute, as attribute evaluation takes place before data binding and before your own code to load a resource runs inside an action. Instead of declarative authorization, the attribute method, we must use imperative authorization, where a developer calls an authorize function within his own code.

Authorizing within your code
----------------------------

Authorization is implemented as a service, ``IAuthorizationService``, registered in the service collection and available for DI into Controllers.

.. code-block:: c#

 public class DocumentController : Controller
 {  
     IAuthorizationService authorizationService;

     public DocumentController(IAuthorizationService authorizationService)
     {
         this.authorizationService = authorizationService;
     }
 }

``IAuthorizationService`` has two methods, one where you pass the resource and the policy name and the other where you pass the resource and a list of requirements to evaluate.

.. code-block:: c#

 Task<bool> AuthorizeAsync(ClaimsPrincipal user, 
                           object resource, 
                           IEnumerable<IAuthorizationRequirement> requirements);
 Task<bool> AuthorizeAsync(ClaimsPrincipal user, 
                           object resource, 
                           string policyName);


.. _security-authorization-resource-based-imperative:

To call the service load your resource within your action then call the ``AuthorizeAsync`` method you require. For example

.. code-block:: c#

 public async Task<IActionResult> Edit(Guid documentId)
 {
     Document document = documentRepository.Find(documentId);

     if (document == null)
     {
         return new HttpNotFoundResult();
     }

     if (await authorizationService.AuthorizeAsync(User, document, "EditPolicy"))
     {
         return View(document);
     }
     else
     {
         return new ChallengeResult();
     }
 }

Writing a resource based handler
--------------------------------

Writing a handler for resource based authorization is not that much different to :ref:`writing a plain requirements handler <security-authorization-policies-based-authorization-handler>`. You create a requirement, and then implement a handler for the requirement, specifying the requirement as before and also the resource type. For example, a handler which might accept a Document resource would look as follows;

.. code-block:: c#

  public class DocumentAuthorizationHandler : AuthorizationHandler<MyRequirement, Document>
  {
      protected override void Handle(AuthorizationContext context, 
                                     OperationAuthorizationRequirement requirement, 
                                     Document resource)
      {
          // Validate the requirement against the resource and identity.
      }
  }

Don't forget to :ref:`register your handlers <security-authorization-policies-based-handler-registration>` during service configuration;

.. code-block:: c#

 services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();

Operational Requirements
~~~~~~~~~~~~~~~~~~~~~~~~

If you are making decisions based on operations such as read, write, update and delete an already defined ``OperationAuthorizationRequirement`` class exists in the ``Microsoft.AspNet.Authorization.Infrastructure`` namespace. This prebuilt requirement class enables you to write a single handler which has a parameterized operation name, rather than create individual classes for each operation To use it provide an operation name;

.. code-block:: c#

 public static class Operations
 {
     public static OperationAuthorizationRequirement Create = 
         new OperationAuthorizationRequirement { Name = "Create" };
     public static OperationAuthorizationRequirement Read = 
         new OperationAuthorizationRequirement   { Name = "Read" };
     public static OperationAuthorizationRequirement Update = 
         new OperationAuthorizationRequirement { Name = "Update" };
     public static OperationAuthorizationRequirement Delete = 
         new OperationAuthorizationRequirement { Name = "Delete" };
 }

Your handler could then be implemented as follows, using a hypothetical Document class as the resource;

.. code-block:: c#

  public class DocumentAuthorizationHandler : 
      AuthorizationHandler<OperationAuthorizationRequirement, Document>
  {
      protected override void Handle(AuthorizationContext context, 
                                     OperationAuthorizationRequirement requirement, 
                                     Document resource)
      {
          // Validate the operation using the resource, the identity and
          // the Name property value from the requirement.
      }
  }

You can see the handler works on ``OperationAuthorizationRequirement``. The code inside the handler must take the Name property of the supplied requirement into account when making its evaluations.