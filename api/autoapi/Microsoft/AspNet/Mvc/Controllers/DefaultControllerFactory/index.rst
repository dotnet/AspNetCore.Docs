

DefaultControllerFactory Class
==============================



.. contents:: 
   :local:



Summary
-------

Default implementation for :any:`Microsoft.AspNet.Mvc.Controllers.IControllerFactory`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory`








Syntax
------

.. code-block:: csharp

   public class DefaultControllerFactory : IControllerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/DefaultControllerFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory.DefaultControllerFactory(Microsoft.AspNet.Mvc.Controllers.IControllerActivator, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Controllers.IControllerPropertyActivator>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory`\.
    
        
        
        
        :param controllerActivator: used to create controller instances.
        
        :type controllerActivator: Microsoft.AspNet.Mvc.Controllers.IControllerActivator
        
        
        :param propertyActivators: A set of  instances used to initialize controller
            properties.
        
        :type propertyActivators: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Controllers.IControllerPropertyActivator}
    
        
        .. code-block:: csharp
    
           public DefaultControllerFactory(IControllerActivator controllerActivator, IEnumerable<IControllerPropertyActivator> propertyActivators)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory.CreateController(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public virtual object CreateController(ActionContext actionContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory.ReleaseController(System.Object)
    
        
        
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           public virtual void ReleaseController(object controller)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerFactory.ControllerActivator
    
        
    
        The :any:`Microsoft.AspNet.Mvc.Controllers.IControllerActivator` used to create a controller.
    
        
        :rtype: Microsoft.AspNet.Mvc.Controllers.IControllerActivator
    
        
        .. code-block:: csharp
    
           protected IControllerActivator ControllerActivator { get; }
    

