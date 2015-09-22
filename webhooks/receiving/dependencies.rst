Receiver Dependencies
=====================

Microsoft ASP.NET WebHooks is designed with dependency injection in mind. Most dependencies in the system 
can be replaced with alternative implementations using a dependency injection engine.

Please see `DependencyScopeExtensions <https://github.com/aspnet/WebHooks/blob/master/src/Microsoft.AspNet.WebHooks.Receivers/Extensions/DependencyScopeExtensions.cs>`_ 
for a list of receiver dependencies. If no dependency has been registered, a default implementation is used. Please see `ReceiverServices <https://github.com/aspnet/WebHooks/blob/master/src/Microsoft.AspNet.WebHooks.Receivers/Services/ReceiverServices.cs>`_ 
for a list of default implementations.
