.. _security-authorization-di:

Dependency Injection in requirement handlers
============================================

:ref:`Authorization handlers must be registered <security-authorization-policies-based-handler-registration>` in the service collection during configuration (using :ref:`dependency injection <fundamentals-dependency-injection>`). 

Suppose you had a repository of rules you wanted to evaluate inside an authorization handler and that repository was registered in the service collection.  Authorization will resolve and inject that into your constructor.

For example, if you wanted to use ASP.NET's logging infrastructure you would to inject :dn:iface:`~Microsoft.Extensions.Logging.ILoggerFactory` into your handler. Such a handler might look like:

.. code-block:: c#

 public class LoggingAuthorizationHandler : AuthorizationHandler<MyRequirement>
 {
     ILogger _logger;

     public LoggingAuthorizationHandler(ILoggerFactory loggerFactory)
     {
         _logger = loggerFactory.CreateLogger(this.GetType().FullName);
     }

     protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyRequirement requirement)
     {
         _logger.LogInformation("Inside my handler");
         // Check if the requirement is fulfilled.
         return Task.CompletedTask;
     }
 }

You would register the handler with ``services.AddSingleton()``:

.. code-block:: c#

 services.AddSingleton<IAuthorizationHandler, LoggingAuthorizationHandler>();

An instance of the handler will be created when your application starts, and DI will inject the registered :dn:iface:`~Microsoft.Extensions.Logging.ILoggerFactory` into your constructor.

.. note:: Handlers that use Entity Framework shouldn't be registered as singletons.