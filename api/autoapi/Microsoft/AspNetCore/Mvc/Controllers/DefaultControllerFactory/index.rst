

DefaultControllerFactory Class
==============================






Default implementation for :any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerFactory`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Controllers`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory`








Syntax
------

.. code-block:: csharp

    public class DefaultControllerFactory : IControllerFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory.DefaultControllerFactory(Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Internal.IControllerPropertyActivator>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory`\.
    
        
    
        
        :param controllerActivator: 
            :any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator` used to create controller instances.
        
        :type controllerActivator: Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator
    
        
        :param propertyActivators: 
            A set of :any:`Microsoft.AspNetCore.Mvc.Internal.IControllerPropertyActivator` instances used to initialize controller
            properties.
        
        :type propertyActivators: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Internal.IControllerPropertyActivator<Microsoft.AspNetCore.Mvc.Internal.IControllerPropertyActivator>}
    
        
        .. code-block:: csharp
    
            public DefaultControllerFactory(IControllerActivator controllerActivator, IEnumerable<IControllerPropertyActivator> propertyActivators)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory.ControllerActivator
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator` used to create a controller.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator
    
        
        .. code-block:: csharp
    
            protected IControllerActivator ControllerActivator { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory.CreateController(Microsoft.AspNetCore.Mvc.ControllerContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public virtual object CreateController(ControllerContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerFactory.ReleaseController(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void ReleaseController(ControllerContext context, object controller)
    

