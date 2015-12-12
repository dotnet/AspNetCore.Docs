

DefaultControllerActivator Class
================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.Controllers.IControllerActivator` that uses type activation to create controllers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerActivator`








Syntax
------

.. code-block:: csharp

   public class DefaultControllerActivator : IControllerActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/DefaultControllerActivator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActivator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActivator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActivator.DefaultControllerActivator(Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerActivator`\.
    
        
        
        
        :param typeActivatorCache: The .
        
        :type typeActivatorCache: Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache
    
        
        .. code-block:: csharp
    
           public DefaultControllerActivator(ITypeActivatorCache typeActivatorCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerActivator.Create(Microsoft.AspNet.Mvc.ActionContext, System.Type)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type controllerType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public virtual object Create(ActionContext actionContext, Type controllerType)
    

