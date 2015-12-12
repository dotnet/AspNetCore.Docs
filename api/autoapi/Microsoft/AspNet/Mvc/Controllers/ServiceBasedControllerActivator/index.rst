

ServiceBasedControllerActivator Class
=====================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Controllers.IControllerActivator` that retrieves controllers as services from the request's 
:any:`System.IServiceProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ServiceBasedControllerActivator`








Syntax
------

.. code-block:: csharp

   public class ServiceBasedControllerActivator : IControllerActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/ServiceBasedControllerActivator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ServiceBasedControllerActivator

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ServiceBasedControllerActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ServiceBasedControllerActivator.Create(Microsoft.AspNet.Mvc.ActionContext, System.Type)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type controllerType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Create(ActionContext actionContext, Type controllerType)
    

