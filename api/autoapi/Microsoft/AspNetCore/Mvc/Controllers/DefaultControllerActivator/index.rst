

DefaultControllerActivator Class
================================






:any:`Microsoft.AspNetCore.Mvc.Controllers.IControllerActivator` that uses type activation to create controllers.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator`








Syntax
------

.. code-block:: csharp

    public class DefaultControllerActivator : IControllerActivator








.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator.DefaultControllerActivator(Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator`\.
    
        
    
        
        :param typeActivatorCache: The :any:`Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache`\.
        
        :type typeActivatorCache: Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache
    
        
        .. code-block:: csharp
    
            public DefaultControllerActivator(ITypeActivatorCache typeActivatorCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator.Create(Microsoft.AspNetCore.Mvc.ControllerContext)
    
        
    
        
        :type controllerContext: Microsoft.AspNetCore.Mvc.ControllerContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public virtual object Create(ControllerContext controllerContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.DefaultControllerActivator.Release(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void Release(ControllerContext context, object controller)
    

