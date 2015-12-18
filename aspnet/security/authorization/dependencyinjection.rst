.. _security-authorization-di:

Dependency Injection in Requirement Handlers
============================================

As :ref:`handlers must be registered <security-authorization-policies-based-handler-registration>` in the service collection they support :ref:`dependency injection <fundamentals-dependency-injection>`. If, for example, you had a repository of rules you want to evaluate inside a handler and that repository is registered in the service collection authorization will resolve and inject that into your constructor.

For example, if you wanted to use ASP.NET's logging infrastructure you would to inject ``ILoggerFactory`` into your handler. Such a handler might look like this;

.. code-block:: c#

 public class LoggingAuthorizationHandler : AuthorizationHandler<MyRequirement>
 {
     ILogger _logger;

     public LoggingAuthorizationHandler(ILoggerFactory loggerFactory)
     {
         _logger = loggerFactory.CreateLogger(this.GetType().FullName);
     }

     protected override void Handle(AuthorizationContext context, MyRequirement requirement)
     {
        _logger.LogInformation("Inside my handler");
        // Check if the requirement is fulfilled.
     }
 }

Then you register handlers with ``services.AddSingleton()``, for example

.. code-block:: c#

 services.AddSingleton<IAuthorizationHandler, LoggingAuthorizationHandler>();

An instance of the handler will be created when your application starts, and DI will inject the registered ILoggerFactory into your constructor.